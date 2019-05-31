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
                    if (piece.Color != p.Color)
                    {
                        check = piece.PieceInWay(x, y);
                    }
                }
            }
            else
            {
                foreach (Piece piece in ReadInPieces.AllPieces)
                {
                    if (piece.Color != p.Color)
                    {
                        check = piece.PieceInWay(x, y);
                    }
                }
            }

            return check;
        }
    }
}

