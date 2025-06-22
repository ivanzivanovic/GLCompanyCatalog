using GL.CompanyCatalog.Domain.Entities;

namespace GL.CompanyCatalog.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithCompanies();
    }
}
