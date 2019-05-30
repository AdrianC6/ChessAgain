﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Bishop : Piece
    {
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
            //int Ymin = 0;
            //int Ymax = 9;
            //char Xmin = 'a';
            //char Xmax = 'h';

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                //CanMove = true;
                PieceInWay(futureX, futureY);
                ReadInPieces.player.Turn(this);
                //ReadInPieces.chessy.GenerateBoard();
            }
            else
            {
                CanMove = false;
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
                while(currentX <= 'h' && currentY < 8)
                {
                    currentX += (char)1;
                    currentY += 1;
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX < this.FutureXCoordinate && currentY < this.FutureYCoordinate))
                    {
                        Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType}");
                        return CanMove = false;
                    }
                    
                    else
                    {
                        CanMove = true;
                    }
                }
                while(currentX >= 'a' && currentY >= 1)
                {
                    currentX -= (char)1;
                    currentY -= 1;
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX > this.FutureXCoordinate && currentY > this.FutureYCoordinate))
                    {
                        Console.WriteLine($"\n{this.Color} {this.PieceType} is blocked by {p.Color} {p.PieceType}");
                        return CanMove = false;
                    }
                    else
                    {
                        CanMove = true;
                    }
                }
                //else if (p.CurrentYCoordinate > this.CurrentYCoordinate && p.CurrentYCoordinate < this.FutureYCoordinate)
                //{
                //    CanMove = false;
                //    Console.WriteLine("no can do");
                    //break;
                //}
            }
            return CanMove;
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
