using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vitelity.Models
{
    [XmlRoot("content")]
    public class ListNpaResponse : BasicResponse
    {
        public ListNpaResponse()
        {
            Numbers = new List<DidInfo>();
        }

        [XmlArray("numbers")]
        [XmlArrayItem("did")]
        public List<DidInfo> Numbers { get; set; }
    }
}
