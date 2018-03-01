using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Reader inReader = new Reader();
            inReader.ReadInputFile();
            string[] outputLines = new string[GlobalObjects.totalVehicles];

            /*Examples! will be deleted*/
            GlobalObjects.vehicle[0].completedRides.Add(1);
            GlobalObjects.vehicle[0].completedRides.Add(5);
            GlobalObjects.vehicle[0].completedRides.Add(13);
            /*Examples! will be deleted*/


            /*Code Here*/




            /*****Writing Output File Starts******/
            /*!!!!!Should Stay at the Bottom!!!!!*/

            for (int i = 0; i < GlobalObjects.totalVehicles; i++)
            {
                outputLines[i] += GlobalObjects.vehicle[i].completedRides.Count().ToString();
                outputLines[i] += " ";

                for (int j = 0; j < GlobalObjects.vehicle[i].completedRides.Count(); j++)
                {
                    outputLines[i] += GlobalObjects.vehicle[0].completedRides[j].ToString();
                    outputLines[i] += " ";
                }
            }

            inReader.WriteOutputFile(outputLines);

            /******Writing Output File Ends*******/
            /*!!!!!Should Stay at the Bottom!!!!!*/
        }
    }
}
