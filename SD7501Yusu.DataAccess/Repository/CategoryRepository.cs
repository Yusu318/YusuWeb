using SD7501Yusu.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YusuWeb.Data;
using YusuWeb.Models;

namespace SD7501Yusu.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {             
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
