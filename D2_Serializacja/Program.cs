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
            Employee emp = new Employee()
            {
                Id = 1,
                FirstName = "Jacek",
                LastName = "Domański",
                IsManager = true,
                /*AccessRooms = new List<int> { 1, 2, 3, 4, 5, 6 },*/
                StartAt = new DateTime(2022, 2, 3)
            };
            emp.SetToken(Guid.NewGuid().ToString());

            BinarySerializer.Create(emp);
            SoapSerializer.Create(emp);

            Console.ReadKey();
        }
    }
}
