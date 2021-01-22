using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
    public interface ISortablePageFunctions
    {
        public string FilterString { get; set; }
        public string CurrentSortField { get; set; }
        public string CurrentSortOrder { get; set; }
        public int PageSize { get; set; }
        public event EventHandler<LoadingEventArgs> LoadingChanged;
                
        Task Filter(string sortField = "", bool reorder = true);
        string SortIndicator(string sortField);
        //public IPaginatedList<T> PaginatedList { get; set; }
        void PageIndexChanged(int newPageNumber);       
    }

    public class LoadingEventArgs : EventArgs
    {
        public bool isUpdating { get;  }
        public LoadingEventArgs(bool val)
        {
            isUpdating = val;
        }
    }
}
