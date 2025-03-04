using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkGettingStarted.Data.Models
{
    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public int? ManagerID { get; set; }

        public virtual ICollection<Employee> Emps { get; set; }
        public virtual Employee? Manager { get; set; }
    }
}
