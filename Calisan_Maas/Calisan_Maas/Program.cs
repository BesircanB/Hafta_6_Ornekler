using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calisan_Maas
{
    // Çalışan rolleri için enum
    public enum EmployeeRole
    {
        Manager,
        Developer,
        Designer,
        Tester
    }

    public class Employee
    {
        public string Name { get; set; }
        public EmployeeRole Role { get; set; }

        public decimal CalculateSalary()
        {
            switch (Role)
            {
                case EmployeeRole.Manager:
                    return 8000m; // Yöneticinin maaşı
                case EmployeeRole.Developer:
                    return 6000m; // Geliştiricinin maaşı
                case EmployeeRole.Designer:
                    return 5000m; // Tasarımcının maaşı
                case EmployeeRole.Tester:
                    return 4000m; // Testçinin maaşı
                default:
                    throw new ArgumentException("Geçersiz çalışan rolü");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Name = "Ahmet",
                Role = EmployeeRole.Developer
            };

            decimal salary = employee.CalculateSalary();
            Console.WriteLine($"{employee.Name} için maaş: {salary} TL");

            Console.ReadLine();
        }
    }
}
