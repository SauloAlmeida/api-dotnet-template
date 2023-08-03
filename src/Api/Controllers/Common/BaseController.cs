using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Common
{
    [ApiController]
    [Route("v1/[controller]")]
    public abstract class BaseController : ControllerBase { }
}
