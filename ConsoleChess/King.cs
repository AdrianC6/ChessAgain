using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class King : Piece
    {

        public King() {
            this.CanMove = false;
            this.HasMoved = false;
        }

        public King(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        public King(ChessPieces pieceType, PieceColors color, char currentXCoordinate, char futureXCoordinate, int currentYCoordinate, int futureYCoordinate, bool canMove, bool hasMoved)
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

        public override void Move(char futureX, int futureY, string[,] board)
        {
            string space = (board[futureX, futureY]);
            char color = space[1];

            //What is happening here is it is checking to see if the move is in the range of the kings movement and based on that it will determin if it can move based on the state of the board

            if (CurrentXCoordinate + 1 == futureX && CurrentYCoordinate == futureY || CurrentXCoordinate - 1 == futureX && CurrentYCoordinate == futureY ||
                CurrentXCoordinate == futureX && CurrentYCoordinate + 1 == futureY || CurrentXCoordinate == futureX && CurrentYCoordinate - 1 == futureY ||
                CurrentXCoordinate + 1 == futureX && CurrentYCoordinate + 1 == futureY || CurrentXCoordinate - 1 == futureX && CurrentYCoordinate - 1 == futureY ||
                CurrentXCoordinate + 1 == futureX && CurrentYCoordinate - 1 == futureY || CurrentXCoordinate - 1 == futureX && CurrentYCoordinate + 1 == futureY)
            {
                if (board.GetValue(futureX, futureY).Equals("[-]")) //Checks is the space is open
                {
                    CanMove = true;
                }
                else if (color > 64 && color < 91) //Checks if the space on the board is white
                {
                    Piece futurePlace = new Pawn(ChessPieces.P, PieceColors.WHITE, futureX, futureY, false, false);

                    if (futurePlace.Color == this.Color) //If the colors match it can't move
                    {
                        CanMove = false;
                    }
                    else
                    {
                        CanMove = true;
                    }

                }
                else if (color > 96 && color < 123) //Checks if the space on the board is black
                {
                    Piece futurePlace = new Pawn(ChessPieces.P, PieceColors.BLACK, futureX, futureY, false, false);

                    if (futurePlace.Color == this.Color) //If the colors match it can't move
                    {
                        CanMove = false;
                    }
                    else
                    {
                        CanMove = true;
                    }
                }
                else //Redundant Failing
                {
                    CanMove = false;
                }
            }
            else //Redundant Failing 
            {
                CanMove = false;
            }
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
