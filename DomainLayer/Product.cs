using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        // explicit FK
        public int CategoryId { get; set; }

        public Category productCategory {  get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }

   
}
