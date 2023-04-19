using Core;
using Microsoft.AspNetCore.Components;

namespace VediGroup.Pages.CitiesPages
{
    public class CityModel: ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        public CityModel()
        {
            ViewModel = new CityViewModel();
        }

        public CityViewModel ViewModel { get; set; }

        public async Task SaveAsync()
        {
            DataAccess.SaveCity(ViewModel.City);
            NavigationManager.NavigateTo("/cities");
        }
    }
}
