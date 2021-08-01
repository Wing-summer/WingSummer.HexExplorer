using System;
using System.IO;

namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        /// <summary>
        /// Opens a file.
        /// </summary>
        /// <param name="fileName">the file name of the file to open，为null为新建一个流</param>
        /// <param name="writeable">是否可写权限</param>
        public bool OpenFile(string fileName = null, bool writeable = true)
        {
            DynamicFileByteProvider dynamicFileByteProvider;
            if (fileName == null)
            {
                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(new MemoryStream());
                    ByteProvider = dynamicFileByteProvider;
                    Filename = string.Empty;
                    IsOpenedFile = true;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            if (!File.Exists(fileName))
                return false;
            CloseFile(false);
            try
            {
                try
                {
                    dynamicFileByteProvider = new DynamicFileByteProvider(fileName, !writeable);
                }
                catch (IOException)
                {
                    return false;
                }
                ByteProvider = dynamicFileByteProvider;
                Filename = fileName;
            }
            catch (Exception)
            {
                return false;
            }
            IsOpenedFile = true;
            return true;
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filename">如果此参数为空，则为保存，否则为导出或另存为</param>
        /// <param name="isExport">如果为导出，则值为True</param>
        /// <returns>成功为True，反之为False</returns>
        public bool SaveFile(string filename = null, bool isExport = true)
        {
            if (_byteProvider == null)
                return false;
            try
            {
                if (filename == null)
                {
                    if (Filename == string.Empty)
                    {
                        return false;
                    }
                    _byteProvider.ApplyChanges(null);
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
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭并默认保存文件
        /// </summary>
        /// <param name="IsSave">如果该参数为False，则丢弃更改</param>
        /// <returns></returns>
        public bool CloseFile(bool IsSave = true)
        {
            if (_byteProvider == null)
                return false;

            try

            {
                if (IsSave && _byteProvider != null && _byteProvider.HasChanges())
                {
                    SaveFile();
                }
                CleanUp();
            }
            catch
            {
                return false;
            }
            IsOpenedFile = false;
            return true;
        }

        private void CleanUp()
        {
            if (_byteProvider != null)
            {
                IDisposable byteProvider = _byteProvider as IDisposable;
                if (byteProvider != null)
                    byteProvider.Dispose();
                ByteProvider = null;
            }
            Filename = null;
        }
    }
}