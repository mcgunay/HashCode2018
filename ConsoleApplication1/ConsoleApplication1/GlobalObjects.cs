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
        public static  List<Warehouse> warehouseList = new List<Warehouse>();
    }

    public class Warehouse
    {
        public int posX;
        public int posY;
    }

}
