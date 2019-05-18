using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleChess
{
    class ChessPiece
    {
        public enum ChessPieces
        {
            K,
            Q,
            B,
            N,
            R,
            P
        }
        public enum PieceColors
        {
            WHITE,
            BLACK
        }
        public string stringRep
        {
            get
            {
                if (Color == PieceColors.BLACK)
                {
                    return Piece.ToString().ToLower();
                }
                return Piece.ToString();

            }
        }
        public ChessPieces Piece { get; set; }
        public PieceColors Color { get; set; }
        public char CurrentXCoordinate { get; set; }
        public char FutureXCoordinate { get; set; }
        public int CurrentYCoordinate { get; set; }
        public int FutureYCoordinate { get; set; }
        public bool CanMove { get; set; }

        public static List<ChessPiece> AllPieces = new List<ChessPiece>();
        public static string placePiece = @"(^[PNBRQK][ld][a-h][1-8]$)";
        public static string movePiece = @"(^[a-h][1-8] [a-h][1-8]$)";
        public static string capturePiece = @"(^[a-h][1-8] [a-h][1-8][*]$)";
        public static string moveTwoPieces = @"(^[a-h][1-8] [a-h][1-8] [a-h][1-8] [a-h][1-8]$)";
        Regex Place = new Regex(placePiece);
        Regex Move = new Regex(movePiece);
        Regex Capture = new Regex(capturePiece);
        Regex MoveTwo = new Regex(moveTwoPieces);

        //used to run the Read file method
        public void run(string args)
        {
            if (!File.Exists(args))
            {
                Console.WriteLine("Enter a valid file path");
            }
            else
            {
                ReadFile(args);
            }
        }
        //reads the File
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
                        }
                        else if (Capture.IsMatch(s))
                        {
                            CapturePiece(s);
                        }
                        else if (MoveTwo.IsMatch(s))
                        {
                            MoveTwoPiece(s);
                        }
                        //getPiece(s);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        //validates the Y Coordinate
        public int validYCoord(char yCoord)
        {
            int.TryParse(yCoord.ToString(), out int result);
            return result;
        }
        //checks to see what is wanted whether its placing a piece or moving

        public void PlacePiece(string s)
        {
            ChessPiece piece = new ChessPiece();
            piece.Piece = pieceDeterminer(s[0]);
            piece.Color = colorDeterminer(s[1]);
            piece.CurrentXCoordinate = (char)s[2];
            piece.CurrentYCoordinate = validYCoord(s[3]);
            Console.WriteLine(piece.neededString(s));
            AllPieces.Add(piece);
        }

        public void MovePiece(string s)
        {
            ChessPiece piece = new ChessPiece();
            ChessPiece piece2 = new ChessPiece();
            foreach (ChessPiece p in AllPieces)
            {
                if (p.CurrentXCoordinate == s[3] && p.CurrentYCoordinate == validYCoord(s[4]))
                {
                    piece2 = p;
                }
                else if (p.CurrentXCoordinate == s[0] && p.CurrentYCoordinate == validYCoord(s[1]))
                {
                    p.FutureXCoordinate = (char)s[3];
                    p.FutureYCoordinate = validYCoord(s[4]);
                    Console.WriteLine(p.neededString(s));
                    p.CurrentXCoordinate = p.FutureXCoordinate;
                    p.CurrentYCoordinate = p.FutureYCoordinate;
                }
            }
            AllPieces.Remove(piece2);
            AllPieces.Add(piece);
        }

        public void CapturePiece(string s)
        {
            ChessPiece piece = new ChessPiece();
            ChessPiece piece2 = new ChessPiece();
            foreach (ChessPiece p in AllPieces)
            {
                if (p.CurrentXCoordinate == s[3] && p.CurrentYCoordinate == validYCoord(s[4]))
                {
                    piece2 = p;
                }
                else if (p.CurrentXCoordinate == s[0] && p.CurrentYCoordinate == validYCoord(s[1]))
                {
                    p.FutureXCoordinate = (char)s[3];
                    p.FutureYCoordinate = validYCoord(s[4]);
                    Console.WriteLine(p.neededString(s));
                    p.CurrentXCoordinate = p.FutureXCoordinate;
                    p.CurrentYCoordinate = p.FutureYCoordinate;
                }
            }
            AllPieces.Remove(piece2);
            AllPieces.Add(piece);
        }

        public void MoveTwoPiece(string s)
        {
            ChessPiece piece = new ChessPiece();
            foreach (ChessPiece p in AllPieces)
            {
                if (p.CurrentXCoordinate == s[0] && p.CurrentYCoordinate == validYCoord(s[1]))
                {
                    p.FutureXCoordinate = (char)s[3];
                    p.FutureYCoordinate = validYCoord(s[4]);
                    Console.Write($"{p.neededString(s)}and ");
                    p.CurrentXCoordinate = p.FutureXCoordinate;
                    p.CurrentYCoordinate = p.FutureYCoordinate;
                }
                else if (p.CurrentXCoordinate == s[6] && p.CurrentYCoordinate == validYCoord(s[7]))
                {
                    p.FutureXCoordinate = (char)s[9];
                    p.FutureYCoordinate = validYCoord(s[10]);
                    Console.WriteLine($"{p.neededString(s)}");
                    p.CurrentXCoordinate = p.FutureXCoordinate;
                    p.CurrentYCoordinate = p.FutureYCoordinate;
                }
            }
            AllPieces.Add(piece);
        }

        //returns a string for what happens depending on what moves or placed
        public string neededString(string s)
        {
            string currentPrint = "";
            string placePrint = $"{Color} {stringRep} Placed at {CurrentXCoordinate}{CurrentYCoordinate}";
            string movePrint = $"{Color} {stringRep} at {CurrentXCoordinate}{CurrentYCoordinate} moved to {FutureXCoordinate}{FutureYCoordinate} ";
            string doubleMovePrint = $"{movePrint}";
            string Cap = $"{Color} {stringRep} captured a piece at {FutureXCoordinate}{FutureYCoordinate}";
            if (MoveTwo.IsMatch(s))
            {
                currentPrint = doubleMovePrint;
            }
            else if (Capture.IsMatch(s))
            {
                currentPrint = Cap;
            }
            else if (Move.IsMatch(s))
            {
                currentPrint = movePrint;
            }
            else if (Place.IsMatch(s))
            {
                currentPrint = placePrint;
            }
            return currentPrint;
        }
        //used to determine the color of the piece
        public PieceColors colorDeterminer(char colorChoice)
        {
            PieceColors color = PieceColors.WHITE;
            if (colorChoice == 'l')
            {
                color = PieceColors.WHITE;
            }
            else if (colorChoice == 'd')
            {
                color = PieceColors.BLACK;
            }
            return color;
        }
        //used to determine what the piece is
        public ChessPieces pieceDeterminer(char pieceName)
        {
            ChessPieces piece = ChessPieces.K;
            if (pieceName == 'K')
            {
                piece = ChessPieces.K;
            }
            else if (pieceName == 'Q')
            {
                piece = ChessPieces.Q;
            }
            else if (pieceName == 'B')
            {
                piece = ChessPieces.B;
            }
            else if (pieceName == 'N')
            {
                piece = ChessPieces.N;
            }
            else if (pieceName == 'R')
            {
                piece = ChessPieces.R;
            }
            else if (pieceName == 'P')
            {
                piece = ChessPieces.P;
            }
            return piece;
        }
        //allows for the piece to print in plain english
        public override string ToString()
        {
            return $"{Piece}{stringRep}{CurrentXCoordinate}{CurrentYCoordinate}{FutureXCoordinate}{FutureYCoordinate}";
        }
    }
}

