
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
        

        public ProductsController()
        {
            
        }
        [HttpGet]
        public IActionResult GetProducts() 
        {
           

            return Ok();
        }
    }
}
