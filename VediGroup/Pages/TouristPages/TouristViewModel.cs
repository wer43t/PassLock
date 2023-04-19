using Core.DataBase;
using System.ComponentModel.DataAnnotations;

namespace VediGroup.Pages.TouristPages
{
    public class TouristViewModel
    {
        public TouristViewModel()
        {
            Tourist = new Tourist();
        }
        [Required] public int Id { get; set; }

        [Required] public string FirstName { get => Tourist.FirstName; set { Tourist.FirstName = value; } }
        [Required] public string LastName { get => Tourist.LastName; set { Tourist.LastName = value; } }
        public string Patronymic { get => Tourist.Patronymic; set { Tourist.Patronymic = value; } }
        
        [Required, StringLength(4, MinimumLength = 4, ErrorMessage = "Серия состоит из 4 символов")]
        public string PassportSeries { get => Tourist.PassportSeries; set { Tourist.PassportSeries = value; } }


        [Required, StringLength(6, MinimumLength = 6, ErrorMessage = "Номер паспорта состоит из 6 символов")] 
        public string PassportNumber { get => Tourist.PassportNumber; set { Tourist.PassportNumber = value; } }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Превышена максимальная длина строки")]
        public string RegistrationAddress { get => Tourist.RegistrationAddress; set { Tourist.RegistrationAddress = value; } }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [StringLength(10, ErrorMessage = "Номер паспорта состоит из 10 символов")]
        public string InternPassportNumber { get => Tourist.InternPassportNumber; set { Tourist.InternPassportNumber = value; } }


        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Phone]
        public string PhoneNumber { get => Tourist.PhoneNumber; set { Tourist.PhoneNumber = value; } }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [EmailAddress]
        public string Email { get => Tourist.Email; set { Tourist.Email = value; } }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public int? VisaAvailabilityId { get => Tourist.VisaAvailabilityId; set { Tourist.VisaAvailabilityId = value; } }

        public Tourist Tourist { get; set; }
    }
}
