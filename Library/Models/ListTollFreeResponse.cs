using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vitelity.Models
{
    [XmlRoot("content")]
    public class ListTollFreeResponse
    {
        public ListTollFreeResponse()
        {
            Numbers = new List<string>();
        }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("error")]
        public string Error { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlArray("numbers")]
        [XmlArrayItem("did")]
        public List<string> Numbers { get; set; }
    }
}
