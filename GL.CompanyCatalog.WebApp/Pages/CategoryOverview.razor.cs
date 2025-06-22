using GL.CompanyCatalog.WebApp.Contracts;
using GL.CompanyCatalog.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GL.CompanyCatalog.WebApp.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CategoryCompaniesViewModel> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategoriesWithCompanies(false);
        }

        protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        {
            if((bool)args.Value)
            {
                Categories = await CategoryDataService.GetAllCategoriesWithCompanies(true);
            }
            else
            {
                Categories = await CategoryDataService.GetAllCategoriesWithCompanies(false);
            }
        }

        protected void NavigateToAddNewCategory()
        {
            NavigationManager.NavigateTo("/addcategory");
        }
    }
}
