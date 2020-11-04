/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: Forecast 
    Aim: Defines 2 forecast classes, prevision of meteorology
            -> [Forecast] Original one (obtained from file)
            -> [ForecastWithLocal] Edited one (local addition to original Forecast)
 */
using System;

namespace BusinessObjects
{
    /// <summary>
    /// Class of a forecast
    /// </summary>
    [Serializable]
    public class ForecastBO
    {
        #region ATTRIBUTES
        string owner;
        string country;

        #endregion

        #region CONSTRUCTORS
        public string Owner { get { return owner; } set { owner = value; } }
        public string Country { get { return country; } set { country = value; } }
        #endregion
    }

    [Serializable]
    /// <summary>
    /// Forecast class with local included
    /// </summary>
    public class ForecastNLocalBO
    {
        public ForecastBO forecast = new ForecastBO();
        string local;

        public string Local { get { return local; } set { local = value; } }
    }
}