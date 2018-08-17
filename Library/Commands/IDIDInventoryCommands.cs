using System.Threading.Tasks;

namespace Vitelity.Commands
{
    public interface IDIDInventoryCommands
    {
        Task<string> ListTollFree();
        Task<string> ListLocal();
        Task<string> ListNpa(string areaCode);
    }
}