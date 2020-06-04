using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CoverTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(CoverType coverType)
        {
            var CoverInDb = _context.CoverTypes.SingleOrDefault(c => c.Id == coverType.Id);
            if (CoverInDb != null)
            {
                CoverInDb.Name = coverType.Name;
            }
        }
    }
}
