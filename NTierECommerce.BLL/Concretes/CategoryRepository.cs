using NTierECommerce.BLL.Abstracts;
using NTierECommerce.Entities.Entities;
using NTierECommerce.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Concretes
{
    public class CategoryRepository : ICategoryReposiyory
    {
        private IRepository<Category> _categoryRep;


        //CategoryRepository, IRepository<Category> türünden bir nesneyi constructor aracılığıyla alır ve bunu _categoryRep alanına atar.
        public CategoryRepository(IRepository<Category> categoryRep)
        {
            _categoryRep = categoryRep;
        }



        public async Task<string> CreateCategory(Category entity)
        {
            //_categoryRep üzerindeki Create metodu, verilen Category varlığını veritabanına eklemek için
            return await _categoryRep.Create(entity);
        }

        //GetAllCategories metodu, _categoryRep üzerinden tüm kategorileri almak için kullanılır. Bu metod, IRepository<Category> arayüzünden gelen GetAll metodunu çağırır
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRep.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            //_categoryRep üzerindeki GetById metodu belirli bir id değerine sahip olan Category varlığını getirme işlemi
            return await _categoryRep.GetById(id);
        }

        public async Task<string> UpdateCategory(Category entity)
        {
            return await _categoryRep.Update(entity);
        }
    }
}
