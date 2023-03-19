using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace D2_Serializacja
{
    [Serializable]
    internal class EmployeeJSON
    {
        public int Id { get; set; }
        public bool IsManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> AccessRooms { get; set; }
        [ScriptIgnore]
        [JsonIgnore]
        public List<string> ExtraData { get; set; }
        public DateTime StartAt { get; set; }
        [NonSerialized()]
        private string Token;

        public void SetToken(string token)
        {
            Token = token;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
