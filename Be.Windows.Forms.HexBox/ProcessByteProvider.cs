using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Be.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ProcessByteProvider : IByteProvider, IDisposable
    {
        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_VM_WRITE = 0x0020;

        private const int IMAGE_SIZEOF_FILE_HEADER = 20;

        private const ushort SizeOfImageOffset = 56;

        /// <summary>
        /// 
        /// </summary>
        public long Length => _stream.Length;

#pragma warning disable CS0067
        /// <summary>
        /// 
        /// </summary>
        [Obsolete("由于操作进程，暂不支持改变镜像大小", true)]
        public event EventHandler LengthChanged;
#pragma warning restore CS0067
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Changed;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr BaseAddr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Process Process { get; set; }

        private MemoryStream _stream;
        private DataMap _dataMap;
        private long _totalLength;
        private readonly bool _readOnly;
        private const int COPY_BLOCK_SIZE = 4096;
        private readonly IntPtr handle;

        /// <summary>
        /// Gets a value, if the file is opened in read-only mode.
        /// </summary>
        public bool ReadOnly => _readOnly;

        /// <summary>
        /// 目前文件流
        /// </summary>
        public Stream Stream { get { return _stream; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processid"></param>
        /// <param name="writeable"></param>
        public ProcessByteProvider(int processid,bool writeable=false)
        {
            _readOnly = !writeable;
            if ((handle = OpenProcess(writeable ? PROCESS_VM_READ | PROCESS_VM_WRITE : PROCESS_VM_READ, false, processid)) != IntPtr.Zero)
            {
                Process process = Process.GetProcessById(processid);
                Process = process;
                BaseAddr = process.MainModule.BaseAddress;
                IntPtr ptr = Marshal.AllocHGlobal(sizeof(int));
                ReadProcessMemory(process.Handle, BaseAddr + 0x3c, ptr, sizeof(int), IntPtr.Zero);
                int offset = Marshal.ReadInt32(ptr);
                ReadProcessMemory(process.Handle, BaseAddr + offset+
                    IMAGE_SIZEOF_FILE_HEADER+4+SizeOfImageOffset, ptr, sizeof(int), IntPtr.Zero);
                int sizeofimage = Marshal.ReadInt32(ptr);
                Marshal.FreeHGlobal(ptr);
                ptr = Marshal.AllocHGlobal(sizeofimage);
                ReadProcessMemory(process.Handle, BaseAddr, ptr, sizeofimage, IntPtr.Zero);
                byte[] buffer = new byte[sizeofimage];
                for (int i = 0; i < sizeofimage; i++)
                {
                    buffer[i] = Marshal.ReadByte(ptr + i);
                }
                _stream = new MemoryStream(buffer);
                Marshal.FreeHGlobal(ptr);
                ReInitialize();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="writeable"></param>
        public ProcessByteProvider(Process process, bool writeable = false)
        {
            _readOnly = !writeable;
            if (OpenProcess(writeable ? PROCESS_VM_READ | PROCESS_VM_WRITE : PROCESS_VM_READ, false, process.Id) != IntPtr.Zero)
            {
                Process = process;
                BaseAddr = process.MainModule.BaseAddress;
                int sizeofimage = process.MainModule.ModuleMemorySize;
                IntPtr  ptr = Marshal.AllocHGlobal(sizeofimage);
                ReadProcessMemory(process.Handle, BaseAddr, ptr, sizeofimage, IntPtr.Zero);

                byte[] buffer = new byte[sizeofimage];
                for (int i = 0; i < sizeofimage; i++)
                {
                    buffer[i] = Marshal.ReadByte(ptr + i);
                }
                _stream = new MemoryStream(buffer);
                Marshal.FreeHGlobal(ptr);
                ReInitialize();
            }
            else
            {
                throw new UnauthorizedAccessException("无法打开进程，拒绝访问");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~ProcessByteProvider()
        {
            Dispose();
        }

        #region WinAPI

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory",
            CallingConvention = CallingConvention.Winapi, SetLastError =true, CharSet = CharSet.Unicode)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory",
            CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess",
            CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll",CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        private static extern void CloseHandle(IntPtr hObject);

        #endregion

        private void ReInitialize()
        {
            _dataMap = new DataMap();
            _dataMap.AddFirst(new FileDataBlock(0, _stream.Length));
            _totalLength = _stream.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Close();
                _stream = null;
            }
            _dataMap = null;
            CloseHandle(handle);
        }

        private byte ReadByteFromImage(long fileOffset)
        {
            // Move to the correct position and read the byte.
            if (_stream.Position != fileOffset)
            {
                _stream.Position = fileOffset;
            }
            return (byte)_stream.ReadByte();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte ReadByte(long index)
        {
            DataBlock block = GetDataBlock(index, out long blockOffset);
            if (block is FileDataBlock fileBlock)
            {
                return ReadByteFromImage(fileBlock.FileOffset + index - blockOffset);
            }
            else
            {
                MemoryDataBlock memoryBlock = block as MemoryDataBlock;
                return memoryBlock.Data[index - blockOffset];
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
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
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bs"></param>
        [Obsolete("由于操作进程，暂不支持改变镜像大小", true)]
        public void InsertBytes(long index, byte[] bs)
        {
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        public void DeleteBytes(long index, long length)
        {
            for (int i = 0; i < length; i++)
            {
                WriteByte(index + i, 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasChanges()
        {
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
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public void ApplyChanges(Stream stream = null)
        {
            var mstream = stream ?? _stream;

            if (stream == null && _readOnly)
                throw new OperationCanceledException("Image is in read-only mode");

            int dataOffset = 0;
            IntPtr handle = Process.Handle;
            for (DataBlock block = _dataMap.FirstBlock; block != null; block = block.NextBlock)
            {
                if (block is MemoryDataBlock memoryBlock)
                {
                    mstream.Position = dataOffset;

                    for (int memoryOffset = 0; memoryOffset < memoryBlock.Length; memoryOffset += COPY_BLOCK_SIZE)
                    {
                        mstream.Write(memoryBlock.Data, memoryOffset, (int)Math.Min(COPY_BLOCK_SIZE, memoryBlock.Length - memoryOffset));
                    }

                    WriteProcessMemory(handle, BaseAddr + dataOffset, memoryBlock.Data, (int)memoryBlock.Length, IntPtr.Zero);
                }
                dataOffset += (int)block.Length;
            }

            if (stream == null)
                ReInitialize();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SupportsWriteByte()
        {
            return !_readOnly;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SupportsInsertBytes()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SupportsDeleteBytes()
        {
            return !_readOnly;
        }
    }
}
