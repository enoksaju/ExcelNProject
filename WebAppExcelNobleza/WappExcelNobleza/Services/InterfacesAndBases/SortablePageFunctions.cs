using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
    public class SortablePageFunctions<T> : ISortablePageFunctions
    {
        private IOperationsDataBase<T> service;
        private string _filterString = "";
        private int _pageSize = 5;
        public int PageNumber { get; set; } = 1;
        public string FilterString
        {
            get => _filterString;
            set
            {
                if (_filterString == value) return;
                _filterString = value;
                ChangePageSize();
            }
        }
        public string CurrentSortField { get; set; } = "";
        public string CurrentSortOrder { get; set; }
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value != _pageSize)
                {
                    _pageSize = value;
                    ChangePageSize();
                }
            }
        }
        public IPaginatedList<T> PaginatedList { get; set; }

        public event EventHandler<LoadingEventArgs> LoadingChanged;

        public MainStateContainer MainContainer { get; set; }       

        public SortablePageFunctions(IOperationsDataBase<T> _service, MainStateContainer mainContainer = null)
        {
            service = _service;
            MainContainer = mainContainer;

            PageSize = MainContainer != null ? MainContainer.PageSize : 5;

        }

        private async void ChangePageSize()
        {
            if (MainContainer != null) MainContainer.setPageSize(this._pageSize);
            PageNumber = 1;
            await Filter(CurrentSortField, false);
        }


        public async Task Filter(string sortField = "", bool reorder = true)
        {
           
            if(PaginatedList != null) OnLoadingChange(new LoadingEventArgs(true));
           
            sortField = sortField == "" ? (CurrentSortField == "" ? "Id" : CurrentSortField) : sortField;

            if (sortField.Equals(CurrentSortField))
            {
                if (reorder) CurrentSortOrder = CurrentSortOrder.Equals("Asc") ? "Desc" : "Asc";
            }
            else
            {
                CurrentSortField = sortField;
                CurrentSortOrder = "Asc";
            }

            PaginatedList = await service.GetList(PageNumber, CurrentSortField, CurrentSortOrder, _filterString, PageSize);

            OnLoadingChange(new LoadingEventArgs(false));
        }

        public string SortIndicator(string sortField)
        {
            if (sortField.Equals(CurrentSortField))
            {
                return CurrentSortOrder.Equals("Asc") ? "sort-asc" : "sort-desc";
            }
            return string.Empty;
        }

        public async void PageIndexChanged(int newPageNumber)
        {
            OnLoadingChange(new LoadingEventArgs(true));
            if (newPageNumber < 1 || newPageNumber > PaginatedList.TotalPages) return;
            PageNumber = newPageNumber;
            PaginatedList = await service.GetList(PageNumber, CurrentSortField, CurrentSortOrder, _filterString, PageSize);
            OnLoadingChange(new LoadingEventArgs(false));
        }

        public virtual void OnLoadingChange(LoadingEventArgs e)
        {
            EventHandler<LoadingEventArgs> handler = LoadingChanged;
            handler?.Invoke(this, e);
        }

    }
}
