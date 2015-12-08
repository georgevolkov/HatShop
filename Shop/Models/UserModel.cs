using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public virtual int RoleId { get; set; }
        public DateTime LastLogon { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Длина капчи от 6 до 100 символов", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Капча")]
        public string Captcha { get; set; }
    }
}