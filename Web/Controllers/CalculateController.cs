using Microsoft.AspNetCore.Mvc;
using Domain;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {

        [HttpGet(Name = "Add/{x}/{y}")]
        public int Get(int x, int y)
        {
            return  new Calculator().Sum(x, y);

            //var calculator = new Calculator();
            //return calculator.Sum(x, y);
        }
    }
}
