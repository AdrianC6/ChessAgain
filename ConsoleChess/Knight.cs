using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Knight : Piece
    {
        public Knight()
        {
            this.CanMove = true;
            this.HasMoved = false;
        }
        public Knight(ChessPieces pieceType, PieceColors color, char currentXcoordinate, int currentYCoordinate, bool canMove, bool hasMoved)
        {
            this.PieceType = pieceType;
            this.Color = color;
            this.CurrentXCoordinate = currentXcoordinate;
            this.CurrentYCoordinate = currentYCoordinate;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }
        public Knight(ChessPieces pieceType, PieceColors color, char currentXCoordinate, char futureXCoordinate, int currentYCoordinate, int futureYCoordinate, bool canMove, bool hasMoved)
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
            if ((CurrentXCoordinate + 1 == futureX && CurrentYCoordinate + 2 == futureY) || (CurrentXCoordinate - 1 == futureX && CurrentYCoordinate + 2 == futureY))
            {
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else if ((CurrentXCoordinate - 1 == futureX && CurrentYCoordinate - 2 == futureY) || (CurrentXCoordinate + 1 == futureX && CurrentYCoordinate - 2 == futureY))
            {
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else if ((CurrentXCoordinate - 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate - 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else if ((CurrentXCoordinate + 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate + 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else
            {
                CanMove = false;
                Console.WriteLine("Bad move u spineless seasponge");
            }
        }

        public override bool MoveToSpace(char futureX, int futureY, string[,] board)
        {
            if ((CurrentXCoordinate + 1 == futureX && CurrentYCoordinate + 2 == futureY) || (CurrentXCoordinate - 1 == futureX && CurrentYCoordinate + 2 == futureY))
            {
                CanMove = true;
                CanMove = PieceInWay(futureX, futureY, board);
            }
            else if ((CurrentXCoordinate - 1 == futureX && CurrentYCoordinate - 2 == futureY) || (CurrentXCoordinate + 1 == futureX && CurrentYCoordinate - 2 == futureY))
            {
                CanMove = true;
                CanMove = PieceInWay(futureX, futureY, board);
            }
            else if ((CurrentXCoordinate - 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate - 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                CanMove = true;
                CanMove = PieceInWay(futureX, futureY, board);
            }
            else if ((CurrentXCoordinate + 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate + 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                CanMove = true;
                CanMove = PieceInWay(futureX, futureY, board);
            }
            else
            {
                CanMove = false;
            }

            return CanMove;
        }

        public override bool PieceInWay(char futureX, int futureY, string[,] board)
        {
            CanMove = false;

            if ((CurrentXCoordinate + 1 == futureX && CurrentYCoordinate + 2 == futureY) || (CurrentXCoordinate - 1 == futureX && CurrentYCoordinate + 2 == futureY))
            {
                if (board[futureX, futureY] == "[-]")
                {
                    CanMove = true;
                }
                else
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

            }
            else if ((CurrentXCoordinate - 1 == futureX && CurrentYCoordinate - 2 == futureY) || (CurrentXCoordinate + 1 == futureX && CurrentYCoordinate - 2 == futureY))
            {
                if (board[futureX, futureY] == "[-]")
                {
                    CanMove = true;
                }
                else
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
            }
            else if ((CurrentXCoordinate - 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate - 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                if (board[futureX, futureY] == "[-]")
                {
                    CanMove = true;
                }
                else
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
            }
            else if ((CurrentXCoordinate + 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate + 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                if (board[futureX, futureY] == "[-]")
                {
                    CanMove = true;
                }
                else
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
            }
            else
            {
                CanMove = false;
            }

            return CanMove;
        }

        public override bool PieceInWay(char futureX, int futureY)
        {
            CanMove = false;

            if ((CurrentXCoordinate + 1 == futureX && CurrentYCoordinate + 2 == futureY) || (CurrentXCoordinate - 1 == futureX && CurrentYCoordinate + 2 == futureY))
            {
                CanMove = true;
            }
            else if ((CurrentXCoordinate - 1 == futureX && CurrentYCoordinate - 2 == futureY) || (CurrentXCoordinate + 1 == futureX && CurrentYCoordinate - 2 == futureY))
            {
                CanMove = true;
            }
            else if ((CurrentXCoordinate - 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate - 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                CanMove = true;
            }
            else if ((CurrentXCoordinate + 2 == futureX && CurrentYCoordinate - 1 == futureY) || (CurrentXCoordinate + 2 == futureX && CurrentYCoordinate + 1 == futureY))
            {
                CanMove = true;
            }
            else
            {
                CanMove = false;
            }
            return CanMove;
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
