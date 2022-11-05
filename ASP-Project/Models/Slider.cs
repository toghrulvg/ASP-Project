using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models
{
    public class Slider : BaseEntity
    {
        [Required]
        public string SubTitle { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [NotMapped]
        public IFormFile MyProperty { get; set; }
    }
}
