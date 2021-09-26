using ContosoCrafts.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.Website.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public JsonFileProductService _ProductService { get; }
        public ProductsController(JsonFileProductService productService)
        {
            _ProductService = productService;
        }
        [Route("{id}")]
        [HttpGet]
        public Product Get(string id)
        {
            var data = _ProductService.GetProducts().First(product => product.Id == id);
            return data ?? null;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _ProductService.GetProducts();
        }


    }
}
