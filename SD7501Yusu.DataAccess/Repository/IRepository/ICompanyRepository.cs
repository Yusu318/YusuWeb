using SD7501Yusu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD7501Yusu.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository:IRepository<Company>
    {
        void Update(Company obj);
        void Save();
    }
}
