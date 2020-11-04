/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: JsonFilesManipulation 
    Aim: Manipulate Json Files 
            -> Open and load data
            -> Create/edit file with data
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Data
{
    /// <summary>
    /// Toolkit to manipulate JsonFiles
    /// </summary>
    public static class JsonFilesManipulation
    {
        /// <summary>
        /// Loads a Json file and returns a string with its content
        /// </summary>
        /// <suggestions>
        /// - let it as JObject and convert to desired format separatedly
        /// </suggestions>
        /// <returns> File containing in string format </returns>
        public static string FileLoader(string filepath)
        {
            string resultText;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filepath))
            {
                JObject obj = null; // will receive deserialized content of file
                try
                {
                    StreamReader sr = new StreamReader(filepath);
                    JsonReader jsonReader = new JsonTextReader(sr);
                    obj = jsonSerializer.Deserialize(jsonReader) as JObject;

                    Console.WriteLine(obj);
                    jsonReader.Close();
                    sr.Close();
                    
                    resultText = obj.ToString(Formatting.None); // conversion of json text to string
                                                                //  Formatting.None -> to not have identation of text

                    return resultText;
                }
                catch (Exception e) { throw e; }
            }
            return null;
        }

        /// <summary>
        /// Saves a string to a json file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveStringToJsonFile(string text, string folderPath,string fileName)
        {
            // Create directory if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fullFilePath = folderPath + "//" + fileName; // Full file path. For now divided, because of directory issues
            try
            {
                File.WriteAllText(fullFilePath, text); // Passing text to json file
                return true;
            }
            catch (Exception e) { throw e; }
        }

    }
}
