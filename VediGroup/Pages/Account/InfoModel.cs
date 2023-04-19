using Core.DataBase;
using Core;
using Microsoft.AspNetCore.Components;
using VediGroup.Services;

namespace VediGroup.Pages.Account
{
    public class InfoModel: ComponentBase
    {
        [Inject] ILocalStorageService LocalStorageService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public InfoViewModel ViewModel { get; set; }

        public InfoModel()
        {
            ViewModel = new InfoViewModel();
        }

        public async Task SaveAsync()
        {

            DataAccess.SaveUser(ViewModel.User);

            var token = new SecurityToken
            {
                Username = ViewModel.User.Login,
                Password = ViewModel.User.Password,
            };

            await LocalStorageService.SetAsync(nameof(SecurityToken), token);
            NavigationManager.NavigateTo("/", true);
        }
    }
}
