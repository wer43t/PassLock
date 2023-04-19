using Microsoft.AspNetCore.Components;
using VediGroup.Pages.TouristPages;

namespace VediGroup.Pages.ToursPages
{
    public class BookTourModel : ComponentBase
    {
        public BookTourModel()
        {
            ViewModel = new BookTourVievModel();
        }

        public BookTourVievModel ViewModel { get; set; }
    }
}
