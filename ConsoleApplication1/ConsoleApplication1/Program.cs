using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader inReader = new Reader();
            string[] outputLines = { "google", "hash", "2018" };

            inReader.ReadInputFile();

            GlobalObjects.gridX = GlobalObjects.gridY;


            inReader.WriteOutputFile(outputLines);

        }
    }
}
