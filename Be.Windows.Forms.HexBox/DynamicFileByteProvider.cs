using System;
using System.IO;

namespace Be.Windows.Forms
{
    /// <summary>
    /// Implements a fully editable byte provider for file data of any size.
    /// </summary>
    /// <remarks>
    /// Only changes to the file are stored in memory with reads from the
    /// original data occurring as required.
    /// </remarks>
    public sealed class DynamicFileByteProvider : IByteProvider, IDisposable
    {
        private const int COPY_BLOCK_SIZE = 4096;
        private string _fileName;
        private Stream _stream;
        private DataMap _dataMap;
        private long _totalLength;
        private readonly bool _readOnly;

        /// <summary>
        /// Ŀǰ�ļ���
        /// </summary>
        public Stream Stream { get { return _stream; } }

        /// <summary>
        /// Constructs a new <see cref="DynamicFileByteProvider" /> instance.
        /// </summary>
        /// <param name="fileName">The name of the file from which bytes should be provided.</param>
        public DynamicFileByteProvider(string fileName) : this(fileName, false) { }

        /// <summary>
        /// Constructs a new <see cref="DynamicFileByteProvider" /> instance.
        /// </summary>
        /// <param name="fileName">The name of the file from which bytes should be provided.</param>
        /// <param name="readOnly">True, opens the file in read-only mode.</param>
        public DynamicFileByteProvider(string fileName, bool readOnly)
        {
            FileName = fileName;

            if (!readOnly)
            {
                _stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            }
            else
            {
                _stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }

            _readOnly = readOnly;

            ReInitialize();
        }

        /// <summary>
        /// Constructs a new <see cref="DynamicFileByteProvider" /> instance.
        /// </summary>
        /// <param name="stream">the stream containing the data.</param>
        /// <remarks>
        /// The stream must supported seek operations.
        /// </remarks>
        public DynamicFileByteProvider(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!stream.CanSeek)
                throw new ArgumentException("stream must supported seek operations(CanSeek)");

            _stream = stream;
            _readOnly = !stream.CanWrite;
            ReInitialize();
        }

        #region IByteProvider Members

        /// <summary>
        /// See <see cref="IByteProvider.LengthChanged" /> for more information.
        /// </summary>
        public event EventHandler LengthChanged;

