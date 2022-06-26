using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Collections;
using System.Reflection;

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

        public enum AreaType { All, Province, Prefecture }

        public class Area
        {
            public string BdIndexCode { get; set; }
            public string Name { get; set; }
            public string FullName { get; set; }
            public string NbscCode { get; set; }
            public string Type { get; set; }
            public string Belong { get; set; }
            public string Deprecated { get; set; }

            public Area(XmlNode node)
            {
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    PropertyInfo property = GetType().GetProperty(attribute.Name);
                    property.SetValue(this, attribute.Value);
                }
            }
        }

        public static class Areas
        {
            static XmlDocument areasTree;

            static Areas()
            {
                string codeFilePath = "Codebook/BdIndexCode.xml";
                areasTree = General.XmlHelper.LoadXml(codeFilePath);
            }

            public static List<Area> FindAreas(AreaType type = AreaType.All, List<string> belong = null)
            {
                XmlNodeList nodes = areasTree.SelectNodes("Areas/Area");
                IEnumerable<XmlNode> selection = from XmlNode node in nodes select node;

                if (type != AreaType.All)
                {
                    selection = from node in selection
                                where node.Attributes["Type"].Value == type.ToString()
                                select node;
                }

                if (belong != null)
                {
                    selection = from XmlNode node in selection
                                where belong.Contains(node.Attributes["Belong"].Value)
                                select node;
                }

                return new List<Area>(from XmlNode node in selection select new Area(node));
            }
        }
    }
}
