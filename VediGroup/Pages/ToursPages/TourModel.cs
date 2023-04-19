using Core;
using Microsoft.AspNetCore.Components;
using System;

namespace VediGroup.Pages.ToursPages
{
    public class TourModel : ComponentBase 
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        public TourModel()
        {
            ViewModel= new TourViewModel();
        }

        public TourViewModel ViewModel { get; set; }

        public async Task SaveAsync()
        {

            if (ViewModel.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(ViewModel.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)ViewModel.Image.Length);
                }
                // установка массива байтов
                ViewModel.Tour.Image = imageData;
            }
            DataAccess.SaveTour(ViewModel.Tour);
            NavigationManager.NavigateTo("/tours");
        }
    }
}
