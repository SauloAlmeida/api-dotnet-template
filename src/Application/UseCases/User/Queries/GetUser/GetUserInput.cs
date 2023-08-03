using Application.UserCases.User.Base;
using Domain.Enum;

namespace Application.UserCases.User.Queries.GetUser
{
    public class GetUserInput : IRequest<List<UserModelOutput>>, ICustomQueryable, IQueryPaging, IQuerySort
    {
        public Guid? Id { get; set; }

        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserStatus? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int? Limit { get; set; } = 10;
        public int? Offset { get; set; }
        public string Sort { get; set; }
    }
}
