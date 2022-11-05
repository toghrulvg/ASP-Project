using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models
{
    public class ProductImage : BaseEntity
    {
        public bool IsMain { get; set; } = false;
        public string Image { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
    }
}
