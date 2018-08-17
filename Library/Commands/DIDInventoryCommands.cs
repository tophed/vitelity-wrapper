using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public class DIDInventoryCommands : IDIDInventoryCommands
    {
        public Task<string> ListLocal()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ListNpa()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ListNpa(string areaCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ListTollFree()
        {
            throw new System.NotImplementedException();
        }
    }
}