using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class PostInfo
    {
        [Key]
        public int id{get; set;}
        [Required]
        public string title{get; set;}
        [Required]
        public string content{get; set; }
        [Required]
        public int deletedFlg { get; set; }

    }
}
