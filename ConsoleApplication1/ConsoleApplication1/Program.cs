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

            List<Ride> SortedRideList = GlobalObjects.GetSortedRides(GlobalObjects.vehicle[0].currentX, GlobalObjects.vehicle[0].currentY);
            for (int i = 0; i < GlobalObjects.vehicle.Count; i++)
            {
                GlobalObjects.vehicle[i].AssignRide(SortedRideList[i]);
            }

            /*Code Here*/
            while (GlobalObjects.totalSteps >= GlobalObjects.currentStep)
            {
                for (int i = 0; i < GlobalObjects.vehicle.Count; i++)
                {
                    GlobalObjects.vehicle[i].Move();
                    if (GlobalObjects.vehicle[i].totalTurnLeftToTarget == 0)
                    {
                        GlobalObjects.vehicle[i].CompleteRide();
                    }
                }
                List<Vehicle> AvailableVehicles = GlobalObjects.vehicle.Where(s => s.isBusy == false).ToList();
                for (int i = 0; i < AvailableVehicles.Count; i++)
                {
                    SortedRideList =
                        GlobalObjects.GetSortedRides(AvailableVehicles[i].currentX, AvailableVehicles[i].currentY);
                    if (SortedRideList.Count == 0)
                        break; 

                    Ride AvailableRide = SortedRideList
                        .FirstOrDefault(s => AvailableVehicles[i].IsRideAvailable(s));
                    if (AvailableRide == null)
                        continue;
                    AvailableVehicles[i].AssignRide(AvailableRide);
                    //SortedRideList.Remove(AvailableRide);

                }

                GlobalObjects.currentStep++;


            }



            /*****Writing Output File Starts******/
            /*!!!!!Should Stay at the Bottom!!!!!*/

            for (int i = 0; i < GlobalObjects.totalVehicles; i++)
            {
                outputLines[i] += GlobalObjects.vehicle[i].completedRides.Count().ToString();
                outputLines[i] += " ";

                for (int j = 0; j < GlobalObjects.vehicle[i].completedRides.Count(); j++)
                {
                    outputLines[i] += GlobalObjects.vehicle[i].completedRides[j].ToString();
                    outputLines[i] += " ";
                }
            }

            inReader.WriteOutputFile(outputLines);

            /******Writing Output File Ends*******/
            /*!!!!!Should Stay at the Bottom!!!!!*/
        }
    }
}
