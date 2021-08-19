using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PEHexExplorer
{

    /// <summary>
    /// 由于本人网络知识欠缺，不想自费弄个服务器（如果该软件捐助达到一定程度我会考虑），
    /// 也不会搭网站，目前也没找到合适快速的固定下载链接方式，
    /// 看到蓝奏云比较合适，它的验证机制还是挺简单的，就是挺麻烦的，可以过验证，故采用此方式。
    /// 本方式不能保证一定会有效，得看蓝奏云运营商了
    /// 
    ///【虽然代码500来行，但这个类本人花费了大量的时间进行实现，请不得用于除学习和本软件更新之外的用途使用】
    /// </summary>
    class UpdateLib
    {
        private static UpdateLib updateLib;

        public static UpdateLib Instance
        {
            get
            {
                if (updateLib==null)
                {
                    updateLib = new UpdateLib();
                }
                return updateLib;
            }
        }

        private readonly string uri = "https://wws.lanzoui.com/b020fwpwh";
        private const string useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.131";
        private const string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
        private const string sec_ch_ua = "\"Chromium\";v=\"92\", \" Not A; Brand\";v=\"99\"";
        private const string cookie = "codelen=1; pc_ad1=1";
        private const string AcceptLanguage = "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6";
        private const string lanzou_header = "https://wws.lanzoui.com/";
        private const string AcceptEncoding = "gzip, deflate, br";
        public const int DefaultBufferSize = 1024;
        public readonly RequestCachePolicy cachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

#pragma warning disable IDE1006, CS0649 //禁用命名样式提示和未使用为null警告

        [DataContract]
        public class DownLoadLinkData
        {
            [DataMember]
            public int zt;

            [DataMember]
            public string dom;

            [DataMember]
            public string url;

            [DataMember]
            public int inf;
        }

        [DataContract]
        public class ResultJson
        {
            [DataMember]
            public int tz { get; set; }

            [DataMember]
            public string info { get; set; }

            [DataMember]
            public ResultCotent[] text { get; set; }
        }

        [DataContract]
        public struct ResultCotent
        {
            [DataMember]
            public string icon { get; set; }

            [DataMember]
            public int t { get; set; }

            [DataMember]
            public string id { get; set; }

            [DataMember]
            public string name_all { get; set; }

            [DataMember]
            public string size { get; set; }

            [DataMember]
            public string time { get; set; }

            [DataMember]
            public string duan { get; set; }

            [DataMember]
            public int p_ico { get; set; }

        }

        public class UpdateInfo
        {
            public string url;
            public float ver;
            public string size;
        }

#pragma warning restore IDE1006, CS0649

        private UpdateLib()
        {
        }

        private string RegexMatch(string pattern, string input, out int index, int start = 0)
        {
            Regex regex = new Regex(pattern);
            var match = regex.Match(input, start);
            if (match.Success)
            {
                index = match.Index;
                return match.Value;
            }
            index = -1;
            return null;
        }

        public HttpWebRequest HttpGet(string url, RequestCachePolicy cachePolicy, string refer = null)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);

            request.Method = "GET";
            request.UseDefaultCredentials = true;
            request.UserAgent = useragent;
            request.CachePolicy = cachePolicy;
            request.Timeout = 5000;
            request.Accept = accept;
            request.Headers.Add(HttpRequestHeader.Authorization, "wws.lanzoui.com");
            request.Headers.Add(HttpRequestHeader.Cookie, "down_ip=1");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, AcceptEncoding);
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, AcceptLanguage);
            request.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
            request.Headers.Add("dnt", "1");
            request.Headers.Add("sec-ch-ua", sec_ch_ua);
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "orign");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("sec-gpc", "1");
            request.Headers.Add("upgrade-insecure-requests", "1");

            if (refer != null)
                request.Referer = refer;

            return request;

        }

        public Stream HttpPost(string url, RequestCachePolicy cachePolicy, string submit, string refer = null)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(submit);
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = "POST";
            request.CachePolicy = cachePolicy;
            request.Accept = "application/json, text/javascript, */*";
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, AcceptEncoding);
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, AcceptLanguage);
            request.ContentLength = buffer.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add(HttpRequestHeader.Cookie, cookie);
            request.Headers.Add("dnt", "1");
            request.Headers.Add("origin", "https://wws.lanzoui.com");
            if (refer != null)
                request.Referer = refer;
            request.Headers.Add("sec-ch-ua", sec_ch_ua);
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-fetch-dest", "empty");
            request.Headers.Add("sec-fetch-mode", "cors");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("sec-gpc", "1");
            request.UserAgent = useragent;
            request.Headers.Add("x-requested-with", "XMLHttpRequest");
            try
            {
                using (var rstream = request.GetRequestStream())
                {
                    rstream.Write(buffer, 0, buffer.Length);
                }
                return request.GetResponse().GetResponseStream();
            }
            catch
            {
                return null;
            }
        }

        public string GetResponseCotent(HttpWebRequest request)
        {
            try
            {
                using (var res = request.GetResponse())
                {
                    using (var stream = res.GetResponseStream())
                    {
                        StreamReader streamReader;
                        using (streamReader = new StreamReader(new GZipStream(stream, CompressionMode.Decompress),
                            Encoding.UTF8, false, DefaultBufferSize, false))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void InfoNewest(Action<string> Log)
        {
            Log?.Invoke("当前为最新版本！！！");
            MessageBox.Show("您已经拥有最新版本的PEHexExplorer！！！", Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public UpdateInfo GetUpdateInfo(Action<string> Log = null)
        {
            string content = null;
            ResultJson result = null;
            string tmp = null;
            Stream stream = null;

            Log?.Invoke("正在初始化请求……");

            try
            {
                //第一步：访问页面，获取动态的t和k的值
                HttpWebRequest request = HttpGet(uri, cachePolicy);

                Log?.Invoke("正在请求服务器……");

                string t = null, k = null;

                content = GetResponseCotent(request);

                Log?.Invoke("开始解析服务器返回信息……");

                tmp = RegexMatch(@"'t'\s?:\s?\w+", content, out _);
                t = tmp.Substring(tmp.IndexOf(":") + 1);

                tmp = RegexMatch(@"'k'\s?:\s?\w+", content, out _);
                k = tmp.Substring(tmp.IndexOf(":") + 1);

                string tv = null, kv = null;

                if (t != null && k != null)
                {
                    tmp = RegexMatch($@"var\s?{t}\s?=\s?'\w+'", content, out _);
                    tv = tmp.Substring(tmp.IndexOf("\'")).Trim('\'');

                    tmp = RegexMatch($@"var\s?{k}\s?=\s?'\w+'", content, out _);
                    kv = tmp.Substring(tmp.IndexOf("\'")).Trim('\'');
                }

                //第二步：校验结果，若成功获取目录信息
                if (tv == null || kv == null)
                {
                    throw new InvalidDataException("tv|kv");
                }

                Log?.Invoke("正在获取版本信息……");

                using (stream = HttpPost("https://wws.lanzoui.com/filemoreajax.php", cachePolicy,
                    $"lx=2&fid=3868377&uid=1846046&pg=1&rep=0&t={tv}&k={kv}&up=1&ls=1&pwd=fw9s",
                    "https://wws.lanzoui.com/b020fwpwh"))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ResultJson));
                    result = jsonSerializer.ReadObject(stream) as ResultJson;
                }

                if (result == null)
                {
                    throw new NullReferenceException("result");
                }
                if (result.tz == 1)
                {
                    throw new InvalidDataException("result");
                }

                //第三步：若获取成功，解析正确的信息
                /*
                 * 发行版更新命名规则：Ver_[版本号].exe（例子：Ver_1.0.exe）
                 * 但如果以后发布与发行可执行程序包不相关的东西，不会符合下面的判断条件
                 * 版本号必为float类型，否则无效包（因为需要判断该程序的版本，为了简化操作）
                 */

                Log?.Invoke("获取更新中……");

                var items = result.text.Where(item =>
                {
                    if (item.id != "-1" && item.t != 1)
                    {
                        Regex regex = new Regex(@"^Ver_(\d+\.\d+).exe$", RegexOptions.IgnoreCase);
                        var match = regex.Match(item.name_all);
                        return match.Success;
                    }
                    return false;
                }).ToList();

                if (items.Count == 0)
                {
                    InfoNewest(Log);
                    return null;
                }

                float newestVer = 0;
                string url = null;
                string size = null;

                foreach (var item in items)
                {
                    string value = RegexMatch(@"\d+\.\d+", item.name_all, out _);
                    float v = float.Parse(value);
                    if (v > newestVer)
                    {
                        newestVer = v;
                        url = item.id;
                        size = item.size;
                    }

                }

                Log?.Invoke($"获取最新版本成功，版本号为{newestVer}");

                if (newestVer == Program.Version)
                {
                    InfoNewest(Log);
                    return null;
                }

                if (newestVer < Program.Version)
                {
                    Log?.Invoke("当前版本号异常！！！");
                    MessageBox.Show("您的程序版本号异常，建议从官方进行下载！！！", Program.AppName,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                return new UpdateInfo { url = url, ver = newestVer, size = size };
            }

            catch (Exception ex)
            {
                Log?.Invoke(ex.Message);
                MessageBox.Show($"{ex.InnerException.Message}。故升级失败！", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public string GetUpdateURL(Action<string> Log = null)
        {
            string content = null;
            string tmp = null;
            Stream stream = null;
            DownLoadLinkData linkData = null;
            UpdateInfo updateInfo = GetUpdateInfo();
            var url = updateInfo.url;

            try
            {

                //第四步：访问下载界面

                Log?.Invoke("正在请求更新……");

                HttpWebRequest request = HttpGet(lanzou_header + url, cachePolicy, url);

                using (var res = request.GetResponse())
                {
                    using (stream = res.GetResponseStream())
                    {
                        StreamReader streamReader;

                        using (streamReader = new StreamReader(new GZipStream(stream, CompressionMode.Decompress),
                            Encoding.UTF8, false, DefaultBufferSize, false))
                        {
                            content = streamReader.ReadToEnd();

                            RegexMatch(@"e\>\-\-\>", content, out int start);
                            content = RegexMatch(@"<iframe.+?>", content, out _, start);

                            tmp = RegexMatch("src=\".+?\"", content, out _);
                            content = url;
                            url = tmp.Substring(6).Trim('\"');

                        }
                    }
                }

                //第五步：获取下载链接
                Log?.Invoke("正在获取下载链接……");

                request = HttpGet(lanzou_header + url, cachePolicy, lanzou_header + content);
                using (var res = request.GetResponse())
                {
                    using (stream = res.GetResponseStream())
                    {
                        StreamReader streamReader = new StreamReader(new GZipStream(stream, CompressionMode.Decompress),
                            Encoding.UTF8, false, DefaultBufferSize, false);
                        content = streamReader.ReadToEnd();
                    }
                }
                var tem = content;

                content = RegexMatch(@"(\s)data\s?:\s?{.+}", content, out _);
                string signs = null, sign = null;

                tmp = RegexMatch(@"'signs'\s?:\s?\w+", content, out _);
                signs = tmp.Substring(tmp.IndexOf(":") + 1).Trim();

                tmp = RegexMatch(@"'sign'\s?:\s?\w+", content, out _);
                sign = tmp.Substring(tmp.IndexOf(":") + 1).Trim();

                string signsv = null, signv = null;

                tmp = RegexMatch($@"var\s?{signs}\s?=\s?'\S+'", tem, out _);
                signsv = tmp.Substring(tmp.IndexOf("\'")).Trim('\'');

                tmp = RegexMatch($@"var\s?{sign}\s?=\s?'\S+'", tem, out _);
                signv = tmp.Substring(tmp.IndexOf("\'")).Trim('\'');

                tmp = $"action=downprocess&signs={signsv}&sign={signv}&ves=1&websign=2&websignkey=BSBU";

                Log?.Invoke("获取下载链接成功，即将开始下载……");

                using (stream = HttpPost("https://wws.lanzoui.com/ajaxm.php", cachePolicy, tmp, lanzou_header + url))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DownLoadLinkData));
                    linkData = jsonSerializer.ReadObject(stream) as DownLoadLinkData;
                }

                url = $"{linkData.dom}/file/{linkData.url}";
                return url;
            }
            catch (Exception ex)
            {
                Log?.Invoke(ex.Message);
                MessageBox.Show($"{ex.InnerException.Message}。故升级失败！", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void UpdateProgramNewest(Action<string> Log = null, Action<long, long> UpdateProgressBarValue = null)
        {
            var dlink = GetUpdateURL();
            if (dlink != null)
            {
                Directory.CreateDirectory(Program.AppUpDate);
                HttpWebRequest request = WebRequest.CreateHttp(dlink);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "GET";
                request.UserAgent = useragent;
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, AcceptLanguage);
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, AcceptEncoding);
                request.Accept = accept;
                request.KeepAlive = true;
                request.Host = "vip.d0.baidupan.com";
                request.Headers.Add(HttpRequestHeader.Cookie, "down_ip=1");
                request.Headers.Add("dnt", "1");
                request.Headers.Add("sec-ch-ua", sec_ch_ua);
                request.Headers.Add("sec-ch-ua-mobile", "?0");
                request.Headers.Add("sec-fetch-dest", "document");
                request.Headers.Add("sec-fetch-mode", "cors");
                request.Headers.Add("sec-fetch-site", "cross-origin");
                request.Headers.Add("sec-fetch-user", "?1");
                request.Headers.Add("sec-gpc", "1");
                request.Headers.Add("upgrade-insecure-requests", "1");
                request.AllowAutoRedirect = true;

                Log?.Invoke("开始下载中……");

                using (var res = request.GetResponse())
                {
                    var total = res.ContentLength;
                    using (var stream = res.GetResponseStream())
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            using (var fs = File.Create(Program.AppUpDateBin))
                            {
                                byte[] buffer;
                                using (BinaryWriter writer = new BinaryWriter(fs))
                                {
                                    while ((buffer = reader.ReadBytes(DefaultBufferSize)).Length > 0)
                                    {
                                        writer.Write(buffer);
                                        UpdateProgressBarValue?.Invoke(fs.Length, total);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

    }
}
