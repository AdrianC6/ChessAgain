using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Rook : Piece
    {
        public Rook()
        {
            this.CanMove = false;
            this.HasMoved = false;
        }

        private int min = 1;
        private int max = 8;

        public Rook(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        public Rook(ChessPieces pieceType, PieceColors color, char currentXCoordinate, char futureXCoordinate, int currentYCoordinate, int futureYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXCoordinate;
            this.FutureXCoordinate = futureXCoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.FutureYCoordinate = futureYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }

        public override void Move(char futureX, int futureY)
        {
            int Ymax = 9;
            int Ymin = 0;
            char Xmax = 'h';
            char Xmin = 'a';

            if((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                CanMove = true;
            }else if((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                CanMove = true;
            }

            for (int i = max; i > min; i--)
            {
                CanMove = false;
                Console.WriteLine("Invalid move u stale end piece of white wonder bread");
            }

            //for (int i = min; i < max; i++)
            //{
            //    if (futureY == i)
            //    {
            //        CurrentYCoordinate = futureY;
            //    }
            //}
            //for (int i = max; i > min; i--)
            //{
            //    if (futureY == i)
            //    {
            //        CurrentYCoordinate = futureY;
            //    }
            //}

        }

        public void SpecialMove()
        {

        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
