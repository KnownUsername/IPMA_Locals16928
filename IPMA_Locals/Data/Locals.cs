/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: Locals 
    Aim: Manipulate locals 
        -> Acess
        -> Edit
        -> Create data storage
 */

using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data
{
    /// <summary>
    /// Contains the list of locals, and allows to consult it 
    /// </summary>
    /// <constrains>
    /// * Doesn't have a method to add objects
    ///     * Objects added are not verified if they're repeated, null, or possible value 
    /// </constrains>
    public class Locals
    {
        public static List<Local> locals = new List<Local>(); // contains all locals | MUST DO: Methods to manipulate list   |

        #region METHODS
        /// <summary>
        /// Aux function to view all locals obtained 
        /// </summary>
        public static void ShowList()
        {
            foreach (Local local in locals)
            {
                Console.WriteLine("ID:{0} Local: {1}", local.Id, local.Name);
            }
        }

        /// <summary>
        /// Gives the local's name corresponding to the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string MatchIdToLocal(int id)
        {
            // Search for id submited
            foreach (Local local in locals)
            {
                if (local.Id == id) return local.Name; // return of the corresponding local's name
            }
            return null; // Null case not found
        }

        #endregion
    }

    /// <summary>
    /// Manipulates data from locals original source
    /// </summary>
    public static class LocalsInfoManipulation
    {

        static string localsFilePath = "..\\..\\..\\..\\distrits-islands.json";
        static string originalData; // saves all data contained on the orginal data of locals 

        #region METHODS

        /// <summary>
        /// Test of generic json file loader created, on locals'file
        /// </summary>
        /// <returns></returns>
        public static bool FileLoader()
        {
            originalData = JsonFilesManipulation.FileLoader(localsFilePath); // Load of locals' file by generic json file loader
            if (originalData != null) return true;
            return false;
        }

        /// <summary>
        /// Gets all Locals from source data
        /// Locals being what was defined on class Local (id of local + local) 
        /// </summary>
        /// <returns></returns>
        public static bool GetLocalsMatches()
        {
            string idRegularExpression; // will contain regular expression for locals' ids
            string localRegularExpression; // wil contain regular expression for locals' names
            int idValue; // aux variable for id's int parse

            try
            {
                // Regular expression for IDs
                idRegularExpression = "globalIdLocal\":([0-9]+)";

                Regex regexObjLocal = new Regex(idRegularExpression);

                // Regular expression for locals (Names)
                localRegularExpression = "\"local\":\"([\\w ]+)";
                Regex regexObjId = new Regex(localRegularExpression);
            }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception e) { throw e; }

            /*  Storage of matches obtained from ids and locals    */
            MatchCollection idMatches = Regex.Matches(originalData, idRegularExpression); // getting id matches
            MatchCollection localMatches = Regex.Matches(originalData, localRegularExpression); // getting local matches

            int max_found_values = (idMatches.Count > localMatches.Count ? idMatches.Count : localMatches.Count); // amount of max values, case it's obtained
                                                                                                                  // different amounts of ids and locals
            Console.WriteLine("");
            // Cycle to introduce values into locals' list
            for (int i = 0; i < max_found_values; i++)
            {
                Local newLocal = new Local(); // aux Local to add info to locals' list
                Int32.TryParse(idMatches[i].Groups[1].Value, out idValue); // Conversion of id into int for future assignment

                // Values' Assignment
                newLocal.Id = idValue;
                Console.Write("ID: "+idValue);
                newLocal.Name = localMatches[i].Groups[1].Value;
                Console.Write("\tName: " + newLocal.Name);
                Console.WriteLine("");
                // Addiction of new local to the list (locals)
                Locals.locals.Add(newLocal);
            }
            return true;
        }
        
        #endregion
    }

    /// <summary>
    /// Manipulates weather files
    /// </summary>
    public static class WeatherInfoManipulation
    {
        #region ATTRIBUTES
        static string weatherFilePath = "..\\..\\..\\..\\1010500.json";
        static string originalData;
        #endregion

        #region METHODS

        /// <summary>
        /// Loads data from a weather file
        /// </summary>
        /// <returns></returns>
        public static bool FileLoader()
        {
            originalData = JsonFilesManipulation.FileLoader(weatherFilePath); // Load of weather's file by generic json file loader
            if (originalData != null) return true;
            return false;
        }

        /// <summary>
        /// Obtains id from source file
        /// </summary>
        /// <constraints>
        ///  This operation is used on its previous file, but implemented again.
        ///  Such things, leads to a kind of repetition of code, which isn't predicted to be fixed
        ///  before its delivery.
        /// </constraints>
        /// <returns>locals'id from a string</returns>
        static int ReachId()
        {
            string idRegularExpression; // will contain regular expression for locals' id

            try
            {
                // Regular expression for IDs
                idRegularExpression = "globalIdLocal\":([0-9]+)";
                Regex regexObjLocal = new Regex(idRegularExpression);

            }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception e) { throw e; }

            /*  Storage of matches obtained from ids and locals    */
            Match idMatch = Regex.Match(originalData, idRegularExpression); // getting id match

            // Parse id to int
            Int32.TryParse(idMatch.Groups[1].Value, out int idObtained);

            return idObtained;
        }
        #endregion

        /// <summary>
        /// Obtains position to add local
        /// </summary>
        /// <returns></returns>
        public static int ReachIndexToAddLocal()
        {
            string indexRegularExpression;
            try
            {
                // Regular expression for IDs
                //indexRegularExpression = "\"globalIdLocal\":\\s[0-9]+,\\s";
                indexRegularExpression = "\"globalIdLocal\":[0-9]+,";

                Regex regexObjIndex = new Regex(indexRegularExpression);

            }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception e) { throw e; }

            Match indexMatch = Regex.Match(originalData, indexRegularExpression);

            int indexObtained = indexMatch.Index;

            #region Auxiliar_WriteLines
            /*
            Console.WriteLine("Index: " + indexObtained);
            Console.WriteLine("Char on given index: " + originalData[indexObtained]);
            Console.WriteLine("String obtained: " + indexMatch.Value);
            Console.WriteLine("Length: " + indexMatch.Length);
            Console.WriteLine("Last char: " + originalData[indexObtained + indexMatch.Length-2]);*/
            #endregion
            return indexObtained+indexMatch.Length;
        }

        /// <summary>
        /// Adds the local, to a weather file, based on its id
        /// </summary>
        /// <returns></returns>
        public static bool AddLocalToWeatherFile()
        {
            string weatherLocal, stringLocal, newFilePath = ".//output", modifiedData;
            int idLocal, posString;

            idLocal = ReachId(); // id on file
            weatherLocal = Locals.MatchIdToLocal(idLocal); // corresponding local
            posString = ReachIndexToAddLocal(); // position to add local

            stringLocal = "\"local\": \""+weatherLocal+"\","; // text to add (local field + its value)

            modifiedData = originalData.Insert(posString, stringLocal); // Insert of new info to string copy of file

            Console.WriteLine(modifiedData);
            // # Save new changes on new file
            JsonFilesManipulation.SaveStringToJsonFile(modifiedData, newFilePath, "1110600-detalhe.json");
            
            return true;
        }
    }
}