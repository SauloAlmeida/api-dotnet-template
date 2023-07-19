using Application.Common.Interfaces;

namespace Application.UserCases.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequestHandler<CreateUserInput, Unit>
    {
        private readonly IAppDatabaseContext _context;

        public CreateUserCommand(IAppDatabaseContext context) => _context = context;

        public async Task<Unit> Handle(CreateUserInput request, CancellationToken cancellationToken)
        {
            var newUser = new Domain.Entity.User(request.Name, request.LastName, request.Email, request.Password);

            await _context.Users.AddAsync(newUser, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
