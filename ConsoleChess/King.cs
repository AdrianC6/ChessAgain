﻿using System;
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
                    Console.WriteLine("Invalid move u foon");
                }
            }
            else
            {
                CanMove = false;
                Console.WriteLine("Invalid move u foon");
            }
        }

        public void SpecialMove()
        {
            if (!HasMoved)
            {

            }
        }
        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
