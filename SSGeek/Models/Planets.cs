using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class Planets
    {
        public static List<SelectListItem> TransportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };

        public static Dictionary<string, double> PlanetWeightDictionary = new Dictionary<string, double>
        {
            {"Mercury", 0.37},
            {"Venus", 0.90},
            {"Mars", 0.38},
            {"Jupiter", 2.65},
            {"Saturn", 1.13},
            {"Uranus", 1.09},
            {"Neptune", 1.43},
        };
        public static Dictionary<string, double> PlanetAgeDictionary = new Dictionary<string, double>()
        {
            {"Mercury", 0.2408},
            {"Venus", 0.6151},
            {"Mars", 1.88},
            {"Jupiter", 11.862},
            {"Saturn", 29.456},
            {"Uranus", 84.07},
            {"Neptune", 164.81},
        };
        public static Dictionary<string, double> PlanetDistanceDictionary = new Dictionary<string, double>
        {
            {"Mercury", 56974146},
            {"Venus", 25724767},
            {"Mars", 48678219},
            {"Jupiter", 390674710},
            {"Saturn", 792248270},
            {"Uranus", 1692662530},
            {"Neptune", 2703959960},
        };
        public static Dictionary<string, double> TransportSpeedDictionary = new Dictionary<string, double>
        {
            {"walking", 3},
            {"car", 100},
            {"bullet train", 200},
            {"boeing 747", 570},
            {"concorde", 1350},  
        };

        public static double ConvertWeight(string planetName, double earthWeight)
        {
            double result = earthWeight * (PlanetWeightDictionary[planetName]);
            return result;
        }

        public static double ConvertAge(string planetName, int earthYears)
        {
            double result = earthYears / (PlanetAgeDictionary[planetName]);
            return result;
        }
        public static double CalculateTravelTime(string planetName, string transport)
        {
            double result = (PlanetDistanceDictionary[planetName]) / (TransportSpeedDictionary[transport]) 
                / 24 / 365.26;
            return result;
        }
        public static double CalculateArrivalAge(int earthAge, double distanceTime)
        {
            double result = earthAge + distanceTime;
            return result;
        }

    }
}