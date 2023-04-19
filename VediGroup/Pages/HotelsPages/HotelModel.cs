using Core;
using Microsoft.AspNetCore.Components;

namespace VediGroup.Pages.HotelsPages
{
    public class HotelModel : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        public HotelModel()
        {
            ViewModel = new HotelViewModel();
        }
        public HotelViewModel ViewModel { get; set; }

        public async Task SaveAsync()
        {
            DataAccess.SaveHotel(ViewModel.Hotel);
            NavigationManager.NavigateTo("/hotels");
        }
    }
}
