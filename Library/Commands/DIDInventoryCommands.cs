using System.Net.Http;
using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public class DIDInventoryCommands : IDIDInventoryCommands
    {
        HttpClient _http;
        CommandUrlBuilder _urlBuilder;

        public DIDInventoryCommands(HttpClient http, CommandUrlBuilder urlBuilder)
        {
            _http = http;
            _urlBuilder = urlBuilder;
        }

        public async Task<CommandResult> ListNpa(string npa)
        {
            var response = await _http.GetAsync(_urlBuilder.ListNpa(npa));
            return new CommandResult
            {
                Succeeded = response.IsSuccessStatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task<CommandResult> ListTollFree()
        {
            var response = await _http.GetAsync(_urlBuilder.ListTollFree());
            return new CommandResult
            {
                Succeeded = response.IsSuccessStatusCode,
                Content = await response.Content.ReadAsStringAsync()
            };
        }
    }
}