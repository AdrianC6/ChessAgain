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
            //string file = "C:\\Users\\ACastellon\\source\\repos\\ConsoleChess\\ConsoleChess\\bin\\Debug\\NoPawns.txt";
<<<<<<< HEAD
            //ReadInPieces pieced = new ReadInPieces();
            // pieced.run(file);
            //pieced.run(args[0]);
            GameMenu g = new GameMenu();
            g.GameStart();
=======
            ReadInPieces pieced = new ReadInPieces();
           // pieced.run(file);
          pieced.run(args[0]);
>>>>>>> parent of 2eda1e2... 6/5
        }
    }
}
