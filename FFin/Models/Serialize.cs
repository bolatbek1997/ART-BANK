using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace FFin.Models
{
    public class Serialize
    {
        public string SerializeObject<T>(T filter)
        {

            string xml = null;
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, filter);
                try
                {
                    xml = sw.ToString();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return xml;
        }
        public T DeSerialize<T>(string inputXml)
        {
            T instance = default(T);

            if (string.IsNullOrEmpty(inputXml))
                return instance;

            try
            {
                string xml = inputXml; //TransformXml(inputXml);  // Transform the input xml to the desired xml format needed to de-serialize objects.

                //string attributeXml = string.Empty;
                using (StringReader reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlReader xmlReader = new XmlTextReader(reader))
                    {
                        instance = (T)serializer.Deserialize(xmlReader);
                        // xmlReader.Close();
                    }
                    //reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return instance;
        }

        public Batch Deserializing(string directory)
        {
            var butch = new Batch();
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Batch));
                using (FileStream fs = new FileStream(directory, FileMode.OpenOrCreate))
                {
                    butch = (Batch)formatter.Deserialize(fs);
                }
                return butch;
            }
            catch (Exception ex)
            {
                return butch=null;

                throw ex;
            }
           
        }
    }
}