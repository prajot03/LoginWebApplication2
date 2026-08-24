using ApplicationLayer.DTO;
using DomainLayer;
using InfrastratureLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class CategoryService(AppDbContext dbContext) : ICategoryService
    {
        public async Task<ResultResponse<List<Category>>> AddCategory(List<AddCategoryRequest> add)
        {
           var entry=add.Select(x=>new Category { CategoryName=x.CategoryName}).ToList();



                



            await dbContext.AddRangeAsync(entry);
              await dbContext.SaveChangesAsync();
            return ResultResponse<List<Category>>.Success(entry);
        }

        public async Task<ResultResponse<List<Category>>> GetCategory()
        {
            var s= await dbContext.Categories.ToListAsync();

            return s==null?ResultResponse<List<Category>>
                .Fail("No Category")
                :ResultResponse<List<Category>>.Success(s);
        }

        public async Task<ResultResponse<Category>> UpdateCategory(UpdateCategoryRequest request)
        {
            var existing = await dbContext.Categories.FindAsync(request.Id);
            if (existing == null)
                return ResultResponse<Category>.Fail("Category not found");

            existing.CategoryName = request.CategoryName;
            await dbContext.SaveChangesAsync();

            return ResultResponse<Category>.Success(existing);
        }
    }
}
