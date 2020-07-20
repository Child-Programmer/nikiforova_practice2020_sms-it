using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealSurfClub.Models.DBModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Никнейм
        /// </summary>
        [Display(Name="Псевдоним*")]
        [Required(ErrorMessage = "Ошибка в псевдониме"), MaxLength(20), MinLength(3)]
        public string NickName { get; set; }


        /// <summary>
        /// Почта
        /// </summary>
        [Display(Name="Почта*")]
        [Required(ErrorMessage = "Ошибка в почте")]
        [EmailAddress(ErrorMessage ="Неверно указан электронный адрес")]
        public string Email { get; set; }


        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль*")]
        [Required(ErrorMessage = "Ошибка в пароле"), MaxLength(20), MinLength(6)]
        public string Password { get; set; }


        [Display(Name = "Подтвердите пароль*"), MaxLength(20)]
        [NotMapped]
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия"), MaxLength(31)]
        public string LastName { get; set; }


        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя"), MaxLength(31)]
        public string Name { get; set; }


        /// <summary>
        /// Контакная информация
        /// </summary>
        [Display(Name = "Контактная информация"), MaxLength(4095)]
        public string ContactInfo { get; set; }


        /// <summary>
        /// О себе
        /// </summary>
        [Display(Name = "О себе"), MaxLength(4095)]
        public string About { get; set; }


        /// <summary>
        /// Достижения
        /// </summary>
        [Display(Name = "Достижения"), MaxLength(4095)]
        public string Achievements { get; set; }


        /// <summary>
        /// Фото
        /// </summary>
        [Display(Name = "Выберите фото")]
        public Guid Photo { get; set; }

    }
}