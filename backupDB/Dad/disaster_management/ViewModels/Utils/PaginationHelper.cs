using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.Utils
{
    public class PaginationHelper<T>
    {
        private readonly IList<T> _allItems;

        public ObservableCollection<T> PagedItems { get; private set; }

        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages => (int)Math.Ceiling((double)_allItems.Count / PageSize);

        public PaginationHelper(IEnumerable<T> items, int pageSize = 10)
        {
            _allItems = items.ToList();
            PageSize = pageSize > 0 ? pageSize : 10;
            CurrentPage = 1;

            PagedItems = new ObservableCollection<T>();
            UpdatePagedItems();
        }

        public void MoveFirst()
        {
            CurrentPage = 1;
            UpdatePagedItems();
        }

        public void MovePrevious()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdatePagedItems();
            }
        }

        public void MoveNext()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                UpdatePagedItems();
            }
        }

        public void MoveLast()
        {
            CurrentPage = TotalPages;
            UpdatePagedItems();
        }

        private void UpdatePagedItems()
        {
            PagedItems.Clear();
            var items = _allItems.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            foreach (var item in items)
            {
                PagedItems.Add(item);
            }
        }

    }
}
