using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WappExcelNobleza.Data;
using static WappExcelNobleza.Data.ExpressionUtils;

namespace WappExcelNobleza.Services
{
    public class OperationsDataBase<T> : IOperationsDataBase<T> where T : class
    {
        public excelnobleza.shared.ApplicationDbContextCore _context { get; protected set; }

        public OperationsDataBase(excelnobleza.shared.ApplicationDbContextCore _context)
        {
            this._context = _context;
            this.Source = _context.Set<T>().AsQueryable();
            this.FilterPropertyNames = new string[] { "Id" };
        }

        public IQueryable<T> Source { get; set; }
        public string[] FilterPropertyNames { get; set; }


        public void SetFilterPropertyNames(params string[] propertiesToFilter)
        {
            this.FilterPropertyNames = propertiesToFilter;
        }

        public void SetIncludes(params string[] propertiesToInclude)
        {
            this.Source = _context.Set<T>().AsQueryable();

            foreach (var prop in propertiesToInclude)
            {
                var property = typeof(T).GetProperty(prop);
                if (property == null)
                {
                    throw new ArgumentException($"The property {typeof(T)}.{prop} was not found.", nameof(prop));
                }

                this.Source = this.Source.Include(prop);
            }

        }


        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T Entity)
        {
            _context.Add(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }


        public async Task<T> Get(object Id)
        {
            var ret = await _context.FindAsync<T>(Id);
            if (ret != null && _context.Entry(ret).State != EntityState.Unchanged) await _context.Entry(ret).ReloadAsync();
            return ret;
        }

        public async Task<T> Update(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> Delete(int Id)
        {
            var ret = await _context.FindAsync<T>(Id);
            if (ret != null)
            {
                _context.Remove(ret);
                await _context.SaveChangesAsync();
            }
            return ret;
        }

        public async Task<PaginatedList<T>> GetList(int? pageNumber, string sortField, string sortOrder, string filter = "", int pageSize = 5)
        {
            this.Source = Source ?? _context.Set<T>().AsQueryable();
            var ret = Source.OrderByDynamic(sortField, sortOrder.ToUpper());

            if (FilterPropertyNames != null) ret = ret.Where(FilterPropertyNames, ComparisonTypes.Contains, filter);

            return await PaginatedList<T>.CreateAsync(ret.AsNoTracking(), pageNumber ?? 1, pageSize);
        }

    }
}
