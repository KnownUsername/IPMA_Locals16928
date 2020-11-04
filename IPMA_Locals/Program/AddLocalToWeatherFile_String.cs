/*
    Name: João Rodrigues
    Student no.: 16928
    University: IPCA
    Subject: Integration of Informatic Sistems
    Objective: Manipulate informations from IPMA's metereology
    Created at: 28/10/20
    
    Class: AddLocalToWeatherFile_String
    Aim: Add local to a weather file, based on its id, present on globalIdLocal
 */
using BusinessRules;
using System;
namespace Program
{
    /// <summary>
    /// Takes a weather file, and add its location, based on globalIdLocal
    /// </summary>
    class AddLocalToWeatherFile_String
    {
        static void Main(string[] args)
        {

            // Test loading of file
            if (DataAcessLocals.LoadDistrits()) Console.WriteLine("File loaded sucessfuly!");
            else Console.WriteLine("Couldn't load desired file.");

            DataAcessLocals.GetLocals(); // Matches locals with their id
            DataAcessWeather.LoadWeather(); // Loads weather file
            DataAcessWeather.AddLocalToWeatherFile(); // Adds local to weather file, based on its id
            Console.ReadKey();
        }
    }
}