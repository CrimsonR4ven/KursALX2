using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace D2_Serializacja
{
    internal class SoapSerializer
    {
        public static void Create(Employee emp)
        {
            Employee[] empArray = new Employee[]
            {
                emp, emp, emp
            };

            using (FileStream fs = new FileStream("dump.bin", FileMode.Create))
            {
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, empArray);
            }

            using (FileStream fs = new FileStream("dump.bin", FileMode.Open))
            {
                SoapFormatter sf = new SoapFormatter();
                Employee[] empArrayDeserial = sf.Deserialize(fs) as Employee[];
                if (empArrayDeserial != null)
                {
                    Console.WriteLine(empArrayDeserial.Length);
                }
            }
        }
    }
}
