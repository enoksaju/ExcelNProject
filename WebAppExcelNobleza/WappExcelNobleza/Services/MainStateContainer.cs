
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
    public class MainStateContainer
    {       

        public event Action OnChange;
        public int PageSize { get; set; }

        public void setPageSize(int value)
        {
            PageSize = value;
            NotifyStateChanged();           
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
