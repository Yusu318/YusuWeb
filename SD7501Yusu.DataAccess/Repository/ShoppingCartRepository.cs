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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {             
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj);
        }
    }
}
