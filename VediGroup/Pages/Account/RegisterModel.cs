using Microsoft.AspNetCore.Components;
using VediGroup.Services;
using Core;
using Core.DataBase;

namespace VediGroup.Pages.Account
{
    public class RegisterModel: ComponentBase
    {
        [Inject] ILocalStorageService LocalStorageService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        public RegisterModel() 
        {
            ViewModel = new RegisterViewModel();
        }

        public RegisterViewModel ViewModel { get; set; }

        protected async Task RegisterAsync()
        {
            var user = new User
            {
                Login = ViewModel.Username,
                Password = ViewModel.Password,
                Email = ViewModel.Email,
                FirstName = ViewModel.FirstName,
                LastName = ViewModel.LastName,
                Role = DataAccess.GetRole("Manager")
            };

            DataAccess.SaveUser(user);

            var token = new SecurityToken
            {
                Username = ViewModel.Username,
                Password = ViewModel.Password,
            };

            await LocalStorageService.SetAsync(nameof(SecurityToken), token);
            NavigationManager.NavigateTo("/", true);
        }
    }
}
