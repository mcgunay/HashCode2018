using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GlobalObjects
    {
        public static int gridX;
        public static int gridY;
        public static int totalVehicles;
        public static int totalRides;
        public static int bonus;
        public static int totalSteps;

        public static List<Ride> ride = new List<Ride>();
        public static List<Vehicle> vehicle = new List<Vehicle>();
    }

    public class Ride
    {
        public int startX;
        public int startY;
        public int destX;
        public int destY;
        public int earliestStart;
        public int latestFinish;
        public bool isAssigned = false;
    }
    public class Vehicle
    {
        public int currentX = 0;
        public int currentY = 0;
        public bool isBusy = false;
        public List<int> completedRides = new List<int>();
    }

}
