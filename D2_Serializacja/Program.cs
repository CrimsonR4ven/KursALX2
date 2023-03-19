using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2_Serializacja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeJSON emp = new EmployeeJSON()
            {
                Id = 1,
                FirstName = "  Jacek",
                LastName = "    Domański",
                IsManager = true,
                AccessRooms = new List<int> { 1, 2, 3, 4, 5, 6 },
                StartAt = new DateTime(2022, 2, 3)
            };
            EmployeeJSON emp2 = new EmployeeJSON()
            {
                Id = 1,
                FirstName = " JJacekk",
                LastName = "  DDomańskii",
                IsManager = true,
                AccessRooms = new List<int> { 1, 2, 3, 4, 5, 6 },
                StartAt = new DateTime(2022, 2, 3)
            };
            EmployeeJSON emp3 = new EmployeeJSON()
            {
                Id = 1,
                FirstName ="JJJacekkk",
                LastName = "DDDomańskiii",
                IsManager = true,
                AccessRooms = new List<int> { 1, 2, 3, 4, 5, 6 },
                StartAt = new DateTime(2022, 2, 3)
            };
            emp.SetToken(Guid.NewGuid().ToString());

            // JsonSerializer1.Create(new EmployeeJSON[] { emp, emp2, emp3 });
            JsonSerializer1.ApplyJson();

            Console.ReadKey();
        }
    }
}
