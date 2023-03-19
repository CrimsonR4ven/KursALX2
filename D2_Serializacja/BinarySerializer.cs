﻿using System;
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
        public static void Create(Employee emp)
        {
            using (FileStream fs = new FileStream("dump.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, emp);
            }

            using (FileStream fs = new FileStream("dump.bin", FileMode.Open))
            {
                BinaryFormatter bf   = new BinaryFormatter();
                Employee empDeserial = bf.Deserialize(fs) as Employee;
                if (empDeserial != null)
                {
                    Console.WriteLine(empDeserial);
                }
            }
        }
    }
}
