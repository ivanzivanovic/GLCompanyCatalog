using GL.CompanyCatalog.Application.Contracts;
using GL.CompanyCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GL.CompanyCatalog.Persistence.IntegrationTests
{
    public class GLDbContextTests
    {
        private readonly GLDbContext _gLDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public GLDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GLDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _gLDbContext = new GLDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Company() {CompanyId = Guid.NewGuid(), Name = "Test company" };

            _gLDbContext.Companies.Add(ev);
            await _gLDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
