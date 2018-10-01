using System;
using System.IO;
using System.Threading.Tasks;
using Vitelity.Commands;
using Vitelity.Models;
using Vitelity.Utility;

namespace Vitelity.Api
{
    public class DIDOrdering : IDIDOrdering
    {
        IDIDOrderingCommands _cmd;
        ResponseDeserializer _deserializer;

        public DIDOrdering(IDIDOrderingCommands cmd, ResponseDeserializer deserializer)
        {
            _cmd = cmd;
            _deserializer = deserializer;
        }

        public async Task<BasicResponse> GetLocalDID(string did, string routesip = null)
        {
            var result = await _cmd.GetLocalDID(did, routesip);

            if (!result.Succeeded) return null;

            return _deserializer.DeserializeBasicResponse(result.Content);
        }

        public async Task<BasicResponse> GetTollFreeDID(string did, string routesip = null)
        {
            var result = await _cmd.GetTollFree(did, routesip);

            if (!result.Succeeded) return null;

            return _deserializer.DeserializeBasicResponse(result.Content);
        }
    }
}
