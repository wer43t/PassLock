using Core.DataBase;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace VediGroup.Pages.ToursPages
{
    public class TourViewModel
    {
        public TourViewModel()
        {
            Tour = new Tour();
        }
        public Tour Tour { get; set; }

        [Required]
        public string Name { get => Tour.Name; set { Tour.Name = value; } }

        [Required]
        public int? HotelId { get => Tour.HotelId; set { Tour.HotelId = value; } }
        [Required]
        public int? CityId { get => Tour.CityId; set { Tour.CityId = value; } }
        [Required]
        public int? CountryId { get => Tour.CountryId; set { Tour.CountryId = value; } }
        
        [Required]
        public DateTime DepartureDate { get => Tour.DepartureDate; set { Tour.DepartureDate = value; } }
        
        [Required]
        public DateTime ArrivalDate { get => Tour.ArrivalDate; set { Tour.ArrivalDate = value; } }

        [Required]
        public decimal? Price { get => Tour.Price; set { Tour.Price = value; } }

        [Required]
        public bool IsVisaNeeded { get => Tour.IsVisaNeeded; set { Tour.IsVisaNeeded = value; } }

        public IFormFile Image { get; set; }
    }
}