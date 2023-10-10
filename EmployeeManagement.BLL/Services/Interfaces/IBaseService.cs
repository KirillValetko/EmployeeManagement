using EmployeeManagement.BLL.Models;
using EmployeeManagement.Common.Models;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BLL.Services.Interfaces
{
    public interface IBaseService<TDbModel, TDataModel, TModel, TFilter>
        where TDbModel : BaseDbModel
        where TDataModel : BaseDataModel
        where TModel : BaseModel
        where TFilter : BaseFilter
    {
        Task CreateAsync(TModel item);
        Task UpdateAsync(TModel item);
        Task DeleteAsync(Guid id);
        Task<TModel> GetByFilterAsync(TFilter filter);
        Task<List<TModel>> GetAllByFilterAsync(TFilter filter);
        Task<PaginationResponse<TModel>> GetPaginatedAsync(PaginationRequest<TFilter> request);
    }
}
