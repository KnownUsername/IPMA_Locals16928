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
using BusinessObjects;

namespace Data
{
    /// <summary>
    /// Class of forecast with list of weather
    /// </summary>
    public class ForecastTyped
    {
        #region ATTRIBUTES
        public ForecastNLocalBO forecastLocal; // BO version of ForestNLocal
        //      Lists of 5 days of weather
        public static List<Weather> dataTyped; // data with types (float,DateTime)
        #endregion

        #region METHODS
        public static List<Weather> GetDataTypedList()
        {
            return dataTyped;
        }
        #endregion

        #region CONSTRUCTOR
        public ForecastTyped()
        {
            forecastLocal = new ForecastNLocalBO();
            dataTyped = new List<Weather>();
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

        /// <summary>
        /// Updates list data with dataTyped values
        /// </summary>
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
    /// Manipulates forecast files
    /// </summary>
    public static class ForecastInfoManipulation {
        #region ATTRIBUTES
        static string originalData;
        static string forecastFilePath = "..\\..\\..\\..\\1010500.json";
        #endregion

        #region METHODS
        /// <summary>
        /// Gathers all data 
        /// </summary>
        /// <returns></returns>
        public static bool GatherInfo()
        {

            string generalRegularExpression; // wil contain regular expression for fields match
            int intValue; // aux variable for id's int parse
            DateTime auxDate;

            try
            {
                // Regular expression for locals (Names)
                generalRegularExpression = "\"([a-zA-Z]+)\":[\"]?([^\\[][a-zA-z0-9\\.:-]*)[\"]?";
                Regex regexObjId = new Regex(generalRegularExpression);
            }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception e) { throw e; }

            /*  Storage of matches obtained from ids and locals    */
            MatchCollection generalMatches = Regex.Matches(originalData, generalRegularExpression); // getting local matches

            Console.WriteLine("");
            ForecastTyped forecastTyped = new ForecastTyped();

            forecastTyped.forecastLocal.forecast.Owner = generalMatches[0].Groups[2].Value;
            forecastTyped.forecastLocal.forecast.Country = generalMatches[1].Groups[2].Value;
            int j = 0;
            float auxFloatVal;

            // Cycle to introduce values into locals' list

            for (int i = 2; i < generalMatches.Count; i++)
            {
                // precipitaProb
                float.TryParse(generalMatches[i].Groups[2].Value, out auxFloatVal);
                ForecastTyped.dataTyped[j].PrecipitaProb = auxFloatVal;
                i++;

                // tMin
                float.TryParse(generalMatches[i].Groups[2].Value, out auxFloatVal);
                ForecastTyped.dataTyped[j].Tmin = auxFloatVal;
                i++;

                // tMax
                float.TryParse(generalMatches[i].Groups[2].Value, out auxFloatVal);
                ForecastTyped.dataTyped[j].Tmax = auxFloatVal;
                i++;

                // predWindDir
                ForecastTyped.dataTyped[j].PredWindDir = generalMatches[i].Groups[2].Value;
                i++;

                // idWeatherType
                Int32.TryParse(generalMatches[i].Groups[2].Value, out intValue);
                ForecastTyped.dataTyped[j].IdWeatherType = intValue;
                i++;

                // classWindSpeed
                Int32.TryParse(generalMatches[i].Groups[2].Value, out intValue);
                ForecastTyped.dataTyped[j].ClassWindSpeed = intValue;
                i++;

                // longitude
                float.TryParse(generalMatches[i].Groups[2].Value, out auxFloatVal);
                ForecastTyped.dataTyped[j].Longitude = auxFloatVal;
                i++;

                // forecastDate
                DateTime.TryParse(generalMatches[i].Groups[2].Value, out auxDate);
                ForecastTyped.dataTyped[j].ForecastDate = auxDate;
                i++;

                if (generalMatches[i].Groups[1].Value == "classPrecInt")
                {
                    // classPrecInt
                    Int32.TryParse(generalMatches[i].Groups[2].Value, out intValue);
                    ForecastTyped.dataTyped[j].ClassPrecInt = intValue;
                    i++;
                }

                // latitude
                float.TryParse(generalMatches[i].Groups[2].Value, out auxFloatVal);
                ForecastTyped.dataTyped[j].Latitude = auxFloatVal;

            }
            return true;
        }

        /// <summary>
        /// Loads a data from a forecast file
        /// </summary>
        /// <returns></returns>
        public static bool FileLoader()
        {
            originalData = JsonFilesManipulation.FileLoader(forecastFilePath); // Load of forecast's file by generic json file loader
            if (originalData != null) return true;
            return false;
        }

        #endregion
    }

}
