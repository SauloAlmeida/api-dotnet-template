using Application.UserCases.User.Queries.GetUser;
using FluentAssertions;
using MockQueryable.Moq;

namespace App.UnitTests.Application.User.GetUser
{
    [Collection(nameof(GetUserTestFixture))]
    public class GetUserTest
    {
        private readonly GetUserTestFixture _fixture;

        public GetUserTest(GetUserTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(Get))]
        public async Task Get()
        {
            var usersMock = _fixture.GetValidUsers();
            Guid userIdToSearch = usersMock[0].Id;
            GetUserInput inputSearch = _fixture.GetInputById(userIdToSearch);

            var userDbSetMocks = usersMock.AsQueryable().BuildMockDbSet();
            var applicationDbContextMock = _fixture.GetDbContextMock();
            applicationDbContextMock.Setup(s => s.Users).Returns(userDbSetMocks.Object);

            var command = new GetUserQuery(applicationDbContextMock.Object);

            var output = await command.Handle(inputSearch, CancellationToken.None);

            output.Should().NotBeNull();
            output.Should().HaveCount(1);
            output.Should().Contain(c => c.Id == userIdToSearch);
        }
    }
}