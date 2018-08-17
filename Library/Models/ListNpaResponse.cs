using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vitelity.Models
{
    [XmlRoot("content")]
    public class ListNpaResponse
    {
        public ListNpaResponse()
        {
            Numbers = new List<DidInfo>();
        }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("error")]
        public string Error { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlArray("numbers")]
        [XmlArrayItem("did")]
        public List<DidInfo> Numbers { get; set; }
    }
}
