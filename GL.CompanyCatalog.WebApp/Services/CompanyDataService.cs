using AutoMapper;
using Blazored.LocalStorage;
using GL.CompanyCatalog.WebApp.Contracts;
using GL.CompanyCatalog.WebApp.Services.Base;
using GL.CompanyCatalog.WebApp.ViewModels;

namespace GL.CompanyCatalog.WebApp.Services
{
    public class CompanyDataService : BaseDataService, ICompanyDataService
    {
        
        private readonly IMapper _mapper;

        public CompanyDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CompanyListViewModel>> GetAllCompanies()
        {
            var allCompanies = await _client.GetAllCompaniesAsync();
            var mappedCompanies = _mapper.Map<ICollection<CompanyListViewModel>>(allCompanies);
            return mappedCompanies.ToList();
        }

        public async Task<CompanyDetailViewModel> GetCompanyById(Guid id)
        {
            var selectedCompany = await _client.GetCompanyByIdAsync(id);
            var mappedCompany = _mapper.Map<CompanyDetailViewModel>(selectedCompany);
            return mappedCompany;
        }

        public async Task<ApiResponse<Guid>> CreateCompany(CompanyDetailViewModel companyDetailViewModel)
        {
            try
            {
                CreateCompanyCommand createCompanyCommand = _mapper.Map<CreateCompanyCommand>(companyDetailViewModel);
                var newId = await _client.CreateCompanyAsync(createCompanyCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateCompany(CompanyDetailViewModel companyDetailViewModel)
        {
            try
            {
                UpdateCompanyCommand updateCompanyCommand = _mapper.Map<UpdateCompanyCommand>(companyDetailViewModel);
                await _client.UpdateCompanyAsync(updateCompanyCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteCompany(Guid id)
        {
            try
            {
                await _client.DeleteCompanyAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
