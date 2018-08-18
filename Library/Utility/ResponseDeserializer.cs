using System;
using System.IO;
using System.Xml.Serialization;
using Vitelity.Models;

namespace Vitelity.Utility
{
    public class ResponseDeserializer
    {
        public BasicResponse DeserializeBasicResponse(string response)
        {
            var rdr = new StringReader(response);
            var _serializer = new XmlSerializer(typeof(BasicResponse));
            return (BasicResponse)_serializer.Deserialize(rdr);
        }

        public ListNpaResponse DeserializeListNpaResponse(string response)
        {
            var rdr = new StringReader(response);
            var _serializer = new XmlSerializer(typeof(ListNpaResponse));
            return (ListNpaResponse)_serializer.Deserialize(rdr);
        }

        public ListTollFreeResponse DeserializeListTollFreeResponse(string response)
        {
            var rdr = new StringReader(response);
            var _serializer = new XmlSerializer(typeof(ListTollFreeResponse));
            return (ListTollFreeResponse)_serializer.Deserialize(rdr);
        }
    }
}