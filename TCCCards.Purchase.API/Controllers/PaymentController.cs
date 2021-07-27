using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Service.Contact;
using TCCCards.ViewModels.Payment;

namespace TCCCards.Purchase.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentController(IOrderService orderService, IPaymentTypeService paymentTypeService)
        {
            _orderService = orderService;
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var data = _orderService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetOrderByCustomerId/{CustomerId}")]
        public IActionResult GetOrderByCustomerId(int CustomerId)
        {
            var data = _orderService.GetByCustomerId(CustomerId);
            return Ok(data);
        }

        [HttpGet("GetOrderById/{OrderId}")]
        public IActionResult GetOrderById(int OrderId)
        {
            var data = _orderService.GetById(OrderId);
            return Ok(data);
        }

        [HttpPost("")]
        public IActionResult Post([FromBody] AddEditOrderViewModel model)
        {
            var data = _orderService.Insert(model, "Admin");
            if (data == 0)
                return BadRequest("Unable to save data");
            return Ok(data);
        }
        [HttpPut("")]
        public IActionResult Put([FromBody] AddEditOrderViewModel model)
        {
            //var data = _orderService.Update(model, _identityHelper.UserName);
            var data = _orderService.Update(model, "Admin");

            if (data == 0)
                return BadRequest("Unable to save data");
            return Ok(data);
        }

        public IActionResult GetPaymentTypes()
        {
            var data = _paymentTypeService.GetAll();
            return Ok(data);
        }
        
        [HttpGet("GetPaymentTypeById/{PaymentTypeId}")]
        public IActionResult GetPaymentTypeById(int PaymentTypeId)
        {
            var data = _paymentTypeService.GetById(PaymentTypeId);
            return Ok(data);
        }


    }
}
