using Microsoft.AspNetCore.Mvc;

namespace web2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {

        // GET: primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }
        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }
        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }
        // GET: primitiivid/random/5/6
        [HttpGet("random/{min}/{max}")]
        public int RandomNumber(int min, int max)
        {
            return new Random().Next(min,max);
        }
        // GET: primitiivid/sunnipaev/5/6
        [HttpGet("sunnipaev/{date}")]
        public int Sunnnipaev_(DateTime date)
        {
            DateTime datte=DateTime.Now;
            if (datte.Month>=date.Month)
            {
                if (datte.Month>=date.Month)
                {
                    if (datte.Day>=date.Day)
                    {
                        return datte.Year-date.Year;
                    }

                }
            }
            return datte.Year - date.Year - 1;
        }
    }
}
