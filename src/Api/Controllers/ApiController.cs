using Api.Controllers.Common;
using Application.UserCases.User.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ApiController : BaseController
    {
        private readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get()
        {
            await _mediator.Send(new CreateUserInput(string.Empty, string.Empty, string.Empty, string.Empty));

            return Ok();
        }
    }
}