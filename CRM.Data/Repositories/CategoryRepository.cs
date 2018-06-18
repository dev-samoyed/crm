﻿using CRM.Data.Data;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CRM.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private DataContext db;
        public CategoryRepository(DataContext context) => db = context;

        public void Create(Category item) => db.Categories.Add(item);

        public void Delete(Guid id)
        {
            Category cat = db.Categories.Find(id);
            if (cat != null)
                db.Categories.Remove(cat);
        }

        public IEnumerable<Category> GetAll() => db.Categories.OrderByDescending(x => x.CategoryName);

        public Category GetById(Guid id) => db.Categories.Find(id);

        public void Update(Category item) => db.Entry(item).State = EntityState.Modified;
    }
}
