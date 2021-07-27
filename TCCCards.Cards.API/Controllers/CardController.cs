using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCCards.Service.Contact;

namespace TCCCards.Cards.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardDetailService _cardDetailService;
        private readonly ICardTemplateService _cardTemplateService;

        public CardController(ICardDetailService cardDetailService, ICardTemplateService cardTemplateService)
        {
            _cardDetailService = cardDetailService;
            _cardTemplateService = cardTemplateService;
        }
        
        [HttpGet]
        public IActionResult GetCardDetail()
        {
            var data = _cardDetailService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetCardDetailByCustomerId/{CustomerId}")]
        public IActionResult GetCardDetailByCustomerId(int CustomerId)
        {
            var data = _cardDetailService.GetByCustomerId(CustomerId);
            return Ok(data);
        }

        [HttpGet("GetCardDetailById/{CardDetailId}")]
        public IActionResult GetCardDetailById(int CardDetailId)
        {
            var data = _cardDetailService.GetById(CardDetailId);
            return Ok(data);
        }

        public IActionResult GetCardTemplates()
        {
            var data = _cardTemplateService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetCardTemplateById/{CardTemplateId}")]
        public IActionResult GetCardTemplateById(int CardTemplateId)
        {
            var data = _cardTemplateService.GetById(CardTemplateId);
            return Ok(data);
        }


    }
}
