using Api.Controllers.Common;
using Application.UserCases.User.Commands.CreateUser;
using Application.UserCases.User.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetUserInput query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserInput input)
        {
            await _mediator.Send(input);

            return NoContent();
        }
    }
}
