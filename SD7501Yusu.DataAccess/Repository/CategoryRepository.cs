using SD7501Yusu.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YusuWeb.Models;

namespace SD7501Yusu.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContect _db;
        public CategoryRepository(ApplicationDbContect db) : base(db)
        {             
            _db = db;
        }  
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Category obj)
        {
            _db.Update();
        }
    }
}
