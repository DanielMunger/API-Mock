using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        // Change to public virtual Category Category for sql db. Not storing correctly locally.
        public string Category { get; set; }

        public Product()
        { }
        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }
    }
}
