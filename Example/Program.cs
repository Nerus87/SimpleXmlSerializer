using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleXmlSerializer;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Object clazz type ToSerialize (object serialized to XML)
            ToSerialize clazz = new ToSerialize(0.1);

            // Creating Object serializer
            SimpleXmlSerializer<ToSerialize> serializer = new SimpleXmlSerializer<ToSerialize>();

            // Serialize Object to XML
            serializer.Serialization("C:/Tmp/", "serializedObject.xml", clazz);


            ToSerialize clazz2;

            // Deserialize from XML to Object
            clazz2 = serializer.Deserialization("C:/Tmp/serializedObject.xml");


            Console.WriteLine("clazz.getVersion(): " + clazz.getVersion());
            Console.WriteLine("clazz2.getVersion(): " + clazz2.getVersion());
            Console.WriteLine("class 2.getVersion() is null because value: version is not serialized");

            Console.WriteLine("clazz2.getValue2(): " + clazz2.getValue2());

            Console.WriteLine("See xml file in C:/Tmp/serializedObject.xml");
            Console.WriteLine("Press: Enter to close console !!!");

            Console.ReadLine();
        }
    }
}
