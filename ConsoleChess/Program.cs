using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "KingCheck.txt";
            ReadInPieces pieced = new ReadInPieces();
            pieced.run(file);
            //pieced.run(args[0]);
        }
    }
}
