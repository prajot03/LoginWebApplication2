using ApplicationLayer.DTO;
using DomainLayer;
using InfrastratureLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class ProductService:IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultResponse<Product>> AddProduct(AddProductRequest request)
        {
            var category = await _dbContext.Categories.FindAsync(request.CategoryId);
            if (category == null)
                return ResultResponse<Product>.Fail("Category not found");

            var product = new Product
            {
                productName = request.productName,
                productCategory = category,
                price = request.price,
                quantity = request.quantity
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return ResultResponse<Product>.Success(product);
        }

        public async Task<ResultResponse<List<Product>>> GetProducts()
        {
            var products = await _dbContext.Products
                .Include(p => p.productCategory)
                .ToListAsync();

            if (products == null || products.Count == 0)
                return ResultResponse<List<Product>>.Fail("No products found");

            return ResultResponse<List<Product>>.Success(products);
        }

        public async Task<ResultResponse<Product>> UpdateProduct(UpdateProductRequest request)
        {
            var product = await _dbContext.Products
                .Include(p => p.productCategory)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product == null)
                return ResultResponse<Product>.Fail("Product not found");

            var category = await _dbContext.Categories.FindAsync(request.CategoryId);
            if (category == null)
                return ResultResponse<Product>.Fail("Category not found");

            product.productName = request.productName;
            product.productCategory = category;
            product.price = request.price;
            product.quantity = request.quantity;

            await _dbContext.SaveChangesAsync();

            return ResultResponse<Product>.Success(product);
        }
    

}
}
