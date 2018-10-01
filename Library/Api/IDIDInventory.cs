using System.Threading.Tasks;
using Vitelity.Models;

namespace Vitelity.Api
{
    public interface IDIDInventory
    {
        Task<ListTollFreeResponse> ListTollFreeNumbers();
        Task<ListNpaResponse> ListNpa(string npa);
    }
}
