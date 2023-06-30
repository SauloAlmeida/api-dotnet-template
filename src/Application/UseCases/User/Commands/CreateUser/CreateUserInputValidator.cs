using Application.UserCases.User.Commands.CreateUser;

namespace Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserInputValidator : AbstractValidator<CreateUserInput>
    {
        public CreateUserInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
