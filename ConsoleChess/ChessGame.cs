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
                Console.Write($"{i}");
                for (char j = 'a'; j < 'i'; j++)
                {
                    Console.Write(board[i, j], "-");
                }
                Console.Write("\n");
            }

        }

        public bool isInCheck(Piece p, string[,] board)
        {
            bool check = false;
            char x = p.CurrentXCoordinate;
            int y = p.CurrentYCoordinate;
            Console.WriteLine(p);

            foreach (Piece piece in ReadInPieces.AllPieces)
            {
                if (piece.Color != p.Color)
                {
                    check = piece.MoveToSpace(x, y, board);

                    if (check)
                    {
                        Console.WriteLine(piece + $" is putting {p.Color} king in check");
                        break;
                    }
                }
            }

            return check;
        }

        public bool isInCheck(char x, int y , Piece p, string[,] board)
        {
            bool check = false;

            foreach (Piece piece in ReadInPieces.AllPieces)
            {
                if (piece.Color != p.Color)
                {
                    check = piece.MoveToSpace(x, y, board);

                    if (check)
                    {
                        break;
                    }
                }
            }
            return check;
        }

        public bool isInCheckmate(Piece p, string[,] board)
        {
            bool checkmate = false;
            char x = p.CurrentXCoordinate;
            int y = p.CurrentYCoordinate;

            while(!checkmate)
            {
                if (isInCheck((x += (char)1), (y + 1), p, board))
                {
                    break;
                }
                if (isInCheck((x += (char)1), (y - 1), p, board))
                {
                    break;
                }
                if (isInCheck((x += (char)1), (y), p, board))
                {
                    break;
                }
                if (isInCheck((x), (y + 1), p, board))
                {
                    break;
                }
                if (isInCheck((x), (y - 1), p, board))
                {
                    break;
                }
                if (isInCheck((x -= (char)1), (y + 1), p, board))
                {
                    break;
                }
                if (isInCheck((x -= (char)1), (y), p, board))
                {
                    break;
                }
                if (isInCheck((x -= (char)1), (y - 1), p, board))
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

