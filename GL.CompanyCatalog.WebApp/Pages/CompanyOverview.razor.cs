using GL.CompanyCatalog.WebApp.Contracts;
using GL.CompanyCatalog.WebApp.Services;
using GL.CompanyCatalog.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GL.CompanyCatalog.WebApp.Pages
{
    public partial class CompanyOverview
    {
        [Inject]
        public ICompanyDataService CompanyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CompanyListViewModel> Companies { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Companies = await CompanyDataService.GetAllCompanies();
        }

        protected void AddNewCompany()
        {
            NavigationManager.NavigateTo("/companydetails");
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

    }
}
