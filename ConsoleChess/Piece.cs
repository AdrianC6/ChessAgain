using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleChess
{
    public abstract class Piece
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
                    return PieceType.ToString().ToLower();
                }
                return PieceType.ToString();

            }
        }
        public ChessPieces PieceType;
        public PieceColors Color;
        public char CurrentXCoordinate;
        public char FutureXCoordinate;
        public int CurrentYCoordinate;
        public int FutureYCoordinate;
        public bool CanMove;
        public bool HasMoved;
        protected Piece() { }
        protected Piece(ChessPieces piece, PieceColors color, char x, int y, char fx, int fy, bool canMove, bool hasMoved)
        {
            this.PieceType = piece;
            this.Color = color;
            this.CurrentXCoordinate = x;
            this.CurrentYCoordinate = y;
            this.FutureXCoordinate = fx;
            this.FutureYCoordinate = fy;
            this.CanMove = canMove;
            this.HasMoved = hasMoved;
        }

        public abstract void Move(char futureX, int futureY);
    }
}

