using System.Threading.Tasks;
using Vitelity.Models;

namespace Vitelity.Api
{
    public interface IDIDOrdering
    {
        Task<BasicResponse> GetLocalDID(string did, string routesip = null);
        Task<BasicResponse> GetTollFreeDID(string did, string routesip = null);
    }
}
