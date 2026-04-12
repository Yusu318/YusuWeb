using SD7501Yusu.DataAccess.Repository.IRepository;
using SD7501Yusu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YusuWeb.Data;
using YusuWeb.Models;

namespace SD7501Yusu.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {             
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
