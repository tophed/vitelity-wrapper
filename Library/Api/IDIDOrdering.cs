using System.Threading.Tasks;
using Vitelity.Models;

namespace Vitelity.Api
{
    public interface IDIDOrdering
    {
        Task<BasicResponse> GetLocalDID(string did);
        Task<BasicResponse> GetTollFreeDID(string did);
    }
}
