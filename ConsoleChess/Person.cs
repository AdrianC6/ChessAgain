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
        Piece.PieceColors Color;
        public Person()
        {

        }

        public Person(Piece.PieceColors colors)
        {
            this.Color = colors;
        }

        public void Turn(Piece p)
        {
            p.CanMove = true;
            if (p.Color == Piece.PieceColors.WHITE)
            {
                //turn logic
                if (p.CanMove == true && turn == 1)
                {
                    turn += 1;
                }
                else
                {
                    turn = 1;
                    p.CanMove = false;
                }
            }
            else if (p.Color == Piece.PieceColors.BLACK)
            {
                //turn logic
                if (p.CanMove == true && turn == 2)
                {
                    turn -= 1;
                }
                else
                {
                    turn = 2;
                    p.CanMove = false;
                }
            }
        }
    }
}
