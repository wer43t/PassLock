using Core.DataBase;
using System.ComponentModel.DataAnnotations;

namespace VediGroup.Pages.CitiesPages
{
    public class CityViewModel
    {
        public CityViewModel()
        {
            City = new City();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get => City.Name; set { City.Name = value; } }

        [Required]
        public int CountryId { get => City.CountryId; set { City.CountryId = value; } }

        public City City { get; set; }
    }
}
