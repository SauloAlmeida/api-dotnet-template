using App.UnitTests.Application.Common;
using Application.UserCases.User.Queries.GetUser;
using DomainEntity = Domain.Entity;

namespace App.UnitTests.Application.User.GetUser
{
    [CollectionDefinition(nameof(GetUserTestFixture))]
    public class GetUserTestFixtureCollection : ICollectionFixture<GetUserTestFixture> { }

    public class GetUserTestFixture : BaseApplicationFixture
    {
        public GetUserInput GetInputById(Guid id) => new()
        {
            Id = id
        };

        public List<DomainEntity.User> GetValidUsers() => new()
            {
                new DomainEntity.User(Faker.Person.FirstName,
                                      Faker.Person.LastName,
                                      Faker.Person.Email,
                                      Guid.NewGuid().ToString()),
                new DomainEntity.User(Faker.Person.FirstName,
                                      Faker.Person.LastName,
                                      Faker.Person.Email,
                                      Guid.NewGuid().ToString())
            };
    }
}
