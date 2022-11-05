using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models
{
    public class Service : BaseEntity
    {
        public string Color { get; set; }
        public string Header { get; set; }
        public string Desc { get; set; }
        public string Icon { get; set; }
    }
}
