using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ASP_Project.ViewModels.SliderViewModels
{
    public class SliderCreateVM
    {
        [Required]
        public string SubTitle { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
