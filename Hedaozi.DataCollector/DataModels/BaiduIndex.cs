using System;
using System.Collections.Generic;
using System.Text;

namespace Hedaozi.DataCollector.DataModels
{
    public partial class BaiduIndex
    {
        private List<string> keywords = new List<string>();
        private List<int> area = new List<int>();
        private string startDate = null;
        private string endDate = null;
        private string cookies = null;

        public BaiduIndex()
        {

        }
    }

    public partial class BaiduIndex
    {
        public enum IndexType { Search, News, Feed }

        public enum PlotformType { All, PC, Wise }

        public enum AreaType { All, Province, Prefectures }

        public class Area
        {
            public string BdIndexCode { get; set; }
            public string Name { get; set; }
            public string FullName { get; set; }
            public string NbscCode { get; set; }
            public AreaType Type { get; set; }
            public string Belong { get; set; }
            public bool Deprecated { get; set; }
        }

        public static class Areas
        {
            static System.Xml.XmlDocument areasTree;

            static Areas()
            {
                Uri codeFilePath = new Uri("Codebook/BdIndexCode.xml");
                areasTree = General.XmlHelper.LoadXml(codeFilePath);
            }

            public static List<Area> FindAreas(string filter)
            {
                return new List<Area>();
            }

            public static string QueryFilter(AreaType type = AreaType.All, string belong = null)
            {

                return "";
            }
        }
    }
}
