using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;
using System.IO;

namespace ConsoleChess
{
    class GameMenu
    {

        public void GameStart()
        {

            bool play = true;
            bool replay = false;
            int selection = 0;
            bool kingCheck = false;
            int turn = 2;

            while (play)
            {

                bool GamePlay = true;
                ChessGame chessy = new ChessGame();

                //Opening Menu
                if (replay == false)
                {

                    selection = CIO.PromptForMenuSelection(new string[] { "Play" }, true);
                    Console.Clear();

                }
                else if(replay == true)
                {

                    selection = CIO.PromptForMenuSelection(new string[] { "Play Again" }, true);
                    Console.Clear();

                }

                //deciding if they want to play or not
                if (selection == 0)
                {

                    Console.WriteLine("Have a Good day");
                    GamePlay = false;
                    play = false;

                }
                else if (selection == 1)
                {

                    Console.WriteLine("Game Started");

                    //Setting the Board 
                    string file = "completeChess.txt";
                    ReadInPieces pieced = new ReadInPieces();
                    pieced.run(file);


                    GamePlay = true;

                }


                while (GamePlay)
                {
                
                    if(kingCheck == false)
                    {

                        //check to see if king is checked 


                        //Print Board
                        Console.Clear();
                        chessy.GenerateBoard();

                        //turn Check
                        if(Person.turn == 1)
                        {

                            Console.WriteLine("It is The Light Players Turn");

                        }
                        else if (Person.turn == 2)
                        {

                            Console.WriteLine("It is The Dark Players Turn");

                        }

                        //Piece Selection Menu
                        ReadInPieces r = new ReadInPieces();
                        //r.canPieceMove();
                        r.canPieceMove();
                        IEnumerable<string> pieceList = (IEnumerable<string>)ReadInPieces.moveablePieces; 
                        int PieceSelect = CIO.PromptForMenuSelection(pieceList, true);
                        Console.Clear();

                        if (PieceSelect == 0)
                        {

                            GamePlay = false;
                            replay = true;
                            Console.Clear();

                        }
                        else
                        {

                            //menu starts at one lists start at 0
                            //grab piece
                            PieceSelect = PieceSelect - 1;


                            Console.Clear();

                            //generate list of possible movements for selected piece
                            r.whereCanPieceMove(PieceSelect);
                            //Piece Movement Menu
                            IEnumerable<string> MoveableSpots = (IEnumerable<string>)ReadInPieces.moveableSpots;
                            int PieceMovement = CIO.PromptForMenuSelection(MoveableSpots, true);
                            if(PieceMovement == 0)
                            {

                            

                            }
                            else
                            {

                                //menu starts at one lists start at 0
                                PieceMovement = PieceMovement - 1;
                                //grab positions for move and turn back into string
                                string movement;

                                //send into game logic have it move piece and restart loop

                            }
                            Console.Clear();

                        }

                    }
                    else
                    {

                        Console.WriteLine("Congrats you win");
                        Console.WriteLine("GameOver");
                        GamePlay = false;

                    }

                }

            }

        }

    }

}