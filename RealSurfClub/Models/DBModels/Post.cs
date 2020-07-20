using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace RealSurfClub.Models.DBModels
{
    public class Post
    {
        [Key]
        public int Id{get;set;}


        /// <summary>
        /// Тест поста
        /// </summary>
        [Display(Name="Введите текст"), MaxLength(4095)]
        public string Text { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        [Display(Name = "Прикрепить изоражение")]
        public Guid Photo { get; set; }
        
        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Автор поста
        /// </summary>
        public virtual User Author { get; set; }

    }
}