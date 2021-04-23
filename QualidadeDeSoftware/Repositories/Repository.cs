using QualidadeDeSoftware.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualidadeDeSoftware.Repositories
{
    public interface Repository<T>
    {
        Task<T> AddItemAsync(T item);
        Task<T> UpdateItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
