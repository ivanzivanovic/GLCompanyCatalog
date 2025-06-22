using GL.CompanyCatalog.Domain.Entities;

namespace GL.CompanyCatalog.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<bool> HaveUniqueNameInCategory(string name, Guid categoryId);
    }
}
