using Application.Common.Interfaces;
using Application.UserCases.User.Base;

namespace Application.UserCases.User.Queries.GetUser
{
    public class GetUserQuery : IRequestHandler<GetUserInput, List<UserModelOutput>>
    {
        private readonly IAppDatabaseContext _context;

        public GetUserQuery(IAppDatabaseContext context) => _context = context;

        public async Task<List<UserModelOutput>> Handle(GetUserInput request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.AsQueryable().Apply(request).ToListAsync(cancellationToken);

            return users?.Select(UserModelOutput.FromUser).ToList();
        }
    }
}
