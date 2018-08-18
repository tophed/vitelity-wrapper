using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public interface IDIDOrderingCommands
    {
        Task<CommandResult> GetLocalDID(string did);
        Task<CommandResult> GetTollFree(string did);
    }
}