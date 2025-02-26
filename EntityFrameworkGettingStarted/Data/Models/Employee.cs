using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkGettingStarted.Data.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int? DeptID { get; set; }
        public int? LocationID { get; set; }
    }
}
