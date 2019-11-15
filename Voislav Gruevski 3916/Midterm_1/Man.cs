using System;
using System.Xml.Serialization;

namespace Lecture5
{
    [Serializable]
    public class Man
    {
        public int empCode;
        private string empName;

        [XmlAttribute("empName")]
        public string EmpName
        {
            get
            {
                return empName;
            }
            set
            {
                empName = value;
            }
        }
    }
}
