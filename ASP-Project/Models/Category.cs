using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Project.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name cant be empty")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
