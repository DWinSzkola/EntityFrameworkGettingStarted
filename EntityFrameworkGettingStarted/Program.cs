using EntityFrameworkGettingStarted.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkGettingStarted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().
                AddJsonFile("appsetting.json").
                Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            var dbContext = new CompanyDbContext(connectionString);

            //var employess = dbContext.EMP.Include(i=> i.Dept).ToList(); 
            //foreach(var emp in dbContext.EMP)
            //{
            //    //Console.WriteLine(emp.Dept.DeptName);
            //}
            //var departaments = dbContext.DEPT
            //    .Include(d=>d.Manager)
            //    .ToList();
            //foreach (var dept in departaments)
            //{
            //    Console.WriteLine($"{ dept.DeptName} Manager: {dept.Manager.EmpName}");
            //}
            //var managers = dbContext.EMP.Include(e => e.ManagerDepts).ToList();
            //foreach(var man in managers)
            //{
            //    //Console.WriteLine($"{man.EmpName} {man.ManagerDepts.Count()>1 ? man.ManagerDepts.FirstOrDefault() }");
            //}
            //var employessInfo = dbContext.EMP.Include(e => e.Dept).Include(e => e.Location);
            //foreach(var emp in employessInfo)
            //{
            //    Console.WriteLine($"{emp.EmpName} {emp.JobTitle}: {emp.Dept.DeptName} {emp.Location.City} {emp.Location.State}");
            //}

            var departaments = dbContext.DEPT.Include(e => e.Emps).ToList();

            foreach(var dep in departaments)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"|-{dep.DeptName} Departament, avg Salary: {dep.Emps.Average(e=>e.Salary)}");
                foreach(var emps in dep.Emps)
                {
                    Console.WriteLine($"|--{emps.EmpName}: Salary: {emps.Salary}");
                }
            }
        }
    }
}