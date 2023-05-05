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

        //[Required]
        //public string FirstName { get => User.FirstName; set { User.FirstName = value; } }
        //[Required]
        //public string LastName { get => User.LastName; set { User.LastName = value; } }
        //[Required]
        //[EmailAddress]
        //public string Email { get => User.Email; set { User.Email = value; } }
        [Required]
        public string Login { get => User.login; set { User.login = value; } }
        [Required]
        public string Password { get => User.password; set { User.password = value; } }
        public int? RoleId { get => User.id_role; set { User.id_role = value; } }

    }
}