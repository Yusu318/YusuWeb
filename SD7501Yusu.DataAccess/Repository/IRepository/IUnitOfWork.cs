using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD7501Yusu.DataAccess.Repository.IRepository; 
using YusuWeb.Data;

namespace SD7501Yusu.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
