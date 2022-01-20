using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiApp.Models;

namespace apiApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), symbole = "Bitcoin", price="This is an item description." , Change = "9.99"},
                new Item { Id = Guid.NewGuid().ToString(), symbole = "DOGCOIN", price="This is an item description.", Change= "89.9" },
                new Item { Id = Guid.NewGuid().ToString(), symbole = "AVAX", price="This is an item description." , Change= "89,08"},
                new Item { Id = Guid.NewGuid().ToString(), symbole = "VXR", price="This is an item description.", Change= "90.90" },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
