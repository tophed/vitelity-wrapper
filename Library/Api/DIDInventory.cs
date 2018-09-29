using System;
using System.IO;
using System.Threading.Tasks;
using Vitelity.Commands;
using Vitelity.Models;
using Vitelity.Utility;

namespace Vitelity.Api
{
    public class DIDInventory : IDIDInventory
    {
        IDIDInventoryCommands _cmd;
        ResponseDeserializer _deserializer;

        public DIDInventory(IDIDInventoryCommands cmd, ResponseDeserializer deserializer)
        {
            _cmd = cmd;
            _deserializer = deserializer;
        }

        public async Task<ListTollFreeResponse> ListTollFreeNumbers()
        {
            var result = await _cmd.ListTollFree();

            if (!result.Succeeded) return null;

            return _deserializer.DeserializeListTollFreeResponse(result.Content);
        }

        public async Task<ListNpaResponse> ListNpa(string npa)
        {
            var result = await _cmd.ListNpa(npa);

            if (!result.Succeeded) return null;

            return _deserializer.DeserializeListNpaResponse(result.Content);
        }
    }
}
