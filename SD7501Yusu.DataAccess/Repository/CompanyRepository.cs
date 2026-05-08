using SD7501Yusu.DataAccess.Repository.IRepository;
using SD7501Yusu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YusuWeb.Data;

namespace SD7501Yusu.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }

        public void Update(CompanyRepository obj)
        {
            throw new NotImplementedException();
        }
    }
}
