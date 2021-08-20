using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// 打开或关闭文件或缓冲区引发的错误枚举
        /// </summary>
        public enum IOError
        {
            /// <summary>
            /// 成功完成操作
            /// </summary>
            Success,
            /// <summary>
            /// 已打开缓冲区异常，发生在OpenFile函数中
            /// </summary>
            HasOpenedBuffer,
            /// <summary>
            /// 已打开缓冲区异常，发生在CreateBuffer函数中
            /// </summary>
            HasOpenedFile,
            /// <summary>
            ///  文件不存在异常，发生在OpenFile函数中
            /// </summary>
            FileNotExist,
            /// <summary>
            /// .Net的Exception类型异常
            /// </summary>
            Exception,
            /// <summary>
            /// 对象或其内容为空异常
            /// </summary>
            NullObject
        }

        /// <summary>
        /// 读取int
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public int? Readint(long Pos)
        {
            if (Pos < 0 || Pos + sizeof(int) > _byteProvider.Length)
            {
                return null;
            }
            byte[] buffer = new byte[sizeof(int)];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = _byteProvider.ReadByte(Pos + i);
            }

            return BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>
        /// 读取short
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public short? Readshort(long Pos)
        {
            if (Pos < 0 || Pos + sizeof(short) > _byteProvider.Length)
            {
                return null;
            }
            byte[] buffer = new byte[sizeof(short)];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = _byteProvider.ReadByte(Pos + i);
            }

            return BitConverter.ToInt16(buffer, 0);
        }

        /// <summary>
        /// 读取long
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public long? Readlong(long Pos)
        {
            if (Pos < 0 || Pos + sizeof(long) > _byteProvider.Length)
            {
                return null;
            }
            byte[] buffer = new byte[sizeof(long)];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = _byteProvider.ReadByte(Pos + i);
            }

            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 读取指定类型接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public T Read<T>(long Pos) where T : new()
        {
            if (Pos<0)
            {
                return default;
            }
            int len = Marshal.SizeOf(typeof(T));
            IntPtr ptr = Marshal.AllocHGlobal(len);
            for (int i = 0; i < len; i++)
            {
                Marshal.WriteByte(ptr + i, _byteProvider.ReadByte(Pos));
            }
            T content=new T();
            Marshal.PtrToStructure(ptr, content);
            Marshal.FreeHGlobal(ptr);
            return content;
        }

        /// <summary>
        /// Opens a file.
        /// </summary>
        /// <param name="fileName">the file name of the file to open，为null为新建一个流</param>
        /// <param name="writeable">是否可写权限</param>
        /// <param name="force">是否强制打开文件（如果打开缓冲区则强制关闭）</param>
        /// <param name="error">输出错误记录</param>
        public bool OpenFile(out IOError error, string fileName = null, bool writeable = true, bool force = false)
        {
            if (_isOpenedBuffer)
            {
                if (force)
                {
                    Close();
                }
                else
                {
                    error = IOError.HasOpenedBuffer;
                    return false;
                }
            }

            DynamicFileByteProvider dynamicFileByteProvider;
            if (fileName == null)
            {
                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(new MemoryStream());
                    ByteProvider = dynamicFileByteProvider;
                    Filename = string.Empty;
                    _isOpenedFile = true;
                    error = IOError.Success;
                    _insertActive = true;
                    _isLockedBuffer = false;
                    return true;
                }
                catch (Exception)
                {
                    error = IOError.Exception;
                    return false;
                }
            }
            if (!File.Exists(fileName))
            {
                error = IOError.FileNotExist;
                return false;
            }
            Close();
            try
            {
                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(fileName, !writeable);
                }
                catch (IOException)
                {
                    error = IOError.Exception;
                    return false;
                }
                ByteProvider = dynamicFileByteProvider;
                Filename = fileName;
            }
            catch (Exception)
            {
                error = IOError.Exception;
                return false;
            }
            _isOpenedFile = true;
            _readOnly = !writeable;
            error = IOError.Success;
            _isLockedBuffer = true;
            _insertActive = false;
            _isOpenImage = false;
            return true;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="error">输出错误记录</param>
        /// <param name="filename">如果此参数为空，则为保存，否则为导出或另存为</param>
        /// <param name="isExport">如果为导出，则值为True</param>
        /// <returns>成功为True，反之为False</returns>
        public bool SaveFile(out IOError error , string filename = null, bool isExport = true)
        {
            if (_isOpenedBuffer)
            {
                error = IOError.HasOpenedBuffer;
                return false;
            }
            if (_byteProvider == null)
            {
                error = IOError.NullObject;
                return false;
            }
            try
            {
                if (filename == null)
                {
                    if (Filename == string.Empty)
                    {
                        error = IOError.NullObject;
                        return false;
                    }
                    _byteProvider.ApplyChanges(null);
                    SavedStatusChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    if (isExport)
                    {
                        using (FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Stream stream = (_byteProvider as DynamicFileByteProvider).Stream;
                            stream.Position = 0;
                            stream.CopyTo(fileStream);
                            _byteProvider.ApplyChanges(fileStream);
                            fileStream.Flush();
                            fileStream.Close();
                        }
                    }
                    else
                    {
                        FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Read);
                        _byteProvider.ApplyChanges(fileStream);
                        (_byteProvider as DynamicFileByteProvider).ChangeStream(ref fileStream);
                    }
                }
            }
            catch (Exception)
            {
                error = IOError.Exception;
                return false;
            }
            error = IOError.Success;
            return true;
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            if (_byteProvider == null)
                return false;
            try
            {
                CleanUp();
            }
            catch
            {
                return false;
            }
            _isOpenedFile = false;
            _isOpenedBuffer = false;
            return true;
        }

        /// <summary>
        /// 创建一个可供编写的缓冲区，建议不要用于编写文件
        /// </summary>
        /// <returns></returns>
        public bool CreateBuffer(bool force = false, long limit = 0)
        {
            if (!force && _isOpenedFile)
            {
                return false;
            }
            DynamicByteProvider dynamicByteProvider;
            try
            {
                Close();
                dynamicByteProvider = new DynamicByteProvider(new byte[0]);
                if (limit>0)
                {
                    dynamicByteProvider.Limit = limit;
                }
                ByteProvider = dynamicByteProvider;
                Filename = string.Empty;
                _isOpenedFile = false;
                _isOpenedBuffer = true;
                _insertActive = true;
                _isLockedBuffer = false;
                _isOpenImage = false;
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="writeable"></param>
        /// <returns></returns>
        public bool OpenProcessMemory(Process process,bool writeable=false)
        {
            ProcessByteProvider processByteProvider;
            try
            {
                processByteProvider = new ProcessByteProvider(process, writeable);
                BaseAddr = processByteProvider.BaseAddr.ToInt64();
                ByteProvider = processByteProvider;
                Filename = process.MainModule.FileName;
                _isLockedBuffer = true;
                _insertActive = false;
                _isOpenImage = true;
            }
            catch 
            {
                return false;
            }
            return true;
        }

        private void CleanUp()
        {
            if (_byteProvider != null)
            {
                if (_byteProvider is IDisposable byteProvider)
                    byteProvider.Dispose();
                ByteProvider = null;
            }
            Filename = null;
        }

    }
}