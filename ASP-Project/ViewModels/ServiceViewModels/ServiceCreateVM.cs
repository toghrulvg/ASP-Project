using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.ViewModels.ServiceViewModels
{
    public class ServiceCreateVM
    {
        [Required]
        public string Color { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Desc { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Can't be empty")]
        public IFormFile Photo { get; set; }
    }
}
