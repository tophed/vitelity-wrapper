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

        public async Task<BasicResponse> GetLocalDID(string did)
        {
            var result = await _cmd.GetLocalDID(did);

            if (!result.Succeeded) return null;

            return _deserializer.DeserializeBasicResponse(result.Content);
        }

        public async Task<BasicResponse> GetTollFreeDID(string did)
        {
            var result = await _cmd.GetTollFree(did);

            if (!result.Succeeded) return null;

            return _deserializer.DeserializeBasicResponse(result.Content);
        }
    }
}
