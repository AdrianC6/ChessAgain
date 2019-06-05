using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Bishop : Piece
    {
        List<string> possibleMoves = new List<string>();
        //ReadInPieces r = new ReadInPieces();
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
            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                PieceInWay(futureX, futureY);
                //r.canPiecesMove(this);
                ReadInPieces.player.Turn(this);
            }
            else
            {
                CanMove = false;
                Console.WriteLine("\nInvalid move pls don't");
            }
        }

        public bool PieceInWay(char futureX, int futureY)
        {
            char currentX;
            int currentY;
            foreach (Piece p in ReadInPieces.AllPieces)
            {
                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX <= 'h' && currentY < 8)
                {
                    currentX += (char)1;
                    currentY += 1;
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX < futureX && currentY < futureY))
                    {
                        Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType}");
                        possibleMoves.Add($"{currentX}{currentY}");
                        return CanMove = false;
                    }
                    else
                    {
                        CanMove = true;
                    }
                }
            }
            foreach (Piece p in ReadInPieces.AllPieces)
            {
                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX >= 'a' && currentY >= 1)
                {
                    currentX -= (char)1;
                    currentY -= 1;
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX > futureX && currentY > futureY))
                    {
                        Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType} at {p.CurrentXCoordinate}{p.CurrentYCoordinate}");
                        return CanMove = false;
                    }
                    else
                    {
                        //possibleMoves.Add($"{currentX}{currentY}");
                        CanMove = true;
                    }
                }
            }
            foreach (string s in possibleMoves)
            {
                Console.WriteLine(s);
            }
            return CanMove;
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
