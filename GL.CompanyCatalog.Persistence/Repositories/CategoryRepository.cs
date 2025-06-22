using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GL.CompanyCatalog.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GLDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithCompanies()
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Companies).ToListAsync();
           
            return allCategories;
        }
    }
}
