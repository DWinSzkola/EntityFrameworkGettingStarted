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

            var employess = dbContext.EMP.Include(i=> i.Dept).ToList(); 
            foreach(var emp in dbContext.EMP)
            {
                //Console.WriteLine(emp.Dept.DeptName);
            }
            var departaments = dbContext.DEPT
                .Include(d=>d.Manager)
                .ToList();
            foreach (var dept in departaments)
            {
                Console.WriteLine($"{ dept.DeptName} Manager: {dept.Manager.EmpName}");
            }
            var managers = dbContext.EMP.Include(e => e.ManagerDepts).ToList();
            foreach(var man in managers)
            {
                //Console.WriteLine($"{man.EmpName} {man.ManagerDepts.Count()>1 ? man.ManagerDepts.FirstOrDefault() }");
            }

        }
    }
}