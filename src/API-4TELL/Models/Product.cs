﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_4TELL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual Category Category { get; set; }

        public Product()
        { }
        public Product(int id, string name)
        {
            ProductId = id;
            ProductName = name;
            
        }
    }
}
