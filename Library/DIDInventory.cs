using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Vitelity.Commands;
using Vitelity.Models;

namespace Vitelity
{
    public class DIDInventory
    {
        IDIDInventoryCommands _cmd;

        public DIDInventory(IDIDInventoryCommands cmd)
        {
            _cmd = cmd;
        }

        public async Task<ListTollFreeResponse> ListTollFreeNumbers()
        {
            var response = await _cmd.ListTollFree();
            var rdr = new StringReader(response);
            var _serializer = new XmlSerializer(typeof(ListTollFreeResponse));
            return (ListTollFreeResponse)_serializer.Deserialize(rdr);
        }

        public async Task<ListNpaResponse> ListNpa(string areaCode)
        {
            var response = await _cmd.ListNpa(areaCode);
            var rdr = new StringReader(response);
            var _serializer = new XmlSerializer(typeof(ListTollFreeResponse));
            return (ListNpaResponse)_serializer.Deserialize(rdr);
        }
    }
}
