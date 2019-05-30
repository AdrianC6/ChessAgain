using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Pawn : Piece
    {
        public Pawn() {
            this.CanMove = true;
            this.HasMoved = false;
        }
        public Pawn(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        public Pawn(ChessPieces pieceType, PieceColors color, char currentXCoordinate, char futureXCoordinate, int currentYCoordinate, int futureYCoordinate, bool canMove, bool hasMoved)
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
            if (Color == PieceColors.BLACK)
            {
                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate - 1) == FutureYCoordinate))
                {
                    CanMove = true;
                }
                else
                {
                   this.CurrentYCoordinate = CurrentYCoordinate;
                    CanMove = false;
                    Console.WriteLine("I don't move tthat way, hoe");
                }

            }
            else
            {
                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate + 1) == FutureYCoordinate))
                {
                    CanMove = true;
                }
                else
                {
                    this.CurrentYCoordinate = CurrentYCoordinate;
                    CanMove = false;
                    Console.WriteLine("I don't move tthat way, hoe");
                }
            }
        }

        public void SpecialMove()
        {
            CurrentYCoordinate = Color == PieceColors.WHITE? CurrentYCoordinate + 2 : CurrentYCoordinate - 2;
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
