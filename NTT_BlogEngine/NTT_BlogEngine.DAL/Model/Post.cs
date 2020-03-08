using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace NTT_BlogEngine.DAL.Model
{
    public class Post : BaseModel<int>
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Slug { get; set; }

        [Required, StringLength(300)]
        public string Description { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }
    }
}
