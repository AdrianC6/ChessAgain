﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class ReadInPieces
    {

        public static List<Piece> AllPieces = new List<Piece>();

        public static string placePiece = @"(^[PNBRQK][ld][a-h][1-8]$)";
        public static string movePiece = @"(^[a-h][1-8] [a-h][1-8]$)";
        public static string capturePiece = @"(^[a-h][1-8] [a-h][1-8][*]$)";
        public static string moveTwoPieces = @"(^[a-h][1-8] [a-h][1-8] [a-h][1-8] [a-h][1-8]$)";
        Regex Place = new Regex(placePiece);
        Regex Move = new Regex(movePiece);
        Regex Capture = new Regex(capturePiece);
        Regex MoveTwo = new Regex(moveTwoPieces);
        public static ChessGame chessy = new ChessGame();
        public static Person player = new Person();
        bool IsInitiallyPrinted = false;
        public void run(string args)
        {
            do
            {
                if (!File.Exists(args))
                {
                    Console.WriteLine("Please enter a valid file: ");
                    args = Console.ReadLine();
                }
                else
                {
                    ReadFile(args);
                }
            } while (!File.Exists(args));
        }
        public void ReadFile(string file)
        {
            try
            {
                using (StreamReader path = new StreamReader(file))
                {
                    string line = path.ReadToEnd();
                    string[] pieceCoords;

                    pieceCoords = line.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in pieceCoords)
                    {
                        if (Place.IsMatch(s))
                        {
                            PlacePiece(s);
                        }
                        else if (Move.IsMatch(s))
                        {
                            MovePiece(s);
                            chessy.GenerateBoard();
                        }
                        else if (Capture.IsMatch(s))
                        {
                            CapturePiece(s);
                            chessy.GenerateBoard();
                        }
                        else if (MoveTwo.IsMatch(s))
                        {
                            MoveTwoPieces(s);
                            chessy.GenerateBoard();
                        }
                    }
                }
                if (!IsInitiallyPrinted)
                {
                    chessy.GenerateBoard();
                    IsInitiallyPrinted = true;
                }
                do
                {
                    Console.Write("Enter your file(ctrl+c to exit):");
                  string file1 = Console.ReadLine();
                    if (!File.Exists(file1))
                    {
                        Console.WriteLine("enter valid path");
                    }
                    else
                    {
                        this.ReadFile(file1);
                    }
                } while (!File.Exists(file));
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void PlacePiece(string s)
        {
            Piece piece = CreateSaidPiece(s);
            piece.PieceType = PieceDeterminer(s[0]);
            piece.Color = ColorDeterminer(s[1]);
            piece.CurrentXCoordinate = (char)s[2];
            piece.CurrentYCoordinate = validYCoord(s[3]);
            AllPieces.Add(piece);
            Console.WriteLine(piece);
        }

        public Piece CreateSaidPiece(string s)
        {
            if (s[0] == 'K')
            {
                //lord of the rings
                return new King();
            }
            else if (s[0] == 'Q')
            {
                return new Queen();
            }
            else if (s[0] == 'B')
            {
                return new Bishop();
            }
            else if (s[0] == 'N')
            {
                return new Knight();
            }
            else if (s[0] == 'R')
            {
                return new Rook();
            }
            else if (s[0] == 'P')
            {
                return new Pawn();
            }
            else
            {
                return null;
            }
        }

        public void MovePiece(string s)
        {
            Piece piece = null;
            Piece piece1 = null;
            foreach (Piece p in AllPieces)
            {
                if (p.CurrentXCoordinate == s[0] && p.CurrentYCoordinate == validYCoord(s[1]))
                {
                    piece = p;
                    break;
                }
            }
            foreach (Piece p in AllPieces)
            {
                if (p.CurrentXCoordinate == s[3] && p.CurrentYCoordinate == validYCoord(s[4]))
                {
                    piece1 = p;
                    break;
                }
            }

            if (piece != null)
            {
                if (piece1 == null)
                {
                    piece.Move(piece.FutureXCoordinate = (char)s[3], piece.FutureYCoordinate = validYCoord(s[4]));
                    if (piece.CanMove == true)
                    {
                        Console.WriteLine($"\n{piece}");
                        piece.CurrentXCoordinate = piece.FutureXCoordinate;
                        piece.CurrentYCoordinate = piece.FutureYCoordinate;
                        //chessy.GenerateBoard();
                    }
                }
                else if (piece1.Color != piece.Color)
                {
                    piece.Move(piece.FutureXCoordinate = (char)s[3], piece.FutureYCoordinate = validYCoord(s[4]));
                    if (piece.CanMove == true)
                    {
                        Console.WriteLine($"\n{piece}");
                        piece.CurrentXCoordinate = piece.FutureXCoordinate;
                        piece.CurrentYCoordinate = piece.FutureYCoordinate;
                        AllPieces.Remove(piece1);
                        Console.WriteLine("Piece Captured");
                        //chessy.GenerateBoard();
                    }
                }
                else
                {
                    Console.WriteLine("\nCant take own pieces:/");
                    chessy.GenerateBoard();
                }
            }
            else
            {
                Console.WriteLine("\nThere is no piece there");
                chessy.GenerateBoard();
            }
        }

        public void CapturePiece(string s)
        {
            MovePiece(s);
            //Console.WriteLine("piece captured");
            //J2D waz hear
        }

        public void MoveTwoPieces(string s)
        {
            foreach (Piece p in AllPieces)
            {
                if (p.CurrentXCoordinate == s[0] && p.CurrentYCoordinate == validYCoord(s[1]))
                {
                    p.FutureXCoordinate = (char)s[3];
                    p.FutureYCoordinate = validYCoord(s[4]);
                    Console.Write($"{p} and ");
                    p.CurrentXCoordinate = p.FutureXCoordinate;
                    p.CurrentYCoordinate = p.FutureYCoordinate;
                }
                else if (p.CurrentXCoordinate == s[6] && p.CurrentYCoordinate == validYCoord(s[7]))
                {
                    p.FutureXCoordinate = (char)s[9];
                    p.FutureYCoordinate = validYCoord(s[10]);
                    Console.WriteLine($"{p}");
                    p.CurrentXCoordinate = p.FutureXCoordinate;
                    p.CurrentYCoordinate = p.FutureYCoordinate;
                }
            }
        }

        public Piece.PieceColors ColorDeterminer(char color)
        {
            Piece.PieceColors DeterminedColor = Piece.PieceColors.WHITE;
            if (color == 'l')
            {
                DeterminedColor = Piece.PieceColors.WHITE;
            }
            else if (color == 'd')
            {
                DeterminedColor = Piece.PieceColors.BLACK;
            }
            return DeterminedColor;
        }

        public Piece.ChessPieces PieceDeterminer(char piece)
        {
            Piece.ChessPieces DeterminedPiece = Piece.ChessPieces.K;
            if (piece == 'K')
            {
                DeterminedPiece = Piece.ChessPieces.K;
            }
            else if (piece == 'Q')
            {
                DeterminedPiece = Piece.ChessPieces.Q;
            }
            else if (piece == 'B')
            {
                DeterminedPiece = Piece.ChessPieces.B;
            }
            else if (piece == 'N')
            {
                DeterminedPiece = Piece.ChessPieces.N;
            }
            else if (piece == 'R')
            {
                DeterminedPiece = Piece.ChessPieces.R;
            }
            else if (piece == 'P')
            {
                DeterminedPiece = Piece.ChessPieces.P;
            }
            return DeterminedPiece;
        }

        //validates the Y Coordinate
        public int validYCoord(char yCoord)
        {
            int.TryParse(yCoord.ToString(), out int result);
            return result;
        }
    }
}

