using System;
using WSPEHexPluginHost;

namespace PEHexExplorer
{
    internal partial class WSPlugin
    {
        internal static class PluginSupportLib
        {
            public static WSPlugin pluginManager = null;
            public static void PluginSupport(MessageType messageType, Action action)
            {
                HostPluginArgs args = new HostPluginArgs { MessageType = messageType, IsBefore = true };
                bool isvalid = pluginManager != null && pluginManager.MSGQueue.Value.ContainsKey(messageType);

                if (isvalid)
                {
                    foreach (var item in pluginManager.MSGQueue.Value[messageType])
                    {
                        item.Invoke(null, args);

                        if (args.Cancel)
                            return;
                    }
                }

                action.Invoke();

                if (isvalid)
                {
                    args.IsBefore = false;
                    foreach (var item in pluginManager.MSGQueue.Value[messageType])
                        item.Invoke(null, args);
                }

            }
        }

    }

}