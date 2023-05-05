using Core;
using Microsoft.AspNetCore.Components;
using VediGroup.Pages.Account;
using VediGroup.Services;

namespace VediGroup.Pages.Password
{
    public class PasswordModel : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        public PasswordViewModel ViewModel { get; set; }

        public PasswordModel()
        {
            ViewModel = new PasswordViewModel();
        }

        public async Task SaveAsync()
        {

            DataAccess.SaveLogin(ViewModel.Login);
            NavigationManager.NavigateTo("/", true);
        }
    }
}
