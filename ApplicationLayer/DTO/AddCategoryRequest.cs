using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class AddCategoryRequest
    {
        public string CategoryName { get; set; }
    }
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
