using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Bishop : Piece
    {
        public Bishop()
        {
            this.CanMove = false;
            this.HasMoved = false;
        }

        public Bishop(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        public Bishop(ChessPieces pieceType, PieceColors color, char currentXCoordinate, char futureXCoordinate, int currentYCoordinate, int futureYCoordinate, bool canMove, bool hasMoved)
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

        private int min = 1;
        private int max = 8;

        public override void Move(char futureX, int futureY)
        {
            //int Ymin = 0;
            //int Ymax = 9;
            //char Xmin = 'a';
            //char Xmax = 'h';
            
            if (Math.Abs(((double)CurrentYCoordinate - futureY)/(CurrentXCoordinate - futureX)) == 1)
            {
                CanMove = true;
            }

            for (int i = max; i > min; i--)
            {
                CanMove = false;
            }








            //if ((CurrentXCoordinate + 1 == futureX && CurrentYCoordinate + 1 == futureY))
            //{
            //    CanMove = true;
            //}
            //else if ((CurrentXCoordinate - 1 == futureX && CurrentYCoordinate - 1 == futureY))
            //{
            //    CanMove = true;
            //}
            //else if ((CurrentXCoordinate - 1 == futureX && CurrentYCoordinate + 1 == futureY))
            //{
            //    CanMove = true;
            //}
            //else if ((CurrentXCoordinate + 1 == futureX && CurrentYCoordinate - 1 == futureY))
            //{
            //    CanMove = true;
            //}
            //else
            //{
            //    CanMove = false;
            //}
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
