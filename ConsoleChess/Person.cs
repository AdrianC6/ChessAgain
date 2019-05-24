using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Person
    {
        int turn = 1;

        public void Turn(Piece p)
        {
            if (p.Color == Piece.PieceColors.WHITE)
            {
                //turn logic
                if (p.CanMove == true && turn == 1)
                {
                    turn = 2;
                }
                else
                {
                    p.CanMove = false;
                    Console.WriteLine("\nNot your turn light team");
                }
            }
            else if (p.Color == Piece.PieceColors.BLACK)
            {
                //turn logic
                if (p.CanMove == true && turn == 2)
                {
                    turn = 1;
                }
                else
                {
                    p.CanMove = false;
                    Console.WriteLine("\nNot your turn dark team");
                }
            }
        }
    }
}
