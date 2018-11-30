using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;
using TestApi.Responses;

namespace TestApi.Services
{
    public interface IDataRepository
    {
        Task<ProductsResponse> GetProducts(string skip, string rows);



    }
}
