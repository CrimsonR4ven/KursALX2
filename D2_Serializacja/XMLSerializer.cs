using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace D2_Serializacja
{
    internal class SerializerXML
    {
        public static void Create(EmployeeXML[] emp)
        {
            
            using (FileStream fs = new FileStream("dumpXML.xml", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(EmployeeXML[]));
                xmlSerializer.Serialize(fs, emp);
            }

            using (FileStream fs = new FileStream("dumpXML.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(EmployeeXML[]));
                EmployeeXML[] empArrayDeserial = xmlSerializer.Deserialize(fs) as EmployeeXML[];
                if (empArrayDeserial != null)
                {
                    foreach(var em in empArrayDeserial)
                        Console.WriteLine(em);
                }
            }
        }
    }
}
