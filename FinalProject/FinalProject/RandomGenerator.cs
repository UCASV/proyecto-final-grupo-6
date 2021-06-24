using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using FinalProject.ProjectContext;


namespace FinalProject
{
    public static class RandomGenerator
    {
        public static DateTime GetRandomDate()
        {
            return DateTime.Now.AddDays(new Random().Next(1000));
        }

        public static DateTime GetRandomTime()
        {
            DateTime start = DateTime.Today.AddHours(8);
            Random rnd = new Random();
            
            DateTime newTime = start.AddMinutes(rnd.Next(601));

            return newTime;

        }

        public static int GetRandomElement(List<Place> newList)
        {
            Random rnd = new Random();
            var db = new ProjectFinalV2Context();
            var placeList = db.Places
                .ToList();
            int index = rnd.Next(newList.Count);

            var newPlace = ((Place) newList[index]);
            
            return newPlace.Id; 
        }
    }
    
}