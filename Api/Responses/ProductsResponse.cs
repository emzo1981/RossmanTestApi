using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Responses
{
    public class ProductsResponse
    {
        public ProductListResult Value { get; set; }
        public bool IsError { get; set; }
        public bool IsWaring { get; set; }
        public bool IsInfo { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsRelativeLink { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<string> Warnings { get; set; }
        public IEnumerable<string> Infos { get; set; }
        public IEnumerable<string> Successes { get; set; }
        public IEnumerable<Link> RelativeLinks { get; set; }



    }
}
