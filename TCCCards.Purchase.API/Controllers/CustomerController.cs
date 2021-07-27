using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Service.Contact;

namespace TCCCards.Purchase.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;

        public CustomerController(ICustomerService customerService, IAddressService addressService)
        {
            _customerService = customerService;
            _addressService = addressService;
        }

        [HttpGet("[action]")]
        public IActionResult Selections(int userId)
        {
            var data = _customerService.GetByUserId(userId);
            return Ok(data);
        }






        [HttpGet]
        public IActionResult GetCustomers()
        {
            var data = _customerService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetCustomerByUserId/{UserId}")]
        public IActionResult GetCustomerByUserId(int UserId)
        {
            var data = _customerService.GetByUserId(UserId);
            return Ok(data);
        }

        [HttpGet("GetCustomerById/{CustomerId}")]
        public IActionResult GetCustomerById(int CustomerId)
        {
            var data = _customerService.GetById(CustomerId);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            var data = _addressService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetByCustomerId/{CustomerId}")]
        public IActionResult GetByCustomerId(int CustomerId)
        {
            var data = _addressService.GetByCustomerId(CustomerId);
            return Ok(data);
        }

        [HttpGet("GetAddressrByUserId/{AddressId}")]
        public IActionResult GetAddressIdById(int AddressId)
        {
            var data = _addressService.GetById(AddressId);
            return Ok(data);
        }

        
    }
}
