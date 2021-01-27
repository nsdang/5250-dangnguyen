using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hextech Gunblade", Description="Shoot forward and slow enemy if hit.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hunter Potion", Description="Instantly restore user's health.", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Shield of Shojin", Description="Reduce incoming damage.", Value=4 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Anti-heal Blade", Description="Reduce target's incoming healing if hit.", Value=6 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Rapid Firecannon", Description="Increase attack speed every 10 seconds in battle.", Value=2 },
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}