        /// <summary>
        /// See <see cref="IByteProvider.Changed" /> for more information.
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// See <see cref="IByteProvider.ReadByte" /> for more information.
        /// </summary>
        public byte ReadByte(long index)
        {
            try
            {
                DataBlock block = GetDataBlock(index, out long blockOffset);
                if (block is FileDataBlock fileBlock)
                {
                    return ReadByteFromFile(fileBlock.FileOffset + index - blockOffset);
                }
                else
                {
                    MemoryDataBlock memoryBlock = (MemoryDataBlock)block;
                    return memoryBlock.Data[index - blockOffset];
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// See <see cref="IByteProvider.WriteByte" /> for more information.
        /// </summary>
        public void WriteByte(long index, byte value)
        {
            try
            {
                // Find the block affected.
                DataBlock block = GetDataBlock(index, out long blockOffset);

                // If the byte is already in a memory block, modify it.
                if (block is MemoryDataBlock memoryBlock)
                {
                    memoryBlock.Data[index - blockOffset] = value;
                    return;
                }

                FileDataBlock fileBlock = (FileDataBlock)block;

                // If the byte changing is the first byte in the block and the previous block is a memory block, extend that.
                if (blockOffset == index && block.PreviousBlock != null)
                {
                    if (block.PreviousBlock is MemoryDataBlock previousMemoryBlock)
                    {
                        previousMemoryBlock.AddByteToEnd(value);
                        fileBlock.RemoveBytesFromStart(1);
                        if (fileBlock.Length == 0)
                        {
                            _dataMap.Remove(fileBlock);
                        }
                        return;
                    }
                }

                // If the byte changing is the last byte in the block and the next block is a memory block, extend that.
                if (blockOffset + fileBlock.Length - 1 == index && block.NextBlock != null)
                {
                    if (block.NextBlock is MemoryDataBlock nextMemoryBlock)
                    {
                        nextMemoryBlock.AddByteToStart(value);
                        fileBlock.RemoveBytesFromEnd(1);
                        if (fileBlock.Length == 0)
                        {
                            _dataMap.Remove(fileBlock);
                        }
                        return;
                    }
                }

                // Split the block into a prefix and a suffix and place a memory block in-between.
                FileDataBlock prefixBlock = null;
                if (index > blockOffset)
                {
                    prefixBlock = new FileDataBlock(fileBlock.FileOffset, index - blockOffset);
                }

                FileDataBlock suffixBlock = null;
                if (index < blockOffset + fileBlock.Length - 1)
                {
                    suffixBlock = new FileDataBlock(
                        fileBlock.FileOffset + index - blockOffset + 1,
                        fileBlock.Length - (index - blockOffset + 1));
                }

                block = _dataMap.Replace(block, new MemoryDataBlock(value));

                if (prefixBlock != null)
                {
                    _dataMap.AddBefore(block, prefixBlock);
                }

                if (suffixBlock != null)
                {
                    _dataMap.AddAfter(block, suffixBlock);
                }
            }
            finally
            {
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// See <see cref="IByteProvider.InsertBytes" /> for more information.
        /// </summary>
        public void InsertBytes(long index, byte[] bs)
        {
            try
            {
                // Find the block affected.
                DataBlock block = GetDataBlock(index, out long blockOffset);

                // If the insertion point is in a memory block, just insert it.
                if (block is MemoryDataBlock memoryBlock)
                {
                    memoryBlock.InsertBytes(index - blockOffset, bs);
                    return;
                }

                FileDataBlock fileBlock = (FileDataBlock)block;

                // If the insertion point is at the start of a file block, and the previous block is a memory block, append it to that block.
                if (blockOffset == index && block.PreviousBlock != null)
                {
                    if (block.PreviousBlock is MemoryDataBlock previousMemoryBlock)
                    {
                        previousMemoryBlock.InsertBytes(previousMemoryBlock.Length, bs);
                        return;
                    }
                }

                // Split the block into a prefix and a suffix and place a memory block in-between.
                FileDataBlock prefixBlock = null;
                if (index > blockOffset)
                {
                    prefixBlock = new FileDataBlock(fileBlock.FileOffset, index - blockOffset);
                }

                FileDataBlock suffixBlock = null;
                if (index < blockOffset + fileBlock.Length)
                {
                    suffixBlock = new FileDataBlock(
                        fileBlock.FileOffset + index - blockOffset,
                        fileBlock.Length - (index - blockOffset));
                }

                block = _dataMap.Replace(block, new MemoryDataBlock(bs));

                if (prefixBlock != null)
                {
                    _dataMap.AddBefore(block, prefixBlock);
                }

                if (suffixBlock != null)
                {
                    _dataMap.AddAfter(block, suffixBlock);
                }
            }
            finally
            {
                _totalLength += bs.Length;
                OnLengthChanged(EventArgs.Empty);
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// See <see cref="IByteProvider.DeleteBytes" /> for more information.
        /// </summary>
        public void DeleteBytes(long index, long length)
        {
            try
            {
                long bytesToDelete = length;

                // Find the first block affected.
                DataBlock block = GetDataBlock(index, out long blockOffset);

                // Truncate or remove each block as necessary.
                while ((bytesToDelete > 0) && (block != null))
                {
                    long blockLength = block.Length;
                    DataBlock nextBlock = block.NextBlock;

                    // Delete the appropriate section from the block (this may result in two blocks or a zero length block).
                    long count = Math.Min(bytesToDelete, blockLength - (index - blockOffset));
                    block.RemoveBytes(index - blockOffset, count);

                    if (block.Length == 0)
                    {
                        _dataMap.Remove(block);
                        if (_dataMap.FirstBlock == null)
                        {
                            _dataMap.AddFirst(new MemoryDataBlock(new byte[0]));
                        }
                    }

                    bytesToDelete -= count;
                    blockOffset += block.Length;
                    block = (bytesToDelete > 0) ? nextBlock : null;
                }
            }
            finally
            {
                _totalLength -= length;
                OnLengthChanged(EventArgs.Empty);
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// See <see cref="IByteProvider.Length" /> for more information.
        /// </summary>
        public long Length
        {
            get
            {
                return _totalLength;
            }
        }

        /// <summary>
        /// See <see cref="IByteProvider.HasChanges" /> for more information.
        /// </summary>
        public bool HasChanges()
        {
            if (_readOnly)
                return false;

            if (_totalLength != _stream.Length)
            {
                return true;
            }

            long offset = 0;
            for (DataBlock block = _dataMap.FirstBlock; block != null; block = block.NextBlock)
            {
                if (!(block is FileDataBlock fileBlock))
                {
                    return true;
                }

                if (fileBlock.FileOffset != offset)
                {
                    return true;
                }

                offset += fileBlock.Length;
            }
            return (offset != _stream.Length);
        }

        /// <summary>
        /// See <see cref="IByteProvider.ApplyChanges" /> for more information.
        /// </summary>
        public void ApplyChanges(Stream stream = null)
        {
            var mstream = stream ?? _stream;

            if (stream == null && _readOnly)
                throw new OperationCanceledException("File is in read-only mode");

            // This method is implemented to efficiently save the changes to the same file stream opened for reading.
            // Saving to a separate file would be a much simpler implementation.

            // Firstly, extend the file length (if necessary) to ensure that there is enough disk space.
            if (_totalLength > mstream.Length)
            {
                mstream.SetLength(_totalLength);
            }

            // Secondly, shift around any file sections that have moved.
            long dataOffset = 0;
            for (DataBlock block = _dataMap.FirstBlock; block != null; block = block.NextBlock)
            {
                if (block is FileDataBlock fileBlock && fileBlock.FileOffset != dataOffset)
                {
                    MoveFileBlock(fileBlock, dataOffset);
                }
                dataOffset += block.Length;
            }

            // Next, write in-memory changes.
            dataOffset = 0;
            for (DataBlock block = _dataMap.FirstBlock; block != null; block = block.NextBlock)
            {
                if (block is MemoryDataBlock memoryBlock)
                {
                    mstream.Position = dataOffset;
                    for (int memoryOffset = 0; memoryOffset < memoryBlock.Length; memoryOffset += COPY_BLOCK_SIZE)
                    {
                        mstream.Write(memoryBlock.Data, memoryOffset, (int)Math.Min(COPY_BLOCK_SIZE, memoryBlock.Length - memoryOffset));
                    }
                }
                dataOffset += block.Length;
            }

            // Finally, if the file has shortened, truncate the stream.
            mstream.SetLength(_totalLength);
            if (stream == null)
                ReInitialize();
        }

        /// <summary>
        /// See <see cref="IByteProvider.SupportsWriteByte" /> for more information.
        /// </summary>
        public bool SupportsWriteByte()
        {
            return !_readOnly;
        }

        /// <summary>
        /// See <see cref="IByteProvider.SupportsInsertBytes" /> for more information.
        /// </summary>
        public bool SupportsInsertBytes()
        {
            return !_readOnly;
        }

        /// <summary>
        /// See <see cref="IByteProvider.SupportsDeleteBytes" /> for more information.
        /// </summary>
        public bool SupportsDeleteBytes()
        {
            return !_readOnly;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// See <see cref="Object.Finalize" /> for more information.
        /// </summary>
        ~DynamicFileByteProvider()
        {
            Dispose();
        }

        /// <summary>
        /// See <see cref="IDisposable.Dispose" /> for more information.
        /// </summary>
        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Close();
                _stream = null;
            }
            FileName = null;
            _dataMap = null;
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// Gets a value, if the file is opened in read-only mode.
        /// </summary>
        public bool ReadOnly
        {
            get { return _readOnly; }
        }

        /// <summary>
        /// �ļ���
        /// </summary>
        public string FileName { get => _fileName; set => _fileName = value; }

        private void OnLengthChanged(EventArgs e)
        {
            LengthChanged?.Invoke(this, e);
        }

        private void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        private DataBlock GetDataBlock(long findOffset, out long blockOffset)
        {
            if (findOffset < 0 || findOffset > _totalLength)
            {
                throw new ArgumentOutOfRangeException("findOffset");
            }

            // Iterate over the blocks until the block containing the required offset is encountered.
            blockOffset = 0;
            for (DataBlock block = _dataMap.FirstBlock; block != null; block = block.NextBlock)
            {
                if ((blockOffset <= findOffset && blockOffset + block.Length > findOffset) || block.NextBlock == null)
                {
                    return block;
                }
                blockOffset += block.Length;
            }
            return null;
        }

        private FileDataBlock GetNextFileDataBlock(DataBlock block, long dataOffset, out long nextDataOffset)
        {
            // Iterate over the remaining blocks until a file block is encountered.
            nextDataOffset = dataOffset + block.Length;
            block = block.NextBlock;
            while (block != null)
            {
                if (block is FileDataBlock fileBlock)
                {
                    return fileBlock;
                }
                nextDataOffset += block.Length;
                block = block.NextBlock;
            }
            return null;
        }

        private byte ReadByteFromFile(long fileOffset)
        {
            // Move to the correct position and read the byte.
            if (_stream.Position != fileOffset)
            {
                _stream.Position = fileOffset;
            }
            return (byte)_stream.ReadByte();
        }

        private void MoveFileBlock(FileDataBlock fileBlock, long dataOffset)
        {
            // First, determine whether the next file block needs to move before this one.
            FileDataBlock nextFileBlock = GetNextFileDataBlock(fileBlock, dataOffset, out long nextDataOffset);
            if (nextFileBlock != null && dataOffset + fileBlock.Length > nextFileBlock.FileOffset)
            {
                // The next block needs to move first, so do that now.
                MoveFileBlock(nextFileBlock, nextDataOffset);
            }

            // Now, move the block.
            if (fileBlock.FileOffset > dataOffset)
            {
                // Move the section to earlier in the file stream (done in chunks starting at the beginning of the section).
                byte[] buffer = new byte[COPY_BLOCK_SIZE];
                for (long relativeOffset = 0; relativeOffset < fileBlock.Length; relativeOffset += buffer.Length)
                {
                    long readOffset = fileBlock.FileOffset + relativeOffset;
                    int bytesToRead = (int)Math.Min(buffer.Length, fileBlock.Length - relativeOffset);
                    _stream.Position = readOffset;
                    _stream.Read(buffer, 0, bytesToRead);

                    long writeOffset = dataOffset + relativeOffset;
                    _stream.Position = writeOffset;
                    _stream.Write(buffer, 0, bytesToRead);
                }
            }
            else
            {
                // Move the section to later in the file stream (done in chunks starting at the end of the section).
                byte[] buffer = new byte[COPY_BLOCK_SIZE];
                for (long relativeOffset = 0; relativeOffset < fileBlock.Length; relativeOffset += buffer.Length)
                {
                    int bytesToRead = (int)Math.Min(buffer.Length, fileBlock.Length - relativeOffset);
                    long readOffset = fileBlock.FileOffset + fileBlock.Length - relativeOffset - bytesToRead;
                    _stream.Position = readOffset;
                    _stream.Read(buffer, 0, bytesToRead);

                    long writeOffset = dataOffset + fileBlock.Length - relativeOffset - bytesToRead;
                    _stream.Position = writeOffset;
                    _stream.Write(buffer, 0, bytesToRead);
                }
            }

            // This block now points to a different position in the file.
            fileBlock.SetFileOffset(dataOffset);
        }

        private void ReInitialize()
        {
            _dataMap = new DataMap();
            _dataMap.AddFirst(new FileDataBlock(0, _stream.Length));
            _totalLength = _stream.Length;
        }

        /// <summary>
        /// �滻�ļ�������ʵ�����Ϊ����
        /// </summary>
        /// <param name="newstream">�µ��ļ�������</param>
        public void ChangeStream(ref FileStream newstream)
        {
            if (newstream == null)
            {
                throw new ArgumentNullException("newstream");
            }

            _stream.Position = 0;
            newstream.Position = 0;
            _stream.CopyTo(newstream);
            _stream = newstream;
        }
    }
}