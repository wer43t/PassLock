using Core.DataBase;
using System.ComponentModel.DataAnnotations;

namespace VediGroup.Pages.Manager
{
    public class ManagerViewModel
    {
        public ManagerViewModel()
        {
            Manager = new User();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get => Manager.FirstName; set { Manager.FirstName = value; } }
        [Required]
        public string LastName { get => Manager.LastName; set { Manager.LastName = value; } }
        [Required]
        [EmailAddress]
        public string Email { get => Manager.Email; set { Manager.Email = value; } }
        [Required]
        public string Login { get => Manager.Login; set { Manager.Login = value; } }
        [Required]
        public string Password { get => Manager.Password; set { Manager.Password = value; } }
        [Required]
        public int? RoleId { get => Manager.RoleId; set { Manager.RoleId = value; } }
        public User Manager { get; set; }

    }
}
