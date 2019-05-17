﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Movement
    {
        //ChessGame game = new ChessGame();
        ChessPiece piece = new ChessPiece();

        public void CheckPiece()
        {
            string file;
            do
            {
                Console.WriteLine("Enter File to Read movements: ");
                file = Console.ReadLine();
                if (!File.Exists(file))
                {
                    Console.WriteLine("Enter Valid File:");
                }
                else
                {
                    piece.ReadFile(file);
                }
            } while (!File.Exists(file));
            foreach (ChessPiece p in ChessPiece.AllPieces)
            {
                if (p.Color == ChessPiece.PieceColors.BLACK)
                {
                    MoveDarkPiece(p);
                }
                else if (p.Color == ChessPiece.PieceColors.WHITE)
                {
                    MoveLightPiece(p);
                }
            }
            ChessGame game = new ChessGame();
            game.GenerateBoard();
            game.replace();
        }

        //public void readFile(string file)
        //{
        //    try
        //    {
        //        using (StreamReader path = new StreamReader(file))
        //        {
        //            string line = path.ReadToEnd();
        //            string[] pieceCoords;

        //            pieceCoords = line.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        //            foreach (string s in pieceCoords)
        //            {
        //                //if(piece.CurrentXCoordinate == s[3] && piece.CurrentYCoordinate == s[4])
        //                //{
        //                //    Console.WriteLine("Im here now");
        //                //}
        //                //else
        //                //{
        //                //    Console.WriteLine(s);
        //                //}
        //            }
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine("The file could not be read:");
        //        Console.WriteLine(e.Message);
        //    }
        //}

        public void MoveDarkPiece(ChessPiece piece)
        {
            //foreach (ChessPiece p in ChessPiece.AllPieces)
            //{

            //if (piece.CurrentXCoordinate ==  && piece.CurrentYCoordinate == )
            //{
            //    if (piece.Piece == ChessPiece.ChessPieces.K)
            //    {
            //        KingMovement(piece);
            //    }
            //}
            //else if (piece.Piece == ChessPiece.ChessPieces.Q)
            //{

            //}
            //else if (piece.Piece == ChessPiece.ChessPieces.N)
            //{

            //}
            //else if (piece.Piece == ChessPiece.ChessPieces.B)
            //{

            //}
            //else if (piece.Piece == ChessPiece.ChessPieces.R)
            //{

            //}
            //}
        }

        public void KnightMovement(ChessPiece piece)
        {

        }

        public void KingMovement(ChessPiece piece)
        {

        }
        public void QueenMovement(ChessPiece piece)
        {

        }
        public void RookMovement(ChessPiece piece)
        {
            //if (piece.FutureXCoordinate == && piece.FutureYCoordinate == )
            //{

            //}
        }
        public void BishopMovement(ChessPiece piece)
        {

        }

        public void MoveLightPiece(ChessPiece piece)
        {
            //if (piece.CurrentXCoordinate ==  && piece.CurrentYCoordinate == )
            //{
            //    if (piece.Piece == ChessPiece.ChessPieces.K)
            //    {
            //        piece.FutureXCoordinate = ;
            //        piece.FutureYCoordinate = ;
            //    }
            //    else if (piece.Piece == ChessPiece.ChessPieces.Q)
            //    {

            //    }
            //    else if (piece.Piece == ChessPiece.ChessPieces.N)
            //    {

            //    }
            //    else if (piece.Piece == ChessPiece.ChessPieces.B)
            //    {

            //    }
            //    else if (piece.Piece == ChessPiece.ChessPieces.R)
            //    {

            //    }
            //}
        }
    }
}
