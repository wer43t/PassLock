using System.ComponentModel.DataAnnotations;
using Core.DataBase;

namespace VediGroup.Pages.Account
{
    public class InfoViewModel
    {
        public InfoViewModel()
        {
            User = new User();
        }

        public User User { get; set; }

        [Required]
        public string FirstName { get => User.FirstName; set { User.FirstName = value; } }
        [Required]
        public string LastName { get => User.LastName; set { User.LastName = value; } }
        [Required]
        [EmailAddress]
        public string Email { get => User.Email; set { User.Email = value; } }
        [Required]
        public string Login { get => User.Login; set { User.Login = value; } }
        [Required]
        public string Password { get => User.Password; set { User.Password = value; } }
        public int? RoleId { get => User.RoleId; set { User.RoleId = value; } }

    }
}