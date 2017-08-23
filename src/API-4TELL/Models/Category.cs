using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        { }

        public Category(int id, string name)
        {
            CategoryId = id;
            CategoryName = name;
            Products = new List<Product>() { };
        }

    } 
}
