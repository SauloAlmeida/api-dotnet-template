namespace App.UnitTests.Domain.Entity.User
{
    [CollectionDefinition(nameof(UserTestFixture))]
    public class UserTestFixtureCollection : ICollectionFixture<UserTestFixture> { }

    public class UserTestFixture : BaseFixture
    {
        public UserTestFixture()
            : base() { }

        public (string, string, string, string) GetValidUserParams()
        {
            var fakerPerson = Faker.Person;
            return (fakerPerson.UserName, fakerPerson.LastName, fakerPerson.Email, Guid.NewGuid().ToString());
        }
    }
}
