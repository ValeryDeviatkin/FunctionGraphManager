using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Graph;

namespace ViewModels.Interfaces
{
    public interface IDatabaseService
    {
        Task<IEnumerable<GraphViewModel>> GetAllAsync();
        Task SaveAsync(GraphViewModel item);
        Task DeleteAsync(Guid id);
    }
}