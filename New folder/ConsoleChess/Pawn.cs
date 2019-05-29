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

        //public void determineMove(char futureX, int futureY)
        //{
        //    if((CurrentYCoordinate == 2 && Color == PieceColors.WHITE) || (CurrentYCoordinate == 7 && Color == PieceColors.BLACK))
        //    {
        //        HasMoved = false;
        //    }
        //    if (HasMoved == true)
        //    {
        //        Move(futureX, futureY);
        //    }
        //    else
        //    {
        //        SpecialMove(futureX, futureY);
        //    }
        //}
        public override void Move(char futureX, int futureY)
        {
            Piece piece = null;
            foreach (Piece p in ReadInPieces.AllPieces)
            {
                if (p.CurrentXCoordinate == futureX && p.CurrentYCoordinate == futureY)
                {
                    piece = p;
                }
            }
            if ((CurrentYCoordinate == 2 && Color == PieceColors.WHITE) || (CurrentYCoordinate == 7 && Color == PieceColors.BLACK))
            {
                HasMoved = false;
            }
            else
            {
                HasMoved = true;
                Console.WriteLine("invalid move");
            }
            if (HasMoved == true)
            {
                if (Color == PieceColors.BLACK)
                {
                    if (CurrentXCoordinate == futureX && ((CurrentYCoordinate - 1) == futureY))
                    {
                        CanMove = true;
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
                    }
                    else
                    {
                        CanMove = false;
                    }
                }
            }
            else
            {
                CurrentYCoordinate = Color == PieceColors.WHITE ? CurrentYCoordinate + 2 : CurrentYCoordinate - 2;
            }
        }

        public void SpecialMove(char futureX, int futureY)
        {
            CurrentYCoordinate = Color == PieceColors.WHITE ? CurrentYCoordinate + 2 : CurrentYCoordinate - 2;
        }

        public void capture(Piece p)
        {
            ReadInPieces.AllPieces.Remove(p);
            Console.WriteLine("This piece is captured");
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
