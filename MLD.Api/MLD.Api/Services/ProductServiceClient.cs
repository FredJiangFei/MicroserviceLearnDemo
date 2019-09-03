namespace MLD.Api.Services
{
    public static class ProductServiceClient
    {
        private static readonly ProductService.ProductServiceClient Client;

        static ProductServiceClient()
        {
            var channel = ServiceClientHelper.GetChannelByApiName("ProductApi");
            Client = new ProductService.ProductServiceClient(channel);
        }

        public static GetProductsReply GetProducts()
        {
            return Client.GetProducts(new GetProductsRequest());
        }
    }
}