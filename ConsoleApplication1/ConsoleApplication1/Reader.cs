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
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\z003wknx\Desktop\qualification_round_2016.in\busy_day.in");
            string[] bitsInLine = lines[0].Split(' ');
            GlobalObjects.gridX = int.Parse(bitsInLine[0]);
            GlobalObjects.gridY = int.Parse(bitsInLine[1]);
            int warehouseCount = int.Parse(bitsInLine[2]);

            for (int i = 0; i < warehouseCount; i++)
                GlobalObjects.warehouseList.Add(new Warehouse());

            GlobalObjects.warehouseList[0].posX = int.Parse(bitsInLine[3]);
            GlobalObjects.warehouseList[0].posY = int.Parse(bitsInLine[4]);
        }

        public void WriteOutputFile(string[] lines)
        {
            System.IO.File.WriteAllLines(@"C:\Users\z003wknx\Desktop\googleHash2018\output.txt", lines);
        }
 
        
        
         
    }
}
