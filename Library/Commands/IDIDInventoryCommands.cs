using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public interface IDIDInventoryCommands
    {
        Task<CommandResult> ListTollFree();
        Task<CommandResult> ListNpa(string npa);
    }
}