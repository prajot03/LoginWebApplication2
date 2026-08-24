using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class AddProductRequest
    {
        public string productName { get; set; }
        public int CategoryId { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }

    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public int CategoryId { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
