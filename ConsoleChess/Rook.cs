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

        public override void Move(char futureX, int futureY, string[,] board)
        {
            int Ymax = 9;
            int Ymin = 0;
            char Xmax = 'h';
            char Xmin = 'a';

            if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
            {
                //CanMove = true;
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
            {
                //CanMove = true;
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else
            {
                CanMove = false;
            }
        }

        public override bool MoveToSpace(char futureX, int futureY, string[,] board)
        {
            int Ymax = 9;
            int Ymin = 0;
            char Xmax = 'h';
            char Xmin = 'a';

            if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
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
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)
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
                while (currentX == futureX && currentY < futureY)
                {
                    currentY += 1;
                    if (board[currentY, currentX] == "[-]")
                    {
                        CanMove = true;
                        break;
                    }
                    else if (board[currentY, currentX] != "[-]" && currentY == futureY)
                    {
                        if (Color == PieceColors.WHITE && p.Color == PieceColors.WHITE)
                        {
                            CanMove = false;
                            break;
                        }
                        else if (Color == PieceColors.WHITE && p.Color == PieceColors.WHITE)
                        {
                            CanMove = false;
                            break;
                        }
                        else if (Color == PieceColors.BLACK)
                        {
                            if (board[futureY, futureX][1] > (char)96 || board[futureY, futureX][1] < (char)123)
                            {
                                CanMove = true;
                                break;
                            }
                        }
                        else
                        {
                            if (board[futureY, futureX][1] > (char)64 || board[futureY, futureX][1] < (char)91)
                            {
                                CanMove = true;
                                break;
                            }
                            else
                            {
                                CanMove = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        CanMove = false;
                        break;
                    }
                }

                if (currentX == futureX && currentY == futureY)
                {
                    CanMove = true;
                    break;
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX == futureX && currentY > futureY)
                {
                    currentY -= 1;
                    if (board[currentY, currentX] == "[-]")
                    {
                        CanMove = true;
                        break;
                    }
                    else if (board[currentY, currentX] != "[-]" && currentY == futureY)
                    {
                        if (Color == PieceColors.WHITE)
                        {
                            if (board[futureY, futureX][1] > (char)96 || board[futureY, futureX][1] < (char)123)
                            {
                                CanMove = true;
                                break;
                            }
                        }
                        else
                        {
                            if (board[futureY, futureX][1] > (char)64 || board[futureY, futureX][1] < (char)91)
                            {
                                CanMove = true;
                                break;
                            }
                            else
                            {
                                CanMove = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        CanMove = false;
                        break;
                    }
                }

                if (currentX == futureX && currentY == futureY)
                {
                    CanMove = true;
                    break;
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX > futureX && currentY == futureY)
                {
                    currentX -= (char)1;
                    if (board[currentY, currentX] == "[-]")
                    {
                        CanMove = true;
                        break;
                    }
                    else if (board[currentY, currentX] != "[-]" && currentY == futureY)
                    {
                        if (Color == PieceColors.WHITE)
                        {
                            if (board[futureY, futureX][1] > (char)96 || board[futureY, futureX][1] < (char)123)
                            {
                                CanMove = true;
                                break;
                            }
                        }
                        else
                        {
                            if (board[futureY, futureX][1] > (char)64 || board[futureY, futureX][1] < (char)91)
                            {
                                CanMove = true;
                                break;
                            }
                            else
                            {
                                CanMove = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        CanMove = false;
                        break;
                    }
                }

                if (currentX == futureX && currentY == futureY)
                {
                    CanMove = true;
                    break;
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX < futureX && currentY == futureY)
                {
                    currentX += (char)1;
                    if (board[currentY, currentX] == "[-]")
                    {
                        CanMove = true;
                        break;
                    }
                    else if (board[currentY, currentX] != "[-]" && currentY == futureY)
                    {
                        if (Color == PieceColors.WHITE)
                        {
                            if (board[futureY, futureX][1] > (char)96 || board[futureY, futureX][1] < (char)123)
                            {
                                CanMove = true;
                                break;
                            }
                        }
                        else
                        {
                            if (board[futureY, futureX][1] > (char)64 || board[futureY, futureX][1] < (char)91)
                            {
                                CanMove = true;
                                break;
                            }
                            else
                            {
                                CanMove = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        CanMove = false;
                        break;
                    }

                    if (currentX == futureX && currentY == futureY)
                    {
                        CanMove = true;
                        break;
                    }
                }

                break;
            }
            return CanMove;
        }

        public void SpecialMove()
        {

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
                else if ((p.CurrentYCoordinate < this.CurrentYCoordinate && p.CurrentYCoordinate > this.FutureYCoordinate) && p.CurrentXCoordinate == futureX)
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

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
