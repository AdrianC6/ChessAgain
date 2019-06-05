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


        public override void Move(char futureX, int futureY, string[,] board)
        {

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)

            {
                //CanMove = true;
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else
            {
                CanMove = false;
                Console.WriteLine("Invalid move u uncultured swine");
            }
        }

        public override bool MoveToSpace(char futureX, int futureY, string[,] board)
        {
            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                if (PieceInWay(futureX, futureY, board))
                {
                    CanMove = false;
                }
                else
                {
                    CanMove = true;
                }
            }
            else
            {
                CanMove = false;
            }

            return CanMove;
        }

        public override bool PieceInWay(char futureX, int futureY, string[,] board)
        {
            char currentX;
            int currentY;
            CanMove = false;

            foreach (Piece p in ReadInPieces.AllPieces)
            {
                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX <= futureX  && currentY <= futureY)
                {
                    currentX += (char)1;
                    currentY += 1;
                    if (board[currentX, currentY] == "[-]")
                    {
                        if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                        {
                            CanMove = false;
                            break;
                        }
                        else
                        {
                            CanMove = true;
                        }

                    }
                    else if (board[currentX, currentY] != "[-]")
                    {
                        if (Color == PieceColors.WHITE)
                        {
                            if (board[futureX, futureY][1] > (char)96 || board[futureX, futureY][1] < (char)123)
                            {
                                CanMove = true;
                            }
                        }
                        else
                        {
                            if (board[futureX, futureY][1] > (char)64 || board[futureX, futureY][1] < (char)91)
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
                        CanMove = false;
                    }
                }

                if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                {
                    CanMove = false;
                    break;
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX >= futureX && currentY >= futureY)
                {
                    currentX -= (char)1;
                    currentY -= 1;
                    if (board[currentX, currentY] == "[-]")
                    {
                        if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                        {
                            CanMove = false;
                            break;
                        }
                        else
                        {
                            CanMove = true;
                        }

                    }
                    else if (board[currentX, currentY] != "[-]")
                    {
                        if (Color == PieceColors.WHITE)
                        {
                            if (board[futureX, futureY][1] > (char)96 || board[futureX, futureY][1] < (char)123)
                            {
                                CanMove = true;
                            }
                        }
                        else
                        {
                            if (board[futureX, futureY][1] > (char)64 || board[futureX, futureY][1] < (char)91)
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
                        CanMove = false;
                    }
                }

                if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                {
                    CanMove = false;
                    break;
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX >= futureX && currentY < futureY)
                {
                    currentX -= (char)1;
                    currentY += 1;
                    if (board[currentX, currentY] == "[-]")
                    {
                        if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                        {
                            CanMove = false;
                            break;
                        }
                        else if (board[currentX, currentY] != "[-]")
                        {
                            if (Color == PieceColors.WHITE)
                            {
                                if (board[futureX, futureY][1] > (char)96 || board[futureX, futureY][1] < (char)123)
                                {
                                    CanMove = true;
                                }
                            }
                            else
                            {
                                if (board[futureX, futureY][1] > (char)64 || board[futureX, futureY][1] < (char)91)
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
                            CanMove = true;
                        }

                    }
                    else
                    {
                        CanMove = false;
                    }
                }

                if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                {
                    CanMove = false;
                    break;
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX >= futureX && currentY <= futureY)
                {
                    currentX += (char)1;
                    currentY -= 1;
                    if (board[currentX, currentY] == "[-]")
                    {
                        if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                        {
                            CanMove = false;
                            break;
                        }
                        else if (board[currentX, currentY] != "[-]")
                        {
                            if (Color == PieceColors.WHITE)
                            {
                                if (board[futureX, futureY][1] > (char)96 || board[futureX, futureY][1] < (char)123)
                                {
                                    CanMove = true;
                                }
                            }
                            else
                            {
                                if (board[futureX, futureY][1] > (char)64 || board[futureX, futureY][1] < (char)91)
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
                            CanMove = true;
                        }

                    }
                    else
                    {
                        CanMove = false;
                    }
                }

                if ((currentX == futureX && currentY > futureY || currentY < futureY) || (currentY == futureY && currentX > futureX || currentX < futureX))
                {
                    CanMove = false;
                    break;
                }
            }
            return CanMove;
        }


        public override bool PieceInWay(char futureX, int futureY)
        {
            char currentX;
            int currentY;
            CanMove = false;

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
                        CanMove = false;
                    }
                    else
                    {
                        CanMove = true;
                    }
                }

                while (currentX >= 'a' && currentY >= 1)
                {
                    currentX -= (char)1;
                    currentY -= 1;
                    if ((p.CurrentXCoordinate == currentX && p.CurrentYCoordinate == currentY) && (currentX > futureX && currentY > futureY))
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

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
