using Microsoft.AspNetCore.Components;
using Core.DataBase;
using Core;

namespace VediGroup.Pages.Manager
{
    public class ManagerModel : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        public ManagerModel()
        {
            ViewModel = new ManagerViewModel();
        }

        public ManagerViewModel ViewModel { get; set; }

        public async Task SaveAsync()
        {
            DataAccess.SaveUser(ViewModel.Manager);
            NavigationManager.NavigateTo("/managers");
        }
    }
}
