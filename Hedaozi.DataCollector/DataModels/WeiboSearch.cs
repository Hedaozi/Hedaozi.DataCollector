using System;
using System.Collections.Generic;
using System.IO;

namespace Hedaozi.DataCollector.DataModels
{
    public partial class WeiboSearch
    {
        private CookiesRecord cookiesRecord = null;

        private string cookiesFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Hedaozi", "DataCollector"
        );
        private string cookiesPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Hedaozi", "DataCollector", "WeiboSearch.yaml"
        );

        public CookiesRecord CookiesRecord { get { return cookiesRecord; } }

        public void LoadCookies()
        {
            if (!Directory.Exists(cookiesFolder)) Directory.CreateDirectory(cookiesFolder);

            cookiesRecord = File.Exists(cookiesPath) ?
                CookiesRecord.FromYaml(cookiesPath) :
                CookiesRecord.New();
        }


    }

    public partial class WeiboSearch
    {
        public class Query
        {
            private static string urlTemplate = "https://s.weibo.com/weibo?q={0}&{1}&{2}&timescope=custom:{3}:{4}&Refer=g";

            private static Dictionary<string, string> QueryTypes = new Dictionary<string, string>
            {
                { "全部", "typeall=1" },
                { "热门", "xsort=hot" },
                { "原创", "scope=ori" },
                { "关注人", "atten=1" },
                { "认证用户", "vip=1" },
                { "媒体", "category=4" },
                { "观点", "viewpoint=1" }
            };

            private static Dictionary<string, string> QueryContent = new Dictionary<string, string>
            {
                { "全部", "suball=1" },
                { "含图片", "haspic=1" },
                { "含视频", "hasvideo=1" },
                { "含音乐", "hasmusic=1" },
                { "含短链", "haslink=1" }
            };

            private string type = "全部";
            private string content = "全部";
            private int startTime = -1;
            private int endTime = -1;

            public string Keyword { get; set; }
            public string Type { get { return type; } set { type = value; } }
            public string Content { get { return content; } set { content = value; } }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int StartTime { get { return startTime; } set { startTime = value; } }
            public int EndTime { get { return endTime; } set { endTime = value; } }

            public string ToUrl()
            {
                return string.Format(
                    urlTemplate, Keyword, QueryTypes[Type], QueryContent[Content],
                    StartDate.ToString("yyyy-MM-dd") + (StartTime == -1 ? "" : ("-" + StartTime.ToString())),
                    EndDate.ToString("yyyy-MM-dd") + (EndTime == -1 ? "" : ("-" + EndTime.ToString()))
                );
            }
        }

        public class Result
        {
            public string Mid { get; set; }

        }
    }
}
