using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ASP_Project.ViewModels.BrandViewModels
{
    public class BrandCreateVM
    {

        [Required]
        public IFormFile Photo { get; set; }
    }
}
