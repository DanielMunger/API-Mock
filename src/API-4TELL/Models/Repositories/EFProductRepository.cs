using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Models.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        ApplicationContext db = new ApplicationContext();

        public IQueryable<Product> Products
        { get { return db.Products; } }
    }
}
