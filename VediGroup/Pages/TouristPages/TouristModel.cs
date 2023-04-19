using Microsoft.AspNetCore.Components;
using Core.DataBase;
using Core;

namespace VediGroup.Pages.TouristPages
{
    public class TouristModel : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        public TouristModel()
        {
            ViewModel = new TouristViewModel();
        }

        public TouristViewModel ViewModel { get; set; }

        public async void SaveAsync()
        {
            DataAccess.SaveTourist(ViewModel.Tourist);
            NavigationManager.NavigateTo("/tourists", true);
        }
    }
}
