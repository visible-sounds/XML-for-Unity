using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

namespace XMLSystem
{
    /// <summary>
    /// Class to handle Saving and Loading of Objects to files, using XML Serialization.
    /// </summary>
    public class FileOperations
    {
        public static void WriteXMLFile(object _objToWrite, string _pathToWriteTo)
        {
            string fileName = Path.GetFileName(_pathToWriteTo);
            // If file already exists delete existing.
            if (File.Exists(fileName))
                File.Delete(fileName);
            

            XmlSerializer serializer = new XmlSerializer(_objToWrite.GetType());
            StreamWriter writer = new StreamWriter(_pathToWriteTo);
            serializer.Serialize(writer.BaseStream, _objToWrite);
            writer.Close();
        }

        public static T LoadFromXMLFile<T>(string _pathToFile)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                if (!File.Exists(_pathToFile))
                {
                    throw new FileNotFoundException();
                }
                using (StreamReader sr = new StreamReader(_pathToFile))
                {
                    T deserialized = (T)serializer.Deserialize(sr.BaseStream);
                    sr.Close();
                    return deserialized;
                }
            }
            catch(FileNotFoundException ex)
            {
                Debug.LogError("File not found.");
                Debug.Log($"'{ex}'");
                throw;
            }
            catch (System.Exception ex)
            {
                Debug.Log("File not loaded.");
                Debug.Log($"'{ex}'");
                throw;
            }
        }
    }
}
