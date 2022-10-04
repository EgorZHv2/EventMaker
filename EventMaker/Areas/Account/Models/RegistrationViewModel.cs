using EventMaker.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EventMaker.Areas.Account.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string UserProfilePath { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
