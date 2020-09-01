using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESIXamarinLib.Controls.ViewModels
{
    public class SearchViewModelEnhanced<T> : SearchViewModel<T, SearchClass<T>>, IRefreshFilter
    {
        public SearchViewModelEnhanced(Func<string, Task<List<T>>> filterCallback, Func<T, Task<string>> displayCallback,
             Func<T, Task> returnSelectedItem, int minFilterLength = 1) : base(filterCallback, displayCallback, returnSelectedItem, minFilterLength)
        {
        }
        public SearchViewModelEnhanced(Func<string, Task<List<T>>> filterCallback, Func<T, Task<(string, bool)>> displayCallback,
            Func<T, Task> returnSelectedItem, int minFilterLength = 1) : base(filterCallback, displayCallback, returnSelectedItem, minFilterLength)
        {
        }

        protected override SearchClass<T> CreateItem(string propertyName, T item)
        {
            return new SearchClass<T>(propertyName, item);
        }

        protected override SearchClass<T> CreateItem(string propertyName, bool isSelected, T item)
        {
            return new SearchClass<T>(propertyName, isSelected, item);
        }

        protected override SearchClass<T> CreateItem(string propertyName, string contentName, T item)
        {
            return new SearchClass<T>(propertyName, contentName, item);
        }

        protected override SearchClass<T> CreateItem(string propertyName, string contentName, bool isSelected, T item)
        {
            return new SearchClass<T>(propertyName, contentName, isSelected, item);
        }
    }
}
