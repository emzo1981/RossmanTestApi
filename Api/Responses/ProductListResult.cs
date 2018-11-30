using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace Api.Responses
{
    public class ProductListResult
    {
        public int Total { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
    }
}
