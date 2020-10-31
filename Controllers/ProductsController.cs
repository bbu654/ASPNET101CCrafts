using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraftsASP101v001.WebSite10302020.Models;
using ContosoCraftsASP101v001.WebSite10302020.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace ContosoCraftsASP101v001.WebSite10302020.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //go scott go???
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get; }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //[HttpPatch] [FromBody]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery]string productId, [FromQuery]int rating)
        {       //products/rate?ProductId=jenlooper-cactus&Rating=5
            ProductService.AddRating(productId, rating); return Ok();
        }
        [Route("Rate")]
        [HttpPatch]
        public ActionResult Patch([FromBody]RatingRequest request)
        {           
            ProductService.AddRating(request.ProductId, request.Rating);
            return Ok();
        }
        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
