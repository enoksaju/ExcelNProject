using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
    public class PaginatedList<T>: IPaginatedList<T>
    {
        public PaginatedList() { }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public string TableInfo { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;

            var initialItemIndex = ((PageIndex - 1) * pageSize) + 1;
            var finalItemIndex = initialItemIndex + pageSize - 1 > TotalItems ? TotalItems : initialItemIndex + pageSize - 1;

            TableInfo = $"Se muestran {initialItemIndex} a {finalItemIndex} de {count} items";

            this.Items = new List<T>();
            this.Items.AddRange(items);
        }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }

   
}
