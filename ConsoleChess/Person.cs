using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Person
    {
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
            if(p.Color == Piece.PieceColors.WHITE)
            {
                //turn logic
            }
            else if(p.Color == Piece.PieceColors.BLACK)
            {
                //turn logic
            }
        }
    }
}
