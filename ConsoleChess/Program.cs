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
            string file = "C:\\Users\\ACastellon\\source\\repos\\ConsoleChess\\ConsoleChess\\bin\\Debug\\2.0.txt";
            ReadInPieces pieced = new ReadInPieces();
            pieced.run(file);
            //pieced.run(args[0]);
            ChessGame chessy = new ChessGame();
            chessy.GenerateBoard();
            //Console.ReadLine();
        }
    }
}
