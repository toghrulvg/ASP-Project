using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models
{
    public class Brand : BaseEntity
    {
        
        [Required]
        public string Image { get; set; }
    }
}
