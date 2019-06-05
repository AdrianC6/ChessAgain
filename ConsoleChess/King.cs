using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class King : Piece
    {
        public King()
        {
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

        public override void Move(char futureX, int futureY)
        {
            if (Math.Abs(CurrentYCoordinate - futureY) <= 1 && Math.Abs(CurrentXCoordinate - futureX) <= 1)
            {
                if (Math.Abs(CurrentYCoordinate - futureY) == 1 || Math.Abs(CurrentXCoordinate - futureX) == 1)
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
                CanMove = false;
                Console.WriteLine("Invalid move pls don't");
            }
        }

        public bool PieceInWay(char futureX, int futureY)
        {
            bool check = false;
            if (Math.Abs(CurrentYCoordinate - futureY) <= 1 && Math.Abs(CurrentXCoordinate - futureX) <= 1)
            {
                if (Math.Abs(CurrentYCoordinate - futureY) == 1 || Math.Abs(CurrentXCoordinate - futureX) == 1)
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
                CanMove = false;
            }
            return check;
        }

        public bool IsInCheck()
        {
            bool inCheck = false;
            for (int i = 1; i < 9; i++)
            {
                char x = this.CurrentXCoordinate;
                int y = this.CurrentYCoordinate;
                x += (char)1;
                if (x >= 'a' && x <= 'h')
                {
                    foreach (Piece p in ReadInPieces.AllPieces)
                    {
                        if (p.CurrentXCoordinate == x && p.Color != this.Color)
                        {
                            inCheck = true;
                            break;
                        }
                        else
                        {
                            inCheck = false;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                int x = this.CurrentXCoordinate;
                int y = this.CurrentYCoordinate;
                y += 1;
                if (y >= 1 || y <= 8)
                {
                    foreach (Piece p in ReadInPieces.AllPieces)
                    {
                        if (p.CurrentYCoordinate == y && p.Color != this.Color)
                        {
                            inCheck = true;
                            break;
                        }
                        else
                        {
                            inCheck = false;
                        }
                    }
                }
            }
            return inCheck;
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
