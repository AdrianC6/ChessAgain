using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Pawn : Piece
    {
        public Pawn()
        {
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

        //public void determineMove()
        //{
        //    if (HasMoved)
        //    {
        //        Move();
        //    }
        //    else
        //    {
        //        SpecialMove();
        //    }
        //}
        public override void Move(char futureX, int futureY)
        {
            if ((CurrentYCoordinate == 2 && this.Color == PieceColors.WHITE) || (CurrentYCoordinate == 7 && this.Color == PieceColors.BLACK))
            {
                HasMoved = false;
            }
            else
            {
                HasMoved = true;
            }

            if (Color == PieceColors.BLACK)
            {

                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate - 1) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else if (HasMoved == false)
                {
                    SpecialMove(futureX, futureY);
                }
                else
                {
                    CanMove = false;
                }

            }
            else
            {
                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate + 1) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else if (HasMoved == false)
                {
                    SpecialMove(futureX, futureY);
                }
                else
                {
                    CanMove = false;
                }
            }
        }

        public void SpecialMove(char futureX, int futureY)
        {
            if (this.Color == PieceColors.BLACK)
            {

                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate - 2) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else
                {
                    CanMove = false;
                }
            }
            else
            {
                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate + 2) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else
                {
                    CanMove = false;
                }
            }
        }

        public override bool PieceInWay(char futureX, int futureY)
        {
            if ((CurrentYCoordinate == 2 && this.Color == PieceColors.WHITE) || (CurrentYCoordinate == 7 && this.Color == PieceColors.BLACK))
            {
                HasMoved = false;
            }
            else
            {
                HasMoved = true;
            }

            if (Color == PieceColors.BLACK)
            {

                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate - 1) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else if (HasMoved == false)
                {
                    SpecialMove(futureX, futureY);
                }
                else
                {
                    CanMove = false;
                    Console.WriteLine("I don't move that way, hoe");
                }

            }
            else
            {
                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate + 1) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else if (HasMoved == false)
                {
                    SpecialMove(futureX, futureY);
                }
                else
                {
                    CanMove = false;
                    Console.WriteLine("I don't move that way, hoe");
                }

            }

            if (this.Color == PieceColors.BLACK)
            {

                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate - 2) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else
                {
                    CanMove = false;
                }
            }
            else
            {
                if (CurrentXCoordinate == futureX && ((CurrentYCoordinate + 2) == futureY))
                {
                    CanMove = true;
                    ReadInPieces.player.Turn(this);
                }
                else
                {
                    CanMove = false;
                }
            }
            return CanMove;
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
