using Api.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Ok();
    }
}