using System;
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
        public override void Move(char futureX, int futureY, string[,] board)
        {
            int Ymin = 0;
            int Ymax = 9;
            char Xmin = 'a';
            char Xmax = 'h';

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)
            {
                //CanMove = true;
                PieceInWay(futureX, futureY, board);
                ReadInPieces.player.Turn(this);
            }
            else if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)
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
                Console.WriteLine("bad move m8");
            }

        }

        public override bool MoveToSpace(char futureX, int futureY, string[,] board)
        {
            int Ymin = 0;
            int Ymax = 9;
            char Xmin = 'a';
            char Xmax = 'h';

            if (Math.Abs(((double)CurrentYCoordinate - futureY) / (CurrentXCoordinate - futureX)) == 1)//diagonal
            {
                //CanMove = PieceInWay(futureX, futureY, board);
                if (PieceInWay(futureX, futureY, board))
                {
                    CanMove = true;
                }
                else
                {
                    CanMove = true;
                }
            }
            else if ((futureX >= Xmin && futureX <= Xmax) && CurrentYCoordinate == futureY)//horizontal
            {
                //CanMove = PieceInWay(futureX, futureY, board);
                if (PieceInWay(futureX, futureY, board))
                {
                    CanMove = true;
                }
                else
                {
                    CanMove = true;
                }
            }
            else if ((futureY > Ymin && futureY < Ymax) && CurrentXCoordinate == futureX)//vertival
            {
                //CanMove = PieceInWay(futureX, futureY, board);
                if (PieceInWay(futureX, futureY, board))
                {
                    CanMove = true;
                }
                else
                {
                    CanMove = false;
                }
            }
            else
            {
                CanMove = false;
            }

            return CanMove;
        }

        public bool PieceInWayHorizontal(char futureX, int futureY, string[,] board)
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

        public bool PieceInWayDiagonal(char futureX, int futureY, string[,] board)
        {
            char currentX;
            int currentY;
            CanMove = false;

            foreach (Piece p in ReadInPieces.AllPieces)
            {
                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX < futureX && currentY < futureY)
                {
                    currentY += 1;
                    currentX += (char)1;
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
                        else if (Color == PieceColors.BLACK && p.Color == PieceColors.BLACK)
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
                while (currentX > futureX && currentY > futureY)
                {
                    currentY -= 1;
                    currentX -= (char)1;
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
                        else if (Color == PieceColors.BLACK && p.Color == PieceColors.BLACK)
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
                while (currentX < futureX && currentY > futureY)
                {
                    currentY -= 1;
                    currentX += (char)1;
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
                        else if (Color == PieceColors.BLACK && p.Color == PieceColors.BLACK)
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

                    if (currentX == futureX && currentY == futureY)
                    {
                        CanMove = true;
                        break;
                    }
                }

                currentX = this.CurrentXCoordinate;
                currentY = this.CurrentYCoordinate;
                while (currentX > futureX && currentY < futureY)
                {
                    currentY += 1;
                    currentX -= (char)1;
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
                        else if (Color == PieceColors.BLACK && p.Color == PieceColors.BLACK)
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

        public override bool PieceInWay(char futureX, int futureY)
        {
            CanMove = false;

            if (!CanMove)
            {
                //CanMove = PieceInWayDiagonal(futureX, futureY);
            }
            if (!CanMove)
            {
                //CanMove = PieceInWayHorizontal(futureX, futureY);
            }

            return CanMove;
        }

        public override bool PieceInWay(char futureX, int futureY, string[,] board)
        {
            CanMove = false;

            if (!CanMove)
            {
                CanMove = PieceInWayDiagonal(futureX, futureY, board);
            }
            if (!CanMove)
            {
                CanMove = PieceInWayHorizontal(futureX, futureY, board);
            }

            return CanMove;
        }

        public override string ToString()
        {
            return FutureXCoordinate == 0 && FutureYCoordinate == 0 ? $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate}" : $"{Color} {PieceType} at {CurrentXCoordinate}{CurrentYCoordinate} now at {FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}
