/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: DataAcess 
    Aim: Intermediary class between user and data functions / Allows external use of data functions
 */
using Data;

namespace BusinessRules
{
    /// <summary>
    /// Acessment to locals data
    /// </summary>
    public static class DataAcessLocals
    {

        /// <summary>
        /// Makes it accessible to load districts source file 
        /// </summary>
        /// <returns></returns>
        public static bool LoadDistrits()
        {
            return LocalsInfoManipulation.FileLoader();
        }

        /// <summary>
        /// Makes it accesible to generate Locals
        /// </summary>
        public static bool GetLocals()
        {
            return LocalsInfoManipulation.GetLocalsMatches();
        }

        /// <summary>
        /// Shows all locals obtained
        /// </summary>
        public static void ShowLocalsList()
        {
            Locals.ShowList();
        }
    }
    
    /// <summary>
    /// Acessment to weather data
    /// </summary>
    public static class DataAcessWeather
    {
        /// <summary>
        /// Makes it accessible to load weather source file
        /// </summary>
        public static bool LoadWeather()
        {
            return WeatherInfoManipulation.FileLoader();
        }

        /// <summary>
        /// Allows to add the local to chosen weather file
        /// </summary>
        /// <returns></returns>
        public static bool AddLocalToWeatherFile()
        {
            return WeatherInfoManipulation.AddLocalToWeatherFile();
        }
    }
    
    /// <summary>
    /// Acessment to forecast data
    /// </summary>
    public static class DataAcessForecast
    {
        /// <summary>
        /// Makes it accesible to load forecast source file
        /// </summary>
        /// <returns></returns>
        public static bool LoadForecast()
        {
            return ForecastInfoManipulation.FileLoader();
        }

        /// <summary>
        /// Passes values to class object
        /// </summary>
        /// <returns></returns>
        public static bool ForecastInputInfo()
        {
            return ForecastInfoManipulation.GatherInfo();
        }
    }

}
