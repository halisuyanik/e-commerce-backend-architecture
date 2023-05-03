
using e_commerce.Application.DTOs.Products;
using e_commerce.Application.Repositories;
using e_commerce.Application.RequestParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto product)
        {
            await _productWriteDal.AddAsync(new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            });
            await _productWriteDal.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateDto product)
        {
            var res = await _productReadDal.GetByIdAsync(product.Id);
            res.Stock = product.Stock;
            res.Price = product.Price;
            res.Name = product.Name;
            await _productWriteDal.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteDal.RemoveAsync(id);
            await _productWriteDal.SaveAsync();
            return Ok();
            
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Pagination pagination)
        {
            var totalCount = _productReadDal.GetAll(false).Count();
            var products = _productReadDal.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();
            return Ok(new {totalCount, products});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadDal.GetByIdAsync(id, false));
        }
    } 
}
