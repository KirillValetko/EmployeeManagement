using AutoMapper;
using EmployeeManagement.Common.Constants;
using EmployeeManagement.Common.Helpers.Interfaces;
using EmployeeManagement.Common.Models;
using EmployeeManagement.DAL.DataModels;
using EmployeeManagement.DAL.Filters;
using EmployeeManagement.DAL.Infrastructure;
using EmployeeManagement.DAL.Models;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories
{
    public abstract class BaseRepository<TDbModel, TDataModel, TFilter> :
        IBaseRepository<TDbModel, TDataModel, TFilter> 
        where TDbModel : BaseDbModel
        where TDataModel : BaseDataModel
        where TFilter : BaseFilter, new()
    {
        protected readonly EmployeeManagementContext _employeeManagementContext;
        protected readonly IPaginationHelper<TDbModel> _paginationHelper;
        protected readonly IMapper _mapper;

        protected BaseRepository(EmployeeManagementContext employeeManagementContext,
            IPaginationHelper<TDbModel> paginationHelper,
            IMapper mapper)
        {
            _employeeManagementContext = employeeManagementContext;
            _paginationHelper = paginationHelper;
            _mapper = mapper;
        }

        public virtual void Create(TDataModel item)
        {
            var mappedItem = _mapper.Map<TDbModel>(item);
            PrepareForCreation(mappedItem);
            _employeeManagementContext.Set<TDbModel>().Add(mappedItem);
        }

        public virtual async Task UpdateAsync(TDataModel item)
        {
            var dbItem = await _employeeManagementContext.Set<TDbModel>().FirstOrDefaultAsync(i => i.Id.Equals(item.Id));

            if (dbItem == null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            SaveImportantInfo(dbItem, item);
            _mapper.Map(item, dbItem);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var dbItem = await _employeeManagementContext.Set<TDbModel>().FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (dbItem == null)
            {
                throw new Exception(ExceptionMessageConstants.EntityIsNotFound);
            }

            _employeeManagementContext.Set<TDbModel>().Remove(dbItem);
        }

        public async Task<TDataModel> GetByFilterAsync(TFilter filter)
        {
            var source = ConstructFilter(filter);

            var item = await source.FirstOrDefaultAsync();
            var mappedItem = _mapper.Map<TDataModel>(item);

            return mappedItem;
        }

        public async Task<List<TDataModel>> GetAllByFilterAsync(TFilter filter)
        {
            var source = ConstructFilter(filter);

            var items = await source.ToListAsync();
            var mappedItems = _mapper.Map<List<TDataModel>>(items);

            return mappedItems;
        }

        public async Task<PaginationResponse<TDataModel>> GetPaginatedAsync(PaginationRequest<TFilter> request)
        {
            var source = ConstructFilter(request.Filter);

            var response = await _paginationHelper.PaginateAsync(source, request.PageNumber, request.Limit);
            var mappedResponse = _mapper.Map<PaginationResponse<TDataModel>>(response);

            return mappedResponse;
        }

        protected virtual void PrepareForCreation(TDbModel item)
        {
            item.Id = Guid.NewGuid();
        }

        protected virtual void SaveImportantInfo(TDbModel beforeSave, TDataModel forSave)
        {
            forSave.Id = beforeSave.Id;
        }

        private IQueryable<TDbModel> ConstructFilter(TFilter filter)
        {
            var items = _employeeManagementContext.Set<TDbModel>().AsQueryable().AsNoTracking();

            filter ??= new TFilter();

            if (filter.Id.HasValue)
            {
                items = items.Where(i => i.Id.Equals(filter.Id.Value));
            }

            if (filter.Ids != null && filter.Ids.Any())
            {
                items = items.Where(i => filter.Ids.Contains(i.Id));
            }

            items = AddFilterConditions(items, filter);

            return items;
        }

        protected abstract IQueryable<TDbModel> AddFilterConditions(IQueryable<TDbModel> items, TFilter filter);
    }
}
