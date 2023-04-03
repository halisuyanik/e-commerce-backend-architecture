
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
        public IActionResult GetProducts() 
        {
            
            var products=_productReadDal.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadDal.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
