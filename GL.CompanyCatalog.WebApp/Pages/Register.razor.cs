using GL.CompanyCatalog.WebApp.Contracts;
using GL.CompanyCatalog.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GL.CompanyCatalog.WebApp.Pages
{
    public partial class Register
    {

        public RegisterViewModel RegisterViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Register()
        {

        }
        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var registrationResponse = await AuthenticationService.Register(RegisterViewModel.Email, RegisterViewModel.Password);

            if (registrationResponse.Success) 
            {
                NavigationManager.NavigateTo("login");
            }
            else
            {
                Message += "User registration failed";
                Message += registrationResponse.Message;
                if (!string.IsNullOrEmpty(registrationResponse.ValidationErrors))
                    Message += registrationResponse.ValidationErrors;
            }
                
        }
    }
}
