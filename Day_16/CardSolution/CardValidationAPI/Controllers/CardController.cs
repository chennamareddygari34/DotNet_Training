using CardValidationAPI.Interfaces;
using CardValidationAPI.Models;
using Microsoft.AspNetCore.Mvc;



namespace CardValidationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _service;



        public CardController(ICardService service)
        {
            _service = service;
        }



        [HttpPost]
        public ActionResult Post(Card card)
        {
            var number = _service.ValidateCard(card.CardNumber);



            if (number == null)
            {
                return BadRequest("Invalid credit card number.");
            }
            else
            {
                return Ok("Valid credit card number.");
            }
        }
    }
}
