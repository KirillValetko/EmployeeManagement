using EmployeeManagement.Common.Models;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel, TDataModel, TFilter>
        where TDbModel : BaseDbModel
        where TDataModel : BaseDataModel
        where TFilter : BaseFilter
    {
        void Create(TDataModel item);
        Task UpdateAsync(TDataModel item);
        Task DeleteAsync(Guid id);
        Task<TDataModel> GetByFilterAsync(TFilter filter);
        Task<List<TDataModel>> GetAllByFilterAsync(TFilter filter);
        Task<PaginationResponse<TDataModel>> GetPaginatedAsync(PaginationRequest<TFilter> request);
    }
}
