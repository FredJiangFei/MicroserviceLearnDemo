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
                    Price = 123,
                    Image = "https://ss0.bdstatic.com/94oJfD_bAAcT8t7mm9GUKT-xh_/timg?image&quality=100&size=b4000_4000&sec=1567555276&di=7c0f2b9d23dcb1326604b8c447231446&src=http://s1.sinaimg.cn/large/001TbZQpzy7bgY9Kq6g0c"
                },
                new GetProductReply
                {
                    Id = 2,
                    Sku = "Sk456",
                    Price = 456,
                    Image = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1567565385273&di=7b89f4f48b8157cef03adb4fd664ef06&imgtype=0&src=http%3A%2F%2Fs1.sinaimg.cn%2Flarge%2F0062fPyOzy73pjTr5sge4"
                }
            };
        }
    }
}