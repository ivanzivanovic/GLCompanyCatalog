using GL.CompanyCatalog.WebApp.Services.Base;
using GL.CompanyCatalog.WebApp.ViewModels;

namespace GL.CompanyCatalog.WebApp.Contracts
{
    public interface ICompanyDataService
    {
        Task<List<CompanyListViewModel>> GetAllCompanies();
        Task<CompanyDetailViewModel> GetCompanyById(Guid id);
        Task<ApiResponse<Guid>> CreateCompany(CompanyDetailViewModel companyDetailViewModel);
        Task<ApiResponse<Guid>> UpdateCompany(CompanyDetailViewModel companyDetailViewModel);
        Task<ApiResponse<Guid>> DeleteCompany(Guid id);
    }
}
