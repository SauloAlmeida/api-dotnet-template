using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.UserCases.User.Base;

namespace Application.UserCases.User.Queries.GetUser
{
    public class GetUserQuery : IRequestHandler<GetUserInput, UserModelOutput>
    {
        private readonly IAppDatabaseContext _context;

        public GetUserQuery(IAppDatabaseContext context) => _context = context;

        public async Task<UserModelOutput> Handle(GetUserInput request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);

            NotFoundException.ThrowIfNull(user, $"User '{request.Id}' not found.");

            return UserModelOutput.FromUser(user);
        }
    }
}
