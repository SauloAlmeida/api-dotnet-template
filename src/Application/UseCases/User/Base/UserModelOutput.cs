using Domain.Enum;

namespace Application.UserCases.User.Base
{
    public class UserModelOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserModelOutput(Guid id,
                               string name,
                               string email,
                               UserStatus status,
                               DateTime createdAt)
        {
            Id = id;
            Name = name;
            Email = email;
            Status = status;
            CreatedAt = createdAt;
        }

        public static UserModelOutput FromUser(Domain.Entity.User user) 
            => new(user.Id,
                   user.Name,
                   user.Email,
                   user.Status,
                   user.CreatedAt);
    }
}
