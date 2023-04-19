using Core.DataBase;

namespace VediGroup.Pages.ToursPages
{
    public class BookTourVievModel
    {
        public BookTourVievModel()
        {
            TouristTour = new TouristTour();
        }

        public int SelectedTourist { get; set; }

        TouristTour TouristTour { get; set; }
    }
}
