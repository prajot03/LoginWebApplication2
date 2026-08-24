using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface ICategoryService
    {
        Task<ResultResponse<List<Category>>> AddCategory(List<AddCategoryRequest> add);
        Task<ResultResponse<Category>> UpdateCategory(UpdateCategoryRequest request);
        Task<ResultResponse<List<Category>>> GetCategory();
    }
}
