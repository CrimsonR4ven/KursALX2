using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace D2_Serializacja
{
    internal class JsonSerializer1
    {
        class MyUser
        {
            public string FName { get; set; }
            public string LName { get; set; }
        }
        public static void ApplyJson()
        {
            string s = "{ \"fname\" : \"Jan\",\"lname\" : \"Kowalewski\",\"manager\" : true}";
            MyUser user = JsonConvert.DeserializeObject<MyUser>(s, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            Console.WriteLine(user.LName);
        }
        public static void Create(EmployeeJSON[] emp)
        {
            using (FileStream fs = new FileStream("json1.json", FileMode.Create))
            {
                DataContractJsonSerializer sf = new DataContractJsonSerializer(typeof(EmployeeJSON[]));
                sf.WriteObject(fs, emp);
            }

            using (FileStream fs = new FileStream("json1.json", FileMode.Open))
            {
                DataContractJsonSerializer sf = new DataContractJsonSerializer(typeof(EmployeeJSON[]));
                EmployeeJSON[] empArrayDeserial = sf.ReadObject(fs) as EmployeeJSON[];
                if (empArrayDeserial != null)
                {
                    foreach(var em in empArrayDeserial)
                        Console.WriteLine(em);
                }
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var superes = jss.Serialize(emp);
            Console.WriteLine(superes);
            File.WriteAllText("json2.json", superes);
            var empS = jss.Deserialize<EmployeeJSON[]>(superes);
            Console.WriteLine(empS.Length);

            //serializacja newtonsoft.JSON
            var turbodymoman = JsonConvert.SerializeObject(emp,Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("json3.json", turbodymoman);
            Console.WriteLine(turbodymoman);
            var empss = JsonConvert.DeserializeObject<EmployeeJSON[]>(turbodymoman);
            Console.WriteLine(empss.Length);
        }
    }
}
