﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Rook : Piece
    {
        Person player = new Person();
        public Rook()
        {
            this.CanMove = false;
            this.HasMoved = false;
        }

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
            AvailableMoves = new string[7];
            Piece piece = null;
            int Ymax = 9;
            int Ymin = 0;
            char Xmax = 'h';
            char Xmin = 'a';

            foreach (Piece p in ReadInPieces.AllPieces)
            {
                if (p.CurrentXCoordinate == futureX && p.CurrentYCoordinate == futureY)
                {
                    piece = p;
                }
            }

            if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                if (this != null)
                {
                    if (piece == null)
                    {
                        CanMove = true;
                        PieceInWay(this);
                        ReadInPieces.player.Turn(this);
                        if (CanMove)
                        {
                            Console.WriteLine($"\n\n{this.ToString()}");
                            CurrentXCoordinate = futureX;
                            CurrentYCoordinate = futureY;
                        }
                        else
                        {
                            Console.WriteLine("No can do");
                        }
                    }
                    else if (piece.Color != this.Color)
                    {
                        CanMove = true;
                        PieceInWay(this);
                        ReadInPieces.player.Turn(this);
                        if (CanMove)
                        {
                            Console.WriteLine($"\n\n{this.ToString()}");
                            CurrentXCoordinate = futureX;
                            CurrentYCoordinate = futureY;
                            capture(piece);
                            ReadInPieces.AllPieces.Remove(piece);
                        }
                        else
                        {
                            Console.WriteLine("No can do");
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
                //for (int j = 'a'; j < Xmax; j++)
                //{
                //    this.AvailableMoves[j - 97] = $"{(CurrentXCoordinate + j)-103}{CurrentYCoordinate}";
                //}
            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                if (this != null)
                {
                    if (piece == null)
                    {
                        CanMove = true;
                        PieceInWay(this);
                        ReadInPieces.player.Turn(this);
                        if (CanMove)
                        {
                            Console.WriteLine($"\n\n{this.ToString()}");
                            CurrentXCoordinate = futureX;
                            CurrentYCoordinate = futureY;
                        }
                        else
                        {
                            Console.WriteLine("No can do");
                        }
                    }
                    else if (piece.Color != this.Color)
                    {
                        CanMove = true;
                        PieceInWay(this);
                        ReadInPieces.player.Turn(this);
                        if (CanMove)
                        {
                            Console.WriteLine($"\n\n{this.ToString()}");
                            CurrentXCoordinate = futureX;
                            CurrentYCoordinate = futureY;
                            capture(piece);
                            ReadInPieces.AllPieces.Remove(piece);
                        }
                        else
                        {
                            Console.WriteLine("No can do");
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

        public bool PieceInWay(Piece rook)
        {
            foreach (Piece p in ReadInPieces.AllPieces)
            {
                if (p.CurrentXCoordinate < rook.FutureXCoordinate && p.CurrentXCoordinate > rook.CurrentXCoordinate)
                {
                    CanMove = false;
                    break;
                }
                else if (p.CurrentYCoordinate < rook.FutureYCoordinate && p.CurrentYCoordinate > rook.CurrentYCoordinate)
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

        public void capture(Piece p)
        {
            ReadInPieces.AllPieces.Remove(p);
            Console.WriteLine("This piece is captured");
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
