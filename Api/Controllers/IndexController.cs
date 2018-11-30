using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using TestApi.Models;
using TestApi.ModelsDto;
using TestApi.Responses;
using TestApi.Services;

namespace TestApi.Controllers
{  
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;  
        public IndexController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        /// <summary>
        /// Gets products from the range
        /// </summary>
        /// <param name="skip">products strats from </param>            
        /// <param name="take">products taken</param>    
        [HttpGet]
        [Route("api/products")]
  
        public async Task<IActionResult> GetProducts(string skip,string take)
        {
            if (string.IsNullOrEmpty(skip))
            {
                return BadRequest($"skip parameter can't be empty");
            }
            if (string.IsNullOrEmpty(take))
            {
                return BadRequest($"take parameter can't be empty");
            }

            var apiResponse = await _dataRepository.GetProducts(skip, take);
            if (apiResponse.IsError)
            {
                return BadRequest(apiResponse.IsError);
            }
            List<ProductDto> products = new List<ProductDto>();
            foreach (Product product in apiResponse.Value.ProductList)
            {
                var prodctDto = Mapper.Map<ProductDto>(product);
                products.Add(prodctDto);
            }          

            return Ok(products);
            

        }
  
 



    }
}
