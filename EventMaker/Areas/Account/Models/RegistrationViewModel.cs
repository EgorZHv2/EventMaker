using EventMaker.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EventMaker.Areas.Account.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Required]
        [Display(Name = "Аватар")]
        public IFormFile UserProfile { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повтор пароля")]
        public string PasswordConfirm { get; set; }
    }
}
