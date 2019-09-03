using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;

namespace MLD.Service.Product.Services
{
    public class ProductServiceImpl : ProductService.ProductServiceBase
    {
        public override async Task<GetProductsReply> GetProducts(GetProductsRequest request, ServerCallContext context)
        {
            var products = GetProducts();
            var result = new GetProductsReply();
            result.Products.AddRange(products);
            return result;
        }

        private List<GetProductReply> GetProducts()
        {
            return new List<GetProductReply>
            {
                new GetProductReply
                {
                    Id = 1,
                    Sku = "Sk123",
                    Price = 123
                },
                new GetProductReply
                {
                    Id = 2,
                    Sku = "Sk456",
                    Price = 456
                }
            };
        }
    }
}