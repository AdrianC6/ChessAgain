using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Queen : Piece
    {
        public Queen()
        {
            this.CanMove = false;
            this.HasMoved = false;
        }

        public Queen(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        public Queen(ChessPieces pieceType, PieceColors color, char currentXCoordinate, char futureXCoordinate, int currentYCoordinate, int futureYCoordinate, bool canMove, bool hasMoved)
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
            int Ymin = 0;
            int Ymax = 9;
            char Xmin = 'a';
            char Xmax = 'h';
            if ((futureX % 2 == 1 && futureY % 2 == 1) || (futureX % 2 == 0 && futureY % 2 == 0))
            {
                CanMove = true;
            }
            else if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                CanMove = true;
            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                CanMove = true;
            }
            else
            {
                CanMove = false;
            }
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
