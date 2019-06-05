﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Queen : Piece
    {
        //og constructor 
        public Queen()
        {
            this.CanMove = false;
            this.HasMoved = false;
        }
        //over loaded constructor 1
        public Queen(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        //over loaded constructor 2
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
        //makes the queen move
        public override void Move(char futureX, int futureY)
        {
            int Ymin = 0;
            int Ymax = 9;
            char Xmin = 'a';
            char Xmax = 'h';

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                //CanMove = true;
                NoPieceInWayDiagonal(futureX, futureY);
                ReadInPieces.player.Turn(this);
            }
            else if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                //CanMove = true;
                NoPieceInWayHorizontal(futureX, futureY);
                ReadInPieces.player.Turn(this);
            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                //CanMove = true;
                NoPieceInWayHorizontal(futureX, futureY);
                ReadInPieces.player.Turn(this);
            }
            else
            {
                CanMove = false;
                Console.WriteLine("Invalid move pls don't");
            }
        }
        //checks to see if a piece is in the way horizontally
        public bool NoPieceInWayHorizontal(char futureX, int futureY)
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
                else if ((p.CurrentYCoordinate > this.CurrentYCoordinate && p.CurrentYCoordinate < this.FutureYCoordinate) && p.CurrentXCoordinate == futureX)
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
        //checks if a piece is in the way diagonally
        public bool NoPieceInWayDiagonal(char futureX, int futureY)
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
                        CanMove = true;
                    }
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
