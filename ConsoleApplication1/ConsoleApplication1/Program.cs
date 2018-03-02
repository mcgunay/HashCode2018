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

            string[] InputPaths = {"a_example.in", "b_should_be_easy.in", "c_no_hurry.in", "d_metropolis.in", "e_high_bonus.in" };
            string[] OutputPaths = {"a_example_output.txt", "b_should_be_easy_output.txt", "c_no_hurry_output.txt", "d_metropolis_output.txt", "e_high_bonus_output.txt" };

            for (int i = 0; i < InputPaths.Length; i++)
            {
                Console.WriteLine("Operation is started for input file: " + InputPaths[i]);
                DateTime StartTime = DateTime.Now;

                Run(InputPaths[i], OutputPaths[i]);

                DateTime EndTime = DateTime.Now;
                Console.WriteLine("Output file is created for " +InputPaths[i] + " inputs in " + (EndTime - StartTime).TotalSeconds+ " seconds.");
                Console.WriteLine("------------------------------------------------------------");
            }

            Console.WriteLine("Press any key for exit.");
            Console.ReadLine();

        }

        public static void Run(string inputPath, string outputPath)
        {
            GlobalObjects.vehicle = new List<Vehicle>();
            GlobalObjects.ride = new List<Ride>();
            GlobalObjects.currentStep = 0;

            Reader inReader = new Reader(inputPath, outputPath);
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
