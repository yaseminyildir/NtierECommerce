﻿using NTierECommerce.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.BLL.Abstracts
{
    public interface ICategoryReposiyory
    {
        IEnumerable<Category> GetAllCategories();
        Task<string> CreateCategory(Category entity);
        Task<string> UpdateCategory(Category entity);
        Task<Category> GetById(int id);// Task<T> 
    }
}
