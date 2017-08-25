using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Models.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        ApplicationContext db = new ApplicationContext();
        public IQueryable<Category> Categories
        { get { return db.Categories; } }
    }
}
