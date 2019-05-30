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

            if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                //CanMove = true;
                PieceInWay(futureX, futureY);
                //ReadInPieces.chessy.GenerateBoard();

            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                //CanMove = true;
                PieceInWay(futureX, futureY);
                //ReadInPieces.chessy.GenerateBoard();

            }

            for (int i = max; i > min; i--)
            {
                CanMove = false;
                Console.WriteLine("Invalid move u stale end piece of white wonder bread");
            }

        }

        public void SpecialMove()
        {

        }

        public bool PieceInWay(char futureX, int futureY)
        {
            char currentX;
            int currentY;
            foreach (Piece p in ReadInPieces.AllPieces)
            {
                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;

                if ((p.CurrentXCoordinate > this.CurrentXCoordinate && p.CurrentXCoordinate < this.FutureXCoordinate) && p.CurrentYCoordinate == futureY)
                {
                    CanMove = false;
                    Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType} and cannot move");
                    break;
                }
                else if ((p.CurrentYCoordinate > this.CurrentYCoordinate && p.CurrentYCoordinate < this.FutureYCoordinate) && p.CurrentXCoordinate == futureX)
                {
                    CanMove = false;
                    Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType} and cannot move");
                    break;
                }
                else if ((p.CurrentXCoordinate < this.CurrentXCoordinate && p.CurrentXCoordinate > this.FutureXCoordinate) && p.CurrentYCoordinate == futureY)
                {
                    CanMove = false;
                    Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType} and cannot move");
                    break;
                }
                else if ((p.CurrentYCoordinate < this.CurrentYCoordinate && p.CurrentYCoordinate > this.FutureYCoordinate) && p.CurrentXCoordinate == futureX)
                {
                    CanMove = false;
                    Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType} and cannot move");
                    break;
                }
                else
                {
                    CanMove = true;
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
