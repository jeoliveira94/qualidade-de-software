using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Repositories
{
    public class RepositoryImp<T> : Repository<T> where T : Model, new()
    {
        private List<T> database = new List<T>();

     
        public Task<T> AddItemAsync(T item)
        {
            database.Add(item);
            return Task.FromResult(item);
        }

        public Task<T> GetItemAsync(string id)
        {
            return Task.FromResult(database.Find(i => i.getId().Equals(id)));
        }

        public Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            var items = (IEnumerable<T>)database;
            return Task.FromResult(items);
        }

        public Task<T> UpdateItemAsync(T item)
        {
            var r = database.Find(i => i.getId().Equals(item.getId()));
            database.Remove(r);
            database.Add(item);
            return Task.FromResult(item);
        }
    }
}
