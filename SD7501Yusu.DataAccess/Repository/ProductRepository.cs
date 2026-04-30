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
            var objFormDb=_db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if (objFormDb != null)
            { 
                objFormDb.Title = obj.Title;
                objFormDb.ISBN = obj.ISBN;
                objFormDb.Price = obj.Price;
                objFormDb.ListPrice = obj.ListPrice;
                objFormDb.Price50=obj.Price50;
                objFormDb.Price100=obj.Price100;
                objFormDb.Description = obj.Description;
                objFormDb.CategoryId = obj.CategoryId;
                objFormDb.Author=obj.Author;
                if (obj.ImageUrl != null)
                { 
                    objFormDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
