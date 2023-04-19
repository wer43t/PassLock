using Microsoft.AspNetCore.Components;
using Core;

namespace VediGroup.Pages.CountriesPages
{
    public class CountryModel : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        public CountryModel()
        {
            ViewModel = new CountryViewModel();
        }
        public CountryViewModel ViewModel { get; set; }

        public async Task SaveAsync()
        {
            DataAccess.SaveCountry(ViewModel.Country);
            NavigationManager.NavigateTo("/countries");
        }
    }
}
