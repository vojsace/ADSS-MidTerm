using System;
using System.Xml.Serialization;

namespace Lecture5
{
    [Serializable]
    public class Employee
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