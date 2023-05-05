using Core.DataBase;
using System.ComponentModel.DataAnnotations;

namespace VediGroup.Pages.Password
{
    public class PasswordViewModel
    {
        public PasswordViewModel()
        {

        }

        public Login Login { get; set; }

        //[Required]
        //public string FirstName { get => User.FirstName; set { User.FirstName = value; } }
        //[Required]
        //public string LastName { get => User.LastName; set { User.LastName = value; } }
        //[Required]
        //[EmailAddress]
        //public string Email { get => User.Email; set { User.Email = value; } }
        [Required]
        public string website { get => Login.website; set { Login.website = value; } }
        [Required]
        public string username { get => Login.username; set { Login.username= value; } }
        public string item_name { get => Login.item_name; set { Login.item_name = value; } }
        public string note { get => Login.note; set {  Login.note = value; } }
        public string password { get => Login.password; set { Login.password = value; } }
    }
}
