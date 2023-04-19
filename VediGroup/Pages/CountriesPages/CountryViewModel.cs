using Core.DataBase;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace VediGroup.Pages.CountriesPages
{
    public class CountryViewModel
    {
        
        public CountryViewModel()
        {
            Country = new Country();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get => Country.Name; set { Country.Name = value; } }

        public Country Country { get; set; }
    }
}
