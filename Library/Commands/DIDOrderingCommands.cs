using System.Net.Http;
using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public class DIDOrderingCommands : IDIDOrderingCommands
    {
        HttpClient _http;
        CommandUrlBuilder _urlBuilder;
        public DIDOrderingCommands(HttpClient http, CommandUrlBuilder urlBuilder)
        {
            _http = http;
            _urlBuilder = urlBuilder;
        }

        public async Task<CommandResult> GetLocalDID(string did, string routesip = null)
        {
            var response = await _http.GetAsync(_urlBuilder.GetLocalDID(did, routesip));
            return new CommandResult
            {
                Succeeded = response.IsSuccessStatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task<CommandResult> GetTollFree(string did, string routesip = null)
        {
            var response = await _http.GetAsync(_urlBuilder.GetTollFree(did, routesip));
            return new CommandResult
            {
                Succeeded = response.IsSuccessStatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }
    }
}