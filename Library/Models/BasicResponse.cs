using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vitelity.Models
{
    [XmlRoot("content")]
    public class BasicResponse
    {
        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("error")]
        public string Error { get; set; }
    }
}
