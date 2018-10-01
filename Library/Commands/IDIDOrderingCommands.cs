using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public interface IDIDOrderingCommands
    {
        Task<CommandResult> GetLocalDID(string did, string routesip = null);
        Task<CommandResult> GetTollFree(string did, string routesip = null);
    }
}