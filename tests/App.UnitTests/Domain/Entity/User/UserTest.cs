using Domain.Enum;
using Domain.Exceptions;
using FluentAssertions;
using DomainEntity = Domain.Entity;

namespace App.UnitTests.Domain.Entity.User
{
    [Collection(nameof(UserTestFixture))]
    public class UserTest 
    {
        private readonly UserTestFixture _fixture;

        public UserTest(UserTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(Instantiate))]
        public void Instantiate()
        {
            var (firstName, lastName, email, password) = _fixture.GetValidUserParams();

            var datetimeBefore = DateTime.Now;
            var newUser = new DomainEntity.User(firstName, lastName, email, password);
            var datetimeAfter = DateTime.Now.AddSeconds(1);

            newUser.Should().NotBeNull();
            newUser.Name.Should().Be(firstName);
            newUser.LastName.Should().Be(lastName);
            newUser.Email.Should().Be(email);
            newUser.Password.Should().Be(password);
            newUser.Status.Should().Be(UserStatus.Active);
            newUser.CreatedAt.Should().NotBeSameDateAs(default);
            (newUser.CreatedAt >= datetimeBefore).Should().BeTrue();
            (newUser.CreatedAt <= datetimeAfter).Should().BeTrue();
        }

        [Fact(DisplayName = nameof(InstantiateWithInvalidParams))]
        public void InstantiateWithInvalidParams()
        {
            var action = () => new DomainEntity.User("", "", "", "");

            action.Should().Throw<EntityValidationException>()
                .WithMessage("Name should not be empty or null");
        }
    }
}
