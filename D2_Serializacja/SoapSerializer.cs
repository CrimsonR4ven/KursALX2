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
        public static void Create(EmployeeSoap emp)
        {
            EmployeeSoap[] empArray = new EmployeeSoap[]
            {
                emp, emp, emp
            };

            using (FileStream fs = new FileStream("dump.xml", FileMode.Create))
            {
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, empArray);
            }

            using (FileStream fs = new FileStream("dump.xml", FileMode.Open))
            {
                SoapFormatter sf = new SoapFormatter();
                EmployeeSoap[] empArrayDeserial = sf.Deserialize(fs) as EmployeeSoap[];
                if (empArrayDeserial != null)
                {
                    foreach(var em in empArrayDeserial)
                        Console.WriteLine(em);
                }
            }
        }
    }
}
