using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTT_BlogEngine.DAL.Model
{
    public class Comment : BaseModel<int>
    {
        [Required, StringLength(1000)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        [Required]
        public int PostId { get; set; }

    }
}
