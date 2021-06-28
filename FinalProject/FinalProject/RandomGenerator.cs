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

        public static int GetRandomElement()
        {
            Random rnd = new Random();
            var db = new ProjectFinalV2Context();
            var placeList = db.Places
                .ToList();
            int index = rnd.Next(placeList.Count);

            var newPlace =  placeList[index];
            
            return newPlace.Id; 
        }
        
        public static int GetRandomCabin()
        {
            Random rnd = new Random();
            var db = new ProjectFinalV2Context();
            var cabinList = db.Cabins
                .ToList();
            int index = rnd.Next(cabinList.Count);

            var newPlace = cabinList[index];
            
            return newPlace.Id; 
        }
    }
    
}