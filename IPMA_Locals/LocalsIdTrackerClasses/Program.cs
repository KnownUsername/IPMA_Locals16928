using LocalsIdTracker;
using BusinessRules;
using BusinessObjects;
using System;

namespace LocalsIdTrackerClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalsIDMatcher.GetIDLocalsMatch();
            DataAcessForecast.LoadForecast();
            DataAcessForecast.ForecastInputInfo();

            Console.ReadLine();
        }
    }
}
