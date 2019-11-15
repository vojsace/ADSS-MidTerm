using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Lecture5
{
    class GOD
    {
        static void Main(string[] args)
        {
            #region BinarySerialization

            /// object => data
            Product product0 = new Product() { Id = 0, Name = "Binary Product" };
            using (Stream stream = new FileStream("SerializedBinaryData.txt", FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, product0);
            }

            /// data => object
            using (Stream stream = new FileStream("SerializedBinaryData.txt", FileMode.Open, FileAccess.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                Product binaryProduct = (Product)formatter.Deserialize(stream);
                Console.WriteLine(binaryProduct.Name);
            }


            #endregion

            #region XMLSerialization

            Product product1 = new Product() { Id = 1, Name = "XML Product" };
            using (Stream stream = new FileStream("SerializedXMLData.txt", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer XmlSerializer = new XmlSerializer(typeof(Product));
                XmlSerializer.Serialize(stream, product1);
            }

            using (FileStream readStream = new FileStream("SerializedXMLData.txt", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                Product xmlProduct = (Product)xmlSerializer.Deserialize(readStream);
                Console.WriteLine(xmlProduct.Name);
            }

            #endregion

            #region JSONSerialization

            Product product2 = new Product() { Id = 2, Name = "JSON Product" };
            using (StreamWriter sw = new StreamWriter("SerializedJSONData.txt", false))
            {
                string output = JsonConvert.SerializeObject(product2, Formatting.Indented);
                sw.WriteLine(output);
            }

            string fileContent = File.ReadAllText("SerializedJSONData.txt");
            Product jsonProduct = JsonConvert.DeserializeObject<Product>(fileContent);
            Console.WriteLine(jsonProduct.Name);

            #endregion

            #region BinarySerialization

            Man employee = new Man() { empCode = 0, EmpName = "Binary PrEmployee" };
            BinarySerialize("binaryEmployee.txt", employee);
            BinaryDeserialize("binaryEmployee.txt");

            #endregion

            #region XMLSerialization

            Man xmlEmployee = new Man() { empCode = 0, EmpName = "Xml Employee" };
            XMLSerialize( xmlEmployee, "xmlEmployee.xml" );
            XMLDeserialize("xmlEmployee.xml");

            #endregion

            HUMAN personObject = new HUMAN
            {
                PersonId = 1234,
                PersonFirstName = "First Name",
                PersonLastName = "Last Name",
                PersonFullName = "First and Last name of Person"
            };
            XmlSerializer xmlSerializerForPerson = new XmlSerializer(typeof(HUMAN));
            using (TextWriter textWriter = new StreamWriter(@"Person.xml"))
            {
                xmlSerializerForPerson.Serialize(textWriter, personObject);
            }


            FileSerializer.Serialize("personCustom.txt", personObject);

            Console.ReadLine();
        }

        public static void BinarySerialize(string filename, Man emp)
        {
            FileStream fileStreamObject = null;
            try
            {
                fileStreamObject = new FileStream(filename, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStreamObject, emp);
            }
            finally
            {
                fileStreamObject?.Close();
            }
        }

        public static object BinaryDeserialize(string filename)
        {
            FileStream fileStreamObject = null;
            try
            {
                fileStreamObject = new FileStream(filename, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (binaryFormatter.Deserialize(fileStreamObject));
            }
            finally
            {
                fileStreamObject?.Close();
            }
        }

        //public void SOAPSerialize(string filename, Employee employeeObject)
        //{
        //    FileStream fileStreamObject = new FileStream(filename, FileMode.Create);
        //    SoapFormatter soapFormatter = new SoapFormatter();
        //    soapFormatter.Serialize(fileStreamObject, employeeObject);
        //    fileStreamObject.Close();
        //}

        //public static object SOAPDeserialize(string filename)
        //{
        //    FileStream fileStreamObject = new FileStream(filename, FileMode.Open);
        //    SoapFormatter soapFormatter = new SoapFormatter();
        //    object obj = (object)soapFormatter.Deserialize(fileStreamObject);
        //    fileStreamObject.Close();
        //    return obj;
        //}

        public static void XMLSerialize(Man emp, String filename)
        {
            XmlSerializer serializer = null;
            FileStream stream = null;
            try
            {
                serializer = new XmlSerializer(typeof(Man));
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                serializer.Serialize(stream, emp);
            }
            finally
            {
                stream?.Close();
            }
        }

        public static Man XMLDeserialize(String filename)
        {
            XmlSerializer serializer = null;
            FileStream stream = null;
            Man emp = new Man();
            try
            {
                serializer = new XmlSerializer(typeof(Man));
                stream = new FileStream(filename, FileMode.Open);
                emp = (Man)serializer.Deserialize(stream);
            }
            finally
            {
                stream?.Close();
            }
            return emp;
        }
    }
}
