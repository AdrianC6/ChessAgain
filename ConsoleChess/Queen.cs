﻿using System;
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

        private int min = 1;
        private int max = 8;

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

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                //CanMove = true;
                PieceInWayDiagonal(futureX, futureY);
                ReadInPieces.player.Turn(this);
            }
            else if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                //CanMove = true;
                PieceInWayHorizontal(futureX, futureY);
                ReadInPieces.player.Turn(this);
            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                //CanMove = true;
                PieceInWayHorizontal(futureX, futureY);
                ReadInPieces.player.Turn(this);
            }
            else
            {
                CanMove = false;
                Console.WriteLine("bad move m8");
            }

        }
        public bool PieceInWayHorizontal(char futureX, int futureY)
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
                    break;
                }
                else if ((p.CurrentYCoordinate > this.CurrentYCoordinate && p.CurrentYCoordinate < this.FutureYCoordinate) && p.CurrentXCoordinate == futureX)
                {
                    CanMove = false;
                    break;
                }
                else if ((p.CurrentXCoordinate < this.CurrentXCoordinate && p.CurrentXCoordinate > this.FutureXCoordinate) && p.CurrentYCoordinate == futureY)
                {
                    CanMove = false;
                    break;
                }
                else if ((p.CurrentYCoordinate > this.CurrentYCoordinate && p.CurrentYCoordinate < this.FutureYCoordinate) && p.CurrentXCoordinate == futureX)
                {
                    CanMove = false;
                    break;
                }
                else
                {
                    CanMove = true;
                }
            }
            return CanMove;
        }

        public bool PieceInWayDiagonal(char futureX, int futureY)
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
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX < this.FutureXCoordinate && currentY < this.FutureYCoordinate))
                    {
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
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX > this.FutureXCoordinate && currentY > this.FutureYCoordinate))
                    {
                        return CanMove = false;
                    }
                    else
                    {
                        CanMove = true;
                    }
                }
            }
            return CanMove;
        }

        public override bool PieceInWay(char futureX, int futureY)
        {
            CanMove = false;

            if (!CanMove)
            {
                CanMove = PieceInWayDiagonal(futureX, futureY);
            }
            if (!CanMove)
            {
                CanMove = PieceInWayHorizontal(futureX, futureY);
            }

            return CanMove;
        }



        public override string ToString()
    {
        return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
    }
}
}
