using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Common
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase { }
}
