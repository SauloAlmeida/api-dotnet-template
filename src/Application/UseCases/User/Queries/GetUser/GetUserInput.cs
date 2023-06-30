using Application.UserCases.User.Base;
using MediatR;

namespace Application.UserCases.User.Queries.GetUser
{
    public class GetUserInput : IRequest<UserModelOutput>
    {
        public Guid Id { get; set; }

        public GetUserInput(Guid id) => Id = id;
    }
}
