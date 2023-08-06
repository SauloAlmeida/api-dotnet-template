using Application.UserCases.User.Commands.CreateUser;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using DomainEntity = Domain.Entity;

namespace App.UnitTests.Application.User.CreateUser
{
    [Collection(nameof(CreateUserTestFixture))]
    public class CreateUserTest
    {
        private readonly CreateUserTestFixture _fixture;

        public CreateUserTest(CreateUserTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(Create))]
        public async Task Create()
        {
            var applicationDbContextMock = _fixture.GetDbContextMock();
            applicationDbContextMock.Setup(s => s.Users).Returns(new Mock<DbSet<DomainEntity.User>>().Object);
            var input = _fixture.GetValidInput();
            var command = new CreateUserCommand(applicationDbContextMock.Object);

            var output = await command.Handle(input, CancellationToken.None);

            output.Should().NotBeNull();
            output.Should().Be(Unit.Value);
            applicationDbContextMock.Verify(context => context.Users.AddAsync(It.IsAny<DomainEntity.User>(), 
                                                                              It.IsAny<CancellationToken>()), 
                                            times: Times.Once);

            applicationDbContextMock.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()),
                                            times: Times.Once);
        }
    }
}
