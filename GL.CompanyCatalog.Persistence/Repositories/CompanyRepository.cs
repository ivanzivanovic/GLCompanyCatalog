using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Domain.Entities;

namespace GL.CompanyCatalog.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(GLDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> HaveUniqueNameInCategory(string name, Guid categoryId)
        {
            var matches = _dbContext.Companies.Any(c => c.Name.Equals(name) && c.CategoryId.Equals(categoryId));
            return Task.FromResult(matches);
        }
    }
}
