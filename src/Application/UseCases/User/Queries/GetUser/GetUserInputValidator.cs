namespace Application.UserCases.User.Queries.GetUser
{
    public class GetUserInputValidator : AbstractValidator<GetUserInput>
    {
        public GetUserInputValidator() => RuleFor(x => x.Id).NotEmpty();
    }
}
