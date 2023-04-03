
using e_commerce.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadDal _productReadDal;
        private readonly IProductWriteDal _productWriteDal;
        public ProductsController(IProductReadDal productReadDal, IProductWriteDal productWriteDal)
        {
            _productReadDal = productReadDal;
            _productWriteDal = productWriteDal;
        }

        [HttpGet]
        public async Task Get() 
        {

            var result=await _productReadDal.GetByIdAsync("1e90a299-e403-4547-a6d7-90996854d114", false);
            result.Name = "11p";
            await _productWriteDal.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadDal.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
