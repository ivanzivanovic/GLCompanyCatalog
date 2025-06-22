using GL.CompanyCatalog.WebApp.Services;
using GL.CompanyCatalog.WebApp.Services.Base;
using GL.CompanyCatalog.WebApp.ViewModels;

namespace GL.CompanyCatalog.WebApp.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryCompaniesViewModel>> GetAllCategoriesWithCompanies(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
