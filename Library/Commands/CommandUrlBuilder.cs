namespace Vitelity.Commands
{
    public class CommandUrlBuilder
    {
        string _baseUrl;

        public CommandUrlBuilder(Credentials creds)
        {
            _baseUrl = $"https://api.vitelity.net/api.php?login={creds.Username}&pass={creds.Password}&xml=yes";
        }

        public string ListNpa(string npa)
        {
            return $"{_baseUrl}&cmd=listnpa&npa={npa}";
        }

        public string ListTollFree()
        {
            return $"{_baseUrl}&cmd=listtollfree";
        }

        public string GetLocalDID(string did, string routesip = null)
        {
            var url = $"{_baseUrl}&cmd=getlocaldid&did={did}";

            if (routesip != null)
            {
                url += $"&routesip={routesip}";
            }

            return url;
        }

        public string GetTollFree(string did, string routesip = null)
        {
            var url = $"{_baseUrl}&cmd=gettollfree&did={did}";

            if (routesip != null)
            {
                url += $"&routesip={routesip}";
            }

            return url;
        }
    }
}