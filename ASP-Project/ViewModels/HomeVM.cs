using ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<TwinBlogs> TwinBlogs { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
