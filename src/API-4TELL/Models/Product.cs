using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_4TELL.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual Category Category { get; set; }

        public Product()
        { }
        public Product(int id, string name, Category category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }
    }
}
