using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Vitelity.Models
{
    public class DidInfo
    {
        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("ratecenter")]
        public string RateCenter { get; set; }

        [XmlElement("state")]
        public string State { get; set; }
    }
}
