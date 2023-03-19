using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace D2_Serializacja
{
    [Serializable]
    public class EmployeeXML
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        public bool IsManager { get; set; }
        [XmlElement("First")]
        public string FirstName { get; set; }
        [XmlElement("Last")]
        public string LastName { get; set; }
        public List<int> AccessRooms { get; set; }
        [XmlIgnore]
        public List<string> ExtraData { get; set; }
        [XmlIgnore]
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
