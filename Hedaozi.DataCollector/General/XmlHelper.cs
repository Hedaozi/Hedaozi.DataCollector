using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Hedaozi.DataCollector.General
{
    internal static class XmlHelper
    {
        public static XmlDocument LoadXml(string path)
        {
            XmlDocument document = new XmlDocument();
            document.Load(path);
            return document;
        }
    }
}
