using System;
using System.Threading;
using System.Windows.Forms;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace PEHexExplorer
{
    /// <summary>
    /// 参考： https://github.com/novotnyllc/SingleInstanceHelper 
    /// 作用：实现单例模式
    /// 作者：wingsummer
    /// 说明：本类（SingleInstanceHelper）的代码遵守MIT协议
    /// </summary>
    class SingleInstanceHelper
    {
        public class SingleInstanceArgs : EventArgs
        {
            public string[] args;
        }

        private static SingleInstanceHelper instanceHelper;
        private readonly Mutex mutex;
        private readonly bool firstStartUp;
        private Form formMain;
        private static Assembly currentAssembly;
        private static string appName;
        public static event EventHandler<SingleInstanceArgs> StartUpNextInstance;
        public Form FormMain => formMain;

        public static SingleInstanceHelper SingleInstance
        {
            get
            {
                if (instanceHelper == null)
                {
                    instanceHelper = new SingleInstanceHelper();
                    currentAssembly = Assembly.GetExecutingAssembly();
                    appName = currentAssembly.FullName;
                    CreatePipe();
                }
                return instanceHelper;
            }
        }

        public Mutex Mutex => mutex;
        public bool IsSingleApp { get; set; }
        public bool IsFirstStartUp => firstStartUp && IsSingleApp;
        public string AppName => appName;
        public Assembly CurrentAssembly => currentAssembly;

        private static NamedPipeServerStream pipeServerStream;

        private SingleInstanceHelper()
        {
            lock (mutex = new Mutex(true, Assembly.GetExecutingAssembly().FullName, out bool isnew))
            {
                firstStartUp = isnew;
            }
        }

        ~SingleInstanceHelper()
        {
            mutex?.Dispose();
            pipeServerStream?.Dispose();
        }

        private static void CreatePipe()
        {
            try
            {
                pipeServerStream = new NamedPipeServerStream(appName, PipeDirection.In, 1,
                    PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
                pipeServerStream.BeginWaitForConnection(NamedPipeServerConnectionCallback, pipeServerStream);
            }
            catch
            {
            }
        }

        private static void NamedPipeServerConnectionCallback(IAsyncResult iAsyncResult)
        {
            try
            {
                pipeServerStream.EndWaitForConnection(iAsyncResult);

                BinaryFormatter formatter = new BinaryFormatter();
                string[] args = (string[])formatter.Deserialize(pipeServerStream);
                StartUpNextInstance?.Invoke(null, new SingleInstanceArgs { args = args });

            }
            catch (ObjectDisposedException)
            {
                // EndWaitForConnection will exception when someone calls closes the pipe before connection made
                // In that case we dont create any more pipes and just return
                // This will happen when app is closing and our pipe is closed/disposed
                return;
            }
            catch
            {
            }
            finally
            {
                pipeServerStream.Dispose();
            }

            // Create a new pipe for next connection
            CreatePipe();
        }

        public void Run(Type formType, string[] args = null, bool ctorhasParam = false, object param = null)
        {
            if (!formType.IsSubclassOf(typeof(Form)))
            {
                throw new InvalidCastException("Invalid Form Class");
            }

            if (!IsSingleApp || (IsSingleApp && firstStartUp))
            {
                if (ctorhasParam)
                {
                    Application.Run(formMain = Activator.CreateInstance(formType, param) as Form);
                }
                else
                {
                    Application.Run(formMain = Activator.CreateInstance(formType) as Form);
                }
            }
            else
            {
                try
                {
                    using (var namedPipeClientStream = new NamedPipeClientStream(".", appName, PipeDirection.Out))
                    {
                        namedPipeClientStream.Connect(3000); // Maximum wait 3 seconds
                        var ser = new BinaryFormatter();
                        ser.Serialize(namedPipeClientStream, args);
                    }
                }
                catch
                {
                }

            }
        }

    }
}
