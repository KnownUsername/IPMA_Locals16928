/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: Forecasts 
    Aim: Defines forecast storage and data tratment
 */
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data
{
    /// <summary>
    /// Class of forecast with list of weather
    /// </summary>
    public class ForecastTyped
    {
        #region ATTRIBUTES
        ForecastNLocalBO forecastLocal = new ForecastNLocalBO(); // BO version of ForestNLocal
        //      Lists of 5 days of weather
        static List<Weather> dataTyped = new List<Weather>(); // data with types (float,DateTime)
        #endregion

        #region METHODS
        internal static List<Weather> GetDataTypedList()
        {
            return dataTyped;
        }
        #endregion
    }

    /// <summary>
    /// Class that will be serialized for forecast
    /// </summary>
    public class ForecastToSave
    {
        ForecastNLocalBO forecastLocal = new ForecastNLocalBO(); // BO version of ForestNLocal
        static List<WeatherToSave> data = new List<WeatherToSave>(); // the one to serialize (only strings and ints)

        public static void Update()
        {

            List<Weather> listToPass = ForecastTyped.GetDataTypedList(); // copy of list typed
            
            // Passing of values
            foreach (Weather weather in listToPass)
            {
                WeatherToSave weatherToSave = new WeatherToSave(); // aux weather object to add elements to list
                weatherToSave = TransferTypedToString(weather); // transfer of values
                data.Add(weatherToSave); 
            }
        }

        /// <summary>
        /// Transfers info from a Weather object to a WeatherToSave object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destiny"></param>
        /// <returns></returns>
        static WeatherToSave TransferTypedToString(Weather source)
        {
            WeatherToSave destiny = new WeatherToSave();

            // Values Assignment
            destiny.PrecipitaProb = source.PrecipitaProb.ToString();
            destiny.Tmin = source.PrecipitaProb.ToString();
            destiny.Tmax = source.Tmax.ToString();
            destiny.PredWindDir = source.PredWindDir;
            destiny.IdWeatherType = source.IdWeatherType;
            destiny.ClassWindSpeed = source.ClassWindSpeed;
            destiny.Longitude = source.Longitude.ToString();
            destiny.ForecastDate = source.ForecastDate.ToString();
            destiny.ClassPrecInt = source.ClassPrecInt;
            destiny.Latitude = source.Latitude.ToString();

            return destiny;
        }
    }

    /// <summary>
    /// Forecast data
    /// </summary>
    class ForescastsWithLocal
    {
        static List<ForecastTyped> forecastsListLocal = new List<ForecastTyped>(); // List of all forecasts, with local added
    }

    public static class ForecastInfoManipulation { 
        static string originalData;

        /// <summary>
        /// Gathers all data 
        /// </summary>
        /// <returns></returns>
        public static bool GatherInfo()
        {

            string generalRegularExpression; // wil contain regular expression for fields match
            int idValue; // aux variable for id's int parse

            try
            {
                // Regular expression for locals (Names)
                generalRegularExpression = "\"[a-zA-Z]+\": [\"]?([^\\[][a-zA-z0-9\\.:-]*)[\"]?";
                Regex regexObjId = new Regex(generalRegularExpression);
            }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception e) { throw e; }

            /*  Storage of matches obtained from ids and locals    */
            MatchCollection generalMatches = Regex.Matches(originalData, generalRegularExpression); // getting local matches

            Console.WriteLine("");
            // Cycle to introduce values into locals' list
            for(int i = 0; i < generalMatches.Count; i++)
            {
                
            }
            return true;
        }
    }

}
