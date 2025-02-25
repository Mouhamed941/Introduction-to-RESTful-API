using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class myFirstAPIController : ControllerBase
    {
        [HttpGet("MyName",Name ="myName")]
        public string GetMyName()
        {
            return "Hello, my name is John Doe";
        }

        [HttpGet("YourName")]
        public string GetYourName()
        {
            return "Hello, my name is Nilay";
        }
        [HttpGet("Sum/{Number1}/{Number2}")]
        public int Sum2Numbers(int Number1, int Number2)
        {
            return Number1 + Number2;
        }

        [HttpGet("Subtract/{Number1}/{Number2}")]
        public int Subtract2Numbers(int Number1, int Number2)
        {
            return Math.Abs((Number1 - Number2));
        }


        [HttpGet("PrintNumbers")]
        
        public ActionResult<IEnumerable<int>> PrintNumbersFrom1To100()
        {
            List<int> numbers = Enumerable.Range(1, 100).ToList();
            return Ok(numbers);
        }

    }
}
