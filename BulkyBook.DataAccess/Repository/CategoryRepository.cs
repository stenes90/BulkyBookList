using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var CategoryFromDb = _context.Categories.SingleOrDefault(c => c.Id == category.Id);
            if (CategoryFromDb != null)
            {
                CategoryFromDb.Name = category.Name;

                _context.SaveChanges();
            }
            
        }
    }
}
