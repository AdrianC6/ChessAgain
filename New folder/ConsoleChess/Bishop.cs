using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Bishop : Piece
    {
        Person player = new Person();
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

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                CanMove = true;
                if (this != null)
                {
                    if (piece == null)
                    {
                        CanMove = true;
                        ReadInPieces.player.Turn(this);
                        if (!CanMove)
                        {
                        }
                        else
                        {
                            Console.WriteLine($"\n\n{this.ToString()}");
                            CurrentXCoordinate = futureX;
                            CurrentYCoordinate = futureY;
                        }
                    }
                    else if (piece.Color != this.Color)
                    {
                        CanMove = true;
                        ReadInPieces.player.Turn(this);
                        if (!CanMove)
                        {
                        }
                        else
                        {
                            Console.WriteLine($"\n\n{this.ToString()}");
                            CurrentXCoordinate = futureX;
                            CurrentYCoordinate = futureY;
                            capture(piece);
                            ReadInPieces.AllPieces.Remove(piece);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nCan't take own pieces");
                        CanMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("No piece there");
                }
            }
            else
            {
                CanMove = false;
            }
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
