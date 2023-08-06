using App.UnitTests.Application.Common;
using Application.UserCases.User.Commands.CreateUser;

namespace App.UnitTests.Application.User.CreateUser
{
    [CollectionDefinition(nameof(CreateUserTestFixture))]
    public class CreateUserTestFixtureCollection : ICollectionFixture<CreateUserTestFixture> { }

    public class CreateUserTestFixture : BaseApplicationFixture
    {
        public CreateUserInput GetValidInput()
        {
            var fakerPerson = Faker.Person;
            return new (fakerPerson.UserName, fakerPerson.LastName, fakerPerson.Email, Guid.NewGuid().ToString());
        }
    }
}
