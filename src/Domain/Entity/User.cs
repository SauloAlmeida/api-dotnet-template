using Domain.Enum;
using Domain.Validation;

namespace Domain.Entity
{
    public class User : Common.Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public User(string name, string lastName, string email, string password)
            : base()
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Validate();

            Status = UserStatus.Active;
            CreatedAt = DateTime.Now;
        }

        public string GetFullName() => $"{Name} {LastName}";

        public void Validate()
        {
            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.NotNullOrEmpty(LastName, nameof(LastName));
            DomainValidation.NotNullOrEmpty(Email, nameof(Email));
            DomainValidation.MaxLength(Password, maxLength: 100, nameof(Password));
        }
    }
}
