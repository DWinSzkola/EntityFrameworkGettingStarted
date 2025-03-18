using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkGettingStarted.Data.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Employee> Employess { get; set; }
    }
}
