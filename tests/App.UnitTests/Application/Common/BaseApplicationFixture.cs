using Application.Common.Interfaces;
using Moq;

namespace App.UnitTests.Application.Common
{
    public class BaseApplicationFixture : BaseFixture
    {
        public BaseApplicationFixture()
            : base() { }

        public Mock<IAppDatabaseContext> GetDbContextMock() => new();
    }
}
