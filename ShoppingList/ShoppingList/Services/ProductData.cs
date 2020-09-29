using ShoppingList.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public class ProductData
    {
        readonly SQLiteAsyncConnection _data;

        public ProductData(string dbPath)
        {
            _data = new SQLiteAsyncConnection(dbPath);
            _data.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _data.Table<Product>().ToListAsync();
        }

        public Task<Product> GetProductAsync(int id)
        {
            return _data.Table<Product>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveProductAsync(Product prod)
        {
            if (prod.Id != null)
            {
                return _data.UpdateAsync(prod);
            }
            else
            {
                return _data.InsertAsync(prod);
            }
        }

        public Task<int> DeleteProductAsync(Product prod)
        {
            return _data.DeleteAsync(prod);
        }
    }
}
