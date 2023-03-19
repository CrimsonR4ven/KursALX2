using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace D2_Serializacja
{
    internal class BinarySerializer
    {
        public static void Create()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                FirstName = "Jacek",
                LastName = "Domański",
                IsManager = true,
                AccessRooms = new List<int> { 1, 2, 3, 4, 5, 6 },
                StartAt = new DateTime(2022, 2, 3)
            };
            emp.SetToken(Guid.NewGuid().ToString());

            using (FileStream fs = new FileStream("dump.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, emp);
            }
            using (FileStream fs = new FileStream("dump.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Employee empDeserial = bf.Deserialize(fs) as Employee;
                if (empDeserial != null)
                {
                    Console.WriteLine(empDeserial);
                }
            }
        }
    }
}
