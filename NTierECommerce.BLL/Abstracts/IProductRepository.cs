using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Task<string> CreateProduct(Product entity);
        Task<string> UpdateProduct(Product entity);
        Task<Product> GetById(int id);// Task<T> 
    }
}
