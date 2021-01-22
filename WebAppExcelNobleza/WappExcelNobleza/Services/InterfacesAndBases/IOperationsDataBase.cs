using excelnobleza.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
    public interface IOperationsDataBase<T>
    {
        ApplicationDbContextCore _context { get; }
        IQueryable<T> Source { get; set; }
        string[] FilterPropertyNames { get; set; }
        void SetFilterPropertyNames(params string[] propertiesToFilter);
        void SetIncludes(params string[] propertiesToInclude);
        Task<List<T>> Get();
        Task<T> Get(object Id);
        Task<T> Add(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(int Id);
        Task<PaginatedList<T>> GetList(int? pageNumber, string sortField, string sortOrder, string filter = "", int pageSize = 5);
    }


}
