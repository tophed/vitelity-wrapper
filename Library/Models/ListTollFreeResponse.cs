using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vitelity.Models
{
    [XmlRoot("content")]
    public class ListTollFreeResponse : BasicResponse
    {
        public ListTollFreeResponse()
        {
            Numbers = new List<string>();
        }

        [XmlArray("numbers")]
        [XmlArrayItem("did")]
        public List<string> Numbers { get; set; }
    }
}
