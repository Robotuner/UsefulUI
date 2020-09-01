using ESIStagingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulUI.Models;

namespace UsefulUI.Services
{
    public class MenuDataStore : IDataStore<Item>
    {
        readonly List<Item> menuItems;
        public MenuDataStore()
        {
            menuItems = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Calendar View", Description="Page that displays ESI calendar control.", PageType = PageType.calendarControl },
                new Item { Id = Guid.NewGuid().ToString(), Text = "FontAwesome Viewer", Description="Viewer for FontAwesome Icons.", PageType = PageType.fontAwesomeViewer },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Entry Behaviors", Description="Entry Behaviors", PageType = PageType.controlTester},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Search", Description="Search, EditMode, IsRequired, ", PageType = PageType.search },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Date and Time", Description="DateTime?, EditMode, IsRequired", PageType = PageType.dateAndTime },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Phone Entry", Description="Phone Entry, EditMode, IsRequired, Dialing", PageType = PageType.phoneEntry },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Picker", Description="Picker, Select Mode, IsRequired, UnSelect", PageType = PageType.picker },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Entry", Description="Entry, EditMode, IsRequired, ", PageType = PageType.entry },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Editor", Description="Editor, EditMode, IsRequired, ", PageType = PageType.editor },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Multi-column Grid", Description="Multi-Column Grid, EditMode, IsRequired, ", PageType = PageType.multiColumnGrid },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Label Button", Description="Label Button", PageType = PageType.labelButton }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(menuItems.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(menuItems);
        }

    }
}
