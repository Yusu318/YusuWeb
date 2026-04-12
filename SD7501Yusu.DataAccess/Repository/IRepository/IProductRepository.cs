using SD7501Yusu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YusuWeb.Models;

namespace SD7501Yusu.DataAccess.Repository.IRepository
{
    //public interface ICategoryRepository : IRepository<Category>
    public interface IProductRepository: IRepository<Product>
    {
            void Update(Product obj);

        // Add any additional methods specific to Product repository if needed
    }
    }
