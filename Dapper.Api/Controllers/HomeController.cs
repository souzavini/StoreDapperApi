using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get(){
            return "hello world";
        }

        [HttpPost]
        [Route("")]
        public string Post(){
            return "hello world";
        }

        [HttpPut]
        [Route("")]
        public string Put(){
            return "hello world";
        }

        [HttpDelete]
        [Route("")]
        public string Delete(){
            return "hello world";
        }

    }
}