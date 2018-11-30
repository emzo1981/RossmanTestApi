using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;
using TestApi.Responses;

namespace TestApi.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly IApiClient _apiClient;
        private readonly string FixerKey;


        public DataRepository(IApiClient apiClient,IConfiguration configuration)
        {            
            _apiClient = apiClient;
        }
        public async Task<ProductsResponse> GetProducts(string skip,string rows)
        {
            var uri = _apiClient.CreateRequestUri("products", $"skip={skip}&rows={rows}");
            return await _apiClient.GetAsync<ProductsResponse>(uri);

        }     


    }
}
