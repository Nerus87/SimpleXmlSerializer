using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SimpleXmlSerializer
{
    public class SimpleXmlSerializer<T>
    {
        private Type type;
        private DataContractSerializer serializer;
        private XmlWriterSettings settings;

        /// <summary>
        /// EN: Constructor:
        ///                 Set generic Type
        /// PL: Kosntruktor:
        ///                 Ustawia generyczny Typ 
        /// </summary>
        public SimpleXmlSerializer()
        {

            type = typeof(T);
            serializer = new DataContractSerializer(type);
            settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

        }

        /// <summary>
        /// EN: Method:
        ///             Create XML file from specyfic class
        /// PL: Metoda:
        ///             Tworzy plik XML z podanej klasy
        /// </summary>
        /// <param name="path">
        /// EN: Path to file <example>C:\Users\Folder\</example>
        /// PL: scieżka do pliku <example>C:\Użytkownicy\Folder\</example>
        /// </param>
        /// <param name="fileName">
        /// EN: File name <example>file.xml</example>
        /// PL: Nazwa pliku <example>plik.xml</example>
        /// </param>
        /// <param name="o">
        /// EN: Object to serialize
        /// PL: Obiekt jako parametr przekazany do serializacji
        /// </param>
        public void Serialization(string path, string fileName, Object o)
        {

            try
            {

                if (!path.EndsWith("/"))
                {
                    path += "/";
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                XmlWriter writer = XmlWriter.Create(path + fileName, settings);
                serializer.WriteObject(writer, o);
                writer.Close();
                

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }


        }

        /// <summary>
        /// EN: Method deserialize file to (T) Object
        /// PL: Metoda zwracająca obiekt danego typu po deserializacji z pliku XML
        /// </summary>
        /// <param name="pathToXmlFile">
        /// EN: Path to file <example>C:\Users\Folder\</example>
        /// PL: scieżka do pliku <example>C:\Użytkownicy\Folder\</example>
        /// </param>
        /// <returns></returns>
        public T Deserialization(string pathToXmlFile)
        {

            T result = default(T);
            FileInfo xml = null;
            try
            {

                xml = new FileInfo(pathToXmlFile);
                if (isExistNotNull(xml))
                {
                    result = (T) serializer.ReadObject(File.Open(pathToXmlFile, FileMode.Open));
                }

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return result;
        }

        /// <summary>
        /// EN: Method to check file - Exist and not null
        /// PL: Metoda sprawdzająca czy podany plik istnieje oraz czy nie jest null
        /// </summary>
        /// <param name="xmlFile">
        /// EN: Value of FileInfo type
        /// PL: Wartość typu FileInfo
        /// </param>
        /// <returns></returns>
        private static Boolean isExistNotNull(FileInfo xmlFile)
        {

            if (xmlFile != null && xmlFile.Exists)
            {
                return true;
            }

            return false;
        }

    }


}
