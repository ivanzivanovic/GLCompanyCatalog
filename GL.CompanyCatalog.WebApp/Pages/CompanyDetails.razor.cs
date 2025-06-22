using GL.CompanyCatalog.WebApp.Contracts;
using GL.CompanyCatalog.WebApp.Services;
using GL.CompanyCatalog.WebApp.Services.Base;
using GL.CompanyCatalog.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GL.CompanyCatalog.WebApp.Pages
{
    public partial class CompanyDetails
    {
        [Inject]
        public ICompanyDataService CompanyDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CompanyDetailViewModel CompanyDetailViewModel { get; set; } 
            = new CompanyDetailViewModel() {};

        public ObservableCollection<CategoryViewModel> Categories { get; set; } 
            = new ObservableCollection<CategoryViewModel>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string companyid { get; set; }
        
        private Guid SelectedCompanyId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(companyid, out SelectedCompanyId))
            {
                CompanyDetailViewModel = await CompanyDataService.GetCompanyById(SelectedCompanyId);
                SelectedCategoryId = CompanyDetailViewModel.CategoryId.ToString();
            }

            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(list);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            CompanyDetailViewModel.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedCompanyId == Guid.Empty)
            {
                response = await CompanyDataService.CreateCompany(CompanyDetailViewModel);
            }
            else
            {
                 response = await CompanyDataService.UpdateCompany(CompanyDetailViewModel);
            }
            HandleResponse(response);

        }

        protected async Task DeleteCompany()
        {
            var response = await CompanyDataService.DeleteCompany(SelectedCompanyId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/companyoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/companyoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
