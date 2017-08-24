using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Models.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
