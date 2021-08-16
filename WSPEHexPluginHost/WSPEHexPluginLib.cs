using System.Security.Cryptography;
using System.Text;

namespace WSPEHexPluginHost
{
    public static class WSPEHexPluginLib
    {
        public const string Sig = "WingSummer";

        /// <summary>
        /// 获取Puid（Plugin Unique Identifier）
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        public static string GetPuid(IWSPEHexPlugin plugin)
        {
            string tmp = $"{Sig}{plugin.PluginName}{plugin.Author}{plugin.Comment}{plugin.Version}";
            byte[] buffer = Encoding.ASCII.GetBytes(tmp);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(buffer);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in res)
            {
                stringBuilder.Append(item.ToString("X"));
            }
            return stringBuilder.ToString();
        }

        public static string GetPuid(string PluginName,string Author,string Comment, ushort Version)
        {
            string tmp = $"{Sig}{PluginName}{Author}{Comment}{Version}";
            byte[] buffer = Encoding.ASCII.GetBytes(tmp);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(buffer);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in res)
            {
                stringBuilder.Append(item.ToString("X"));
            }
            return stringBuilder.ToString();
        }

    }

}
