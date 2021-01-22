using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
   public interface IPaginatedList<T>
    {
        int PageIndex { get; set; }
        int TotalPages { get; set; }
        List<T> Items { get; set; }
        int TotalItems { get; set; }
        string TableInfo { get; set; }
    }
}
