using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class ChessGame
    {
        //ReadInPieces rp = new ReadInPieces();
        //board array
        public string[,] board = new string[9, 'i'];
        public void GenerateBoard()
        {
            for (int i = 1; i < 9; i++)
            {
                for (char j = 'a'; j < 'i'; j++)
                {
                    board[i, j] = ((i + j) % 2 == 0) ? board[i, j] = "[-]" : board[i, j] = "[-]";
                }
            }
            replace();
        }

        //place or move piece to where is needed
        public void replace()
        {
            foreach (Piece p in ReadInPieces.AllPieces)
            {
                if (p.FutureXCoordinate != 0 && p.FutureYCoordinate != 0)
                {
                    board[p.CurrentYCoordinate, p.CurrentXCoordinate] = $"[{p.stringRep}]";
                }
                else
                {
                    board[p.CurrentYCoordinate, p.CurrentXCoordinate] = $"[{p.stringRep}]";
                }
            }
            Console.WriteLine("  A  B  C  D  E  F  G  H");
            for (int i = 1; i < 9; i++)
            {
                Console.Write($"{i} ");
                for (char j = 'a'; j < 'i'; j++)
                {
                    Console.Write(board[i, j], "-");
                }
                Console.WriteLine(" "+i);
               // Console.Write("\n");
            }
            Console.Write("  A  B  C  D  E  F  G  H");
            Console.WriteLine();
        }


        public bool isInCheck(Piece p)
        {
            bool check = false;
            char x = p.CurrentXCoordinate;
            int y = p.CurrentYCoordinate;


            if (p.Color == Piece.PieceColors.WHITE)
            {
                foreach (Piece piece in ReadInPieces.AllPieces)
                {
                    if (piece.Color == Piece.PieceColors.BLACK)
                    {
                        check = piece.PieceInWay(x, y);

                        if (check)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (Piece piece in ReadInPieces.AllPieces)
                {
                    if (piece.Color == Piece.PieceColors.WHITE)
                    {
                        check = piece.PieceInWay(x, y);

                        if (check)
                        {
                            break;
                        }
                    }
                }
            }

            return check;
        }

        public bool isInCheck(char x, int y , Piece p)
        {
            bool check = false;

            if (p.Color == Piece.PieceColors.WHITE)
            {
                foreach (Piece piece in ReadInPieces.AllPieces)
                {
                    if (piece.Color == Piece.PieceColors.BLACK)
                    {
                        check = piece.PieceInWay(x, y);

                        if (check)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (Piece piece in ReadInPieces.AllPieces)
                {
                    if (piece.Color == Piece.PieceColors.WHITE)
                    {
                        check = piece.PieceInWay(x, y);

                        if (check)
                        {
                            break;
                        }
                    }
                }
            }

            return check;
        }

        public bool isInCheckmate(Piece p)
        {
            bool checkmate = false;
            char x = p.CurrentXCoordinate;
            int y = p.CurrentYCoordinate;

            while(!checkmate)
            {
                if (isInCheck((x += (char)1), (y + 1), p))
                {
                    break;
                }
                if (isInCheck((x += (char)1), (y - 1), p))
                {
                    break;
                }
                if (isInCheck((x += (char)1), (y), p))
                {
                    break;
                }
                if (isInCheck((x), (y + 1), p))
                {
                    break;
                }
                if (isInCheck((x), (y - 1), p))
                {
                    break;
                }
                if (isInCheck((x -= (char)1), (y + 1), p))
                {
                    break;
                }
                if (isInCheck((x -= (char)1), (y), p))
                {
                    break;
                }
                if (isInCheck((x -= (char)1), (y - 1), p))
                {
                    break;
                }
                else
                {
                    checkmate = true;
                }

            }

            return checkmate;
        }
    }
}

