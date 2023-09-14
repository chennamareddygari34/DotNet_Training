using Microsoft.AspNetCore.Mvc;
using SquareNumberApi.Interfaces;

namespace SquareNumberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberApiController : ControllerBase
    {
        private readonly INumberService _numberService;



        public NumberApiController(INumberService numberService)

        {

            _numberService = numberService;

        }



        [HttpPost]

        public ActionResult<IEnumerable<int>> CheckNumbers(List<int> numbers)

        {

            var numbersWithSquares = _numberService.NumbersWithSquares(numbers);

            return Ok(numbersWithSquares);

        }
    }
}
