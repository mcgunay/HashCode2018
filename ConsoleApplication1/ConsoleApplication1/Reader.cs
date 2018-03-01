using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Reader
    {
        public void ReadInputFile()
        {
            /*init starts*/
            string[] lines = System.IO.File.ReadAllLines(@"a_example.in");
            string[] bitsInLine = lines[0].Split(' ');
            GlobalObjects.gridX = int.Parse(bitsInLine[0]);
            GlobalObjects.gridY = int.Parse(bitsInLine[1]);
            GlobalObjects.totalVehicles = int.Parse(bitsInLine[2]);
            GlobalObjects.totalRides = int.Parse(bitsInLine[3]);
            GlobalObjects.bonus = int.Parse(bitsInLine[4]);
            GlobalObjects.totalSteps = int.Parse(bitsInLine[5]);

            for (int i = 0; i < GlobalObjects.totalVehicles; i++)
            {
                GlobalObjects.vehicle.Add(new Vehicle());
            }

            for (int i = 0; i < GlobalObjects.totalRides; i++)
            {
                GlobalObjects.ride.Add(new Ride());
            }

            for(int i = 0; i < GlobalObjects.totalRides; i++)
            {
                bitsInLine = lines[i + 1].Split(' ');
                GlobalObjects.ride[i].Id = i;
                GlobalObjects.ride[i].startX = int.Parse(bitsInLine[0]);
                GlobalObjects.ride[i].startY = int.Parse(bitsInLine[1]);
                GlobalObjects.ride[i].destX = int.Parse(bitsInLine[2]);
                GlobalObjects.ride[i].destY = int.Parse(bitsInLine[3]);
                GlobalObjects.ride[i].earliestStart = int.Parse(bitsInLine[4]);
                GlobalObjects.ride[i].latestFinish = int.Parse(bitsInLine[5]);
                GlobalObjects.ride[i].CalculateDistance();
            }

            /*init ends*/
        }

        public void WriteOutputFile(string[] lines)
        {
            System.IO.File.WriteAllLines(@"output.txt", lines);
        }
 
        
        
         
    }
}
