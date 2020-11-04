/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: Weather
    Aim: Define a weather state, with some information 
 */
using System;

namespace BusinessObjects
{
    /// <summary>
    /// Weather on it's original state
    /// </summary>
    /// <need>
    /// Its use, is for possible need to edit content
    /// </need>
    public class Weather
    {
        #region ATTRIBUTES
        float precipitaProb;
        float tMin;
        float tMax;
        string predWindDir;
        int idWeatherType;
        int classWindSpeed;
        float longitude;
        DateTime forecastDate;
        int classPrecInt;
        float latitude;
        #endregion

        #region CONSTRUCTORS
        public float PrecipitaProb { get { return precipitaProb; } set { precipitaProb = value; } }
        public float Tmin { get { return tMin; } set { tMin = value; } }
        public float Tmax { get { return tMax; } set { tMax = value; } }
        public string PredWindDir { get { return predWindDir; } set { predWindDir = value; } }
        public int IdWeatherType { get { return idWeatherType; } set { idWeatherType = value; } }
        public int ClassWindSpeed { get { return classWindSpeed; } set { classWindSpeed = value; } }
        public float Longitude { get { return longitude; } set { longitude = value; } }
        public DateTime ForecastDate { get { return forecastDate; } set { forecastDate = value; } }
        public int ClassPrecInt { get { return classPrecInt; } set { classPrecInt = value; } }
        public float Latitude { get { return latitude; } set { latitude = value; } }
        #endregion
    }

    /// <summary>
    /// Weather on format to be saved
    /// </summary>
    /// <constraints>
    /// If a new attribute is joined to the original class, it has to be added also here
    /// </constraints>
    public class WeatherToSave
    {
        #region ATTRIBUTES
        string precipitaProb;
        string tMin;
        string tMax;
        string predWindDir;
        int idWeatherType;
        int classWindSpeed;
        string longitude;
        string forecastDate;
        int classPrecInt;
        string latitude;
        #endregion

        #region CONSTRUCTORS
        public string PrecipitaProb { get { return precipitaProb; } set { precipitaProb = value; } }
        public string Tmin { get { return tMin; } set { tMin = value; } }
        public string Tmax { get { return tMax; } set { tMax = value; } }
        public string PredWindDir { get { return predWindDir; } set { predWindDir = value; } }
        public int IdWeatherType { get { return idWeatherType; } set { idWeatherType = value; } }
        public int ClassWindSpeed { get { return classWindSpeed; } set { classWindSpeed = value; } }
        public string Longitude { get { return longitude; } set { longitude = value; } }
        public string ForecastDate { get { return forecastDate; } set { forecastDate = value; } }
        public int ClassPrecInt { get { return classPrecInt; } set { classPrecInt = value; } }
        public string Latitude { get { return latitude; } set { latitude = value; } }
        #endregion
    }
}
