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

            var employess = dbContext.EMP.ToList(); 
            foreach(var emp in dbContext.EMP)
            {
                Console.WriteLine(emp.EmpName);
            }
        }
    }
}