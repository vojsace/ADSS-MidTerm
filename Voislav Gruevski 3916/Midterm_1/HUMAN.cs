using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Lecture5
{
    [Serializable]
    public class HUMAN:ISerializable
    {
        public int PersonId;

        string personFirstName;

        string personLastName;

        [NonSerialized]
        public string PersonFullName;

        [XmlAttribute("personFirstName")]
        public string PersonFirstName
        {
            get
            {
                return personFirstName;
            }
            set
            {
                personFirstName = value;
            }
        }

        [XmlAttribute("personLastName")]
        public string PersonLastName
        {
            get
            {
                return personLastName;
            }
            set
            {
                personLastName = value;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Fn", PersonFirstName);
            info.AddValue("Ln", PersonLastName);
            info.AddValue("Id", PersonId);
        }
    }
}
