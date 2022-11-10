using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Project.Models
{
    public class Service : BaseEntity
    {
        [Required]
        public string Color { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public string Icon { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Can't be empty")]
        public IFormFile Photo { get; set; }
    }
}
