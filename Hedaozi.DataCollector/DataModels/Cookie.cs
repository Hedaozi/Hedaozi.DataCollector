using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Hedaozi.DataCollector.DataModels
{
    public class CookiesRecord
    {
        private Dictionary<string, string> cookies = null;
        private DateTime recordTime = new DateTime(0);

        public Dictionary<string, string> Cookies { get { return cookies; } }
        public DateTime RecordTime { get { return recordTime; } }

        public bool LongTime() => DateTime.Now - recordTime > TimeSpan.FromDays(1);

        public void SetCookies(Dictionary<string, string> cookies)
        {
            this.cookies = cookies;
            recordTime = DateTime.Now;
        }

        public void AddCookie(string name, string value) => cookies[name] = value;

        public void SetTime() => recordTime = DateTime.Now;

        public static CookiesRecord New()
        {
            CookiesRecord cookiesRecord = new CookiesRecord();
            cookiesRecord.cookies = new Dictionary<string, string>();
            cookiesRecord.SetTime();
            return cookiesRecord;
        }

        public static CookiesRecord FromYaml(string filepath)
        {
            using (TextReader reader = File.OpenText(filepath))
            {
                return new DeserializerBuilder()
                    .WithNamingConvention(PascalCaseNamingConvention.Instance)
                    .Build()
                    .Deserialize<CookiesRecord>(reader.ReadToEnd());
            }
        }

        public void ToYaml(string filepath)
        {
            using (TextWriter writer = File.CreateText(filepath))
            {
                var yaml = new SerializerBuilder()
                    .WithNamingConvention(PascalCaseNamingConvention.Instance)
                    .Build()
                    .Serialize(this);
                writer.Write(yaml);
            }
        }
    }
}
