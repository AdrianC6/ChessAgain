using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class ChessGame
    {
        Movement move = new Movement();
        //list of Pieces
        //board array
        string[,] board = new string[9, 'i'];
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
            foreach (ChessPiece cp in ChessPiece.AllPieces)
            {
                if (cp.FutureXCoordinate != 0 && cp.FutureYCoordinate != 0)
                {
                    board[cp.FutureYCoordinate, cp.FutureXCoordinate] = $"[{cp.stringRep}]";
                }
                else
                {
                    board[cp.CurrentYCoordinate, cp.CurrentXCoordinate] = $"[{cp.stringRep}]";
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
            move.CheckPiece();
        }
    }
}

