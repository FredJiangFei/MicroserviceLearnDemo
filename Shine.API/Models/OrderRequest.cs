
using System;

namespace Shine.API.Models
{
    public class OrderRequest
    {
        public OrderDetail[] Details { get; set; }
    }

    public class OrderDetail
    {
        public string Sku { get; set; }
        public string Name { get; set; }
    }
}