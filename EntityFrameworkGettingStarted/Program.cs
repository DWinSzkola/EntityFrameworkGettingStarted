using EntityFrameworkGettingStarted.Data;
using EntityFrameworkGettingStarted.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EntityFrameworkGettingStarted
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().
                AddJsonFile("appsetting.json").
                Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            var dbContext = new CompanyDbContext(connectionString);

            var Departaments = dbContext.DEPT;
            var Locations = dbContext.LOCATION;
            Location ChosenLocation; 
            Department ChosenDepartament;
            string EmpName;
            string JobTitle;
            float Salary;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wybierz po ID, w którym departamencie pracuje nowy pracownik:");
                Console.WriteLine("ID | DeptName");
                foreach (var dep in Departaments)
                {
                    Console.WriteLine($"{dep.DeptID} {dep.DeptName}");
                }
                int userOutput;
                if(!int.TryParse(Console.ReadLine(), out userOutput)){
                    continue;
                }
                if(Departaments.Where(e=>e.DeptID == userOutput).Count() == 1)
                {
                    Console.Clear();
                    ChosenDepartament = Departaments.Where(e => e.DeptID == userOutput).FirstOrDefault();
                    Console.WriteLine($"Wybrano {ChosenDepartament.DeptName} o ID: {ChosenDepartament.DeptID}");
                    break;

                }

            }
            await Task.Delay(1000);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wybierz po ID, w jakiej lokalizacji pracuje nowy pracownik:");
                Console.WriteLine("ID | City | State");
                foreach (var loc in Locations)
                {
                    Console.WriteLine($"{loc.LocationID} {loc.City} {loc.State}");
                }
                int userOutput;
                if (!int.TryParse(Console.ReadLine(), out userOutput))
                {
                    continue;
                }
                if (Locations.Where(e => e.LocationID == userOutput).Count() == 1)
                {
                    Console.Clear();
                    ChosenLocation = Locations.Where(e => e.LocationID == userOutput).FirstOrDefault();
                    Console.WriteLine($"Wybrano {ChosenLocation.City} {ChosenLocation.State} o ID: {ChosenLocation.LocationID}");
                    break;

                }

            }
            Console.Clear();
            Console.WriteLine("Podaj Imie i Nazwisko pracownika:");
            EmpName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Podaj zawód pracownika:");
            JobTitle = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Podaj wypłate pracownika (w formie zmienno przecinkowej)");
                if(!float.TryParse(Console.ReadLine(), out Salary))
                {
                    continue;
                }
                Salary = (float)Math.Round(Salary, 2);
                break;
            }
            Employee newEmp = new Employee
            {
                EmpName = EmpName,
                JobTitle = JobTitle,
                Salary = (decimal)Salary,
                Dept = ChosenDepartament,
                Location = ChosenLocation
            };
            dbContext.EMP.Add(newEmp);
            dbContext.SaveChanges();
            Console.Clear();
            Console.WriteLine("Dodano nowego pracownika!!!");
            
        }
    }
}