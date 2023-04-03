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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderWriteDal _orderWriteDal;
        private readonly ICustomerWriteDal _customerWriteDal;
        private readonly IOrderReadDal _orderReadDal;
        public OrdersController(IOrderWriteDal orderWriteDal, ICustomerWriteDal customerWriteDal, IOrderReadDal orderReadDal)
        {
            _orderWriteDal = orderWriteDal;
            _customerWriteDal = customerWriteDal;
            _orderReadDal = orderReadDal;
        }

        [HttpGet]
        public async Task Get()
        {
            var order = await _orderReadDal.GetByIdAsync("82dcd6db-a607-48f2-8d31-523b46dd3994");
            order.Address = "address";
            await _orderWriteDal.SaveAsync();
        }
    }
}
