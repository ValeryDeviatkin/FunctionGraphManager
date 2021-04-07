using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IAppLifecycleService
    {
        Task SaveGraphsAsync();
        Task LoadGraphsAsync();
    }
}