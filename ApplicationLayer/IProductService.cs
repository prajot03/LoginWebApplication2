using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IProductService
    {
        Task<ResultResponse<Product>> AddProduct(AddProductRequest request);
        Task<ResultResponse<List<Product>>> GetProducts();
        Task<ResultResponse<Product>> UpdateProduct(UpdateProductRequest request);

    }
}
