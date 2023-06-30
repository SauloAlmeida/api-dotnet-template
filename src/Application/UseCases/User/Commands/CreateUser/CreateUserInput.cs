namespace Application.UserCases.User.Commands.CreateUser
{
    public record CreateUserInput(string Name,
                                  string LastName,
                                  string Email,
                                  string Password) : IRequest<Unit>;
}
