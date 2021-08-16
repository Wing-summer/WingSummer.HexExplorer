using System;

namespace WSPEHexPluginHost
{
    public class HostPluginArgs : EventArgs
    {
        public MessageType MessageType;
        public bool Cancel;
        public bool IsBefore;
        public object Content;

        public override string ToString()
        {
            return MessageType.ToString();
        }
    }

}
