using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.TicTacToeFolder;

/// <summary>
/// BIG THANKS TO VICTOR!!! :D
/// Helped me figure out how to change the colors
/// of the board, depending on if there's
/// an X, an O, or a number!
/// </summary>

namespace TicTacToe.TicTacToeFolder
{
    public class TicTacToeGame
    {
        // getting the values of Player 1 and Player 2
        // from the MainMenu class
        // and setting them to be used in the Game class
        // when needed
        public Players Player1 { get; set; }
        public Players Player2 { get; set; }

        // array created to have single characters that are 1 through 9
        public static char[] GameBoard = { '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        public void DisplayBoard()
        {
            
            // set default color to Cyan
            Console.ForegroundColor = ConsoleColor.Cyan;

            // set an int variable "row" to equal 0
            // this will be used to increase
            // from 0 to 2
            // then 2 to 4
            // and so on
            int row = 0;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                    // indent the board when j = 0
                    if (j == 0)
                    {
                        Console.Write($"\t");
                    }

                    // if it doesn't need an indent
                    // then make a pipe seperate each block
                    else
                    {
                        Console.Write($" | ");
                    }

                    // Call method to check and change colors accordingly

                    // first loop:
                    // GameBoard[0+0+0] = 1
                    // GameBoard[1+0+0] = 2
                    // GameBoard[2+0+0] = 3

                    // second loop
                    // GameBoard[0+1+2] = 4
                    // GameBoard[1+1+2] = 5
                    // GameBoard[2+1+2] = 6

                    // third and last loop
                    // GameBoard[0+2+4] = 7
                    // GameBoard[1+2+4] = 8
                    // GameBoard[2+2+4] = 9

                    // this runs the index number through the checkCharColor
                    // if the value of that index is X make the X yellow
                    // if the value of that index is O make the O green
                    // otherwise, the default color of the unchanged value in the index is Cyan
                    checkCharColor(GameBoard[j + i + row]);
                    Console.Write($"{GameBoard[j+i+row]}");

                    // this makes the pipes show up as Cyan
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                // once j = 3
                // make a new row
                // increase row from 0 to 2
                // and start again from the first loop

                Console.Write("\n");
                row += 2;
               
            }

        }

        private void checkCharColor(char character)
        {
            // Method created to check the char members in the board
            // And change their colors accordingly

            // if the character is X
            // change it to yellow
            if (character == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            // if the character is O
            // change it to Green
            else if (character == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            // otherwise, keep it the default Cyan color
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        public void PlayerInput()
        {
            // Clears the board
            // after the Menu is run through
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            TicTacToeGame boardSpot = new TicTacToeGame();

            // switch between player 1 and player 2
            // player 1 is going to be an odd number
            // while player 2 is an even number
            int player2 = 1;

            // just set up "choice" to use later on
            // for player input
            int choice;

            // setting check to 0
            // and then changing that value (or not)
            // depending on how the checkWin loop is run
            int check = 0;

            do
            {
                // check to see which player's turn it is

                // start "if" to check if it's Player 2's turn
                // ie: checking to see if it's an even number
                // starting at 0 so that it auto sets it to be
                // player 1's turn when the game starts
                if (player2%2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{Player2.Name}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(", you're O!\nChoose your spot, then hit enter!");
                }

                // else if it's an odd number
                // start Player 1's turn
                // starts at 0
                // which means it starts with player 1
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Player1.Name}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(", you're X!\nChoose your spot, then hit enter!");
                }

                // later in the code
                // player2 value increases
                // from 1 to 2
                // and then 2 to 3
                // each time something is marked on the board
                // so that the loop above can continue to run back and forth

                Console.WriteLine("\n");
                boardSpot.DisplayBoard();
                Console.WriteLine();


                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t");

                // take user's input of board spot choice
                string userInput = Console.ReadLine();
                int numValue;

                // checking to see if the user's entry
                // works as an INT
                // if it catches it as anything but an int
                // tell them to try again
                if (!int.TryParse(userInput, out numValue))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! That didn't work!\nPlease try again!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                // the variable "choice" that we declared way before
                // is now the value of whatever the user inputed
                // and converted into an int
                // so that it works properly as a value of choice
                choice = Convert.ToInt32(userInput);

                // first check to see if the number is 1-9
                // if it's 0 or less OR 10 or more
                // tell them to try again
                if (choice <= 0 || choice > 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! That wasn't a valid number!\nPlease type A SINGLE number from 1 to 9!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                


                // if that passes, check to see if there is NO x AND no O on the spot
                if (GameBoard[choice - 1] != 'X' && GameBoard[choice - 1] != 'O')
                {
                    // if the spot IS NOT taken and if it's player 2's turn
                    // change element "number" to element "O"
                    // increase the number value of player2++
                    // to make it odd (for player 1's turn check)
                    // or to make it even (for player 2's turn check)
                    if (player2%2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        GameBoard[choice - 1] = 'O';
                        player2++;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        GameBoard[choice - 1] = 'X';

                        player2++;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }

                // if the spot on the board IS taken up already
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! Looks like that spot is already taken!");
                    Console.WriteLine("Please choose an open spot!");
                    Console.ReadLine();
                }

                // after each player takes their turn
                // a check is made
                // to see if there's a winner
                // if there IS a winner
                // then it goes to the Winner Declaration
                // if check's value of 0
                // does not change
                // then the "do" loop continues
                check = CheckWin();
                Console.Clear();
            } while (check != 1 && check != -1);


            // Clear the board
            // After a player takes their turn
            //Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // after clearing
            // display the UPDATED board
            boardSpot.DisplayBoard();

            // checking for a WIN first
            // if check's value was changed to 1
            // show that there's a winner
            if (check == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine();
                Console.WriteLine($"Congratulations! We have a winner!");
                WinnerMessage();

            }
            // else if the value was changed to -1
            // it's a TIE
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine();
                Console.WriteLine("Oh my! Looks like it's a draw! No one wins!");
            }

            // End of the Game!
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n\tThanks for playing!");
            PlayAgainCheck();
        }

        private static int CheckWin()
        {
            // setting each win condition of array as var
            // because I don't wanna type so much code over and over lmao

            var topRowWin = (GameBoard[0] == GameBoard[1] && GameBoard[1] == GameBoard[2]);
            var secondRowWin = (GameBoard[3] == GameBoard[4] && GameBoard[4] == GameBoard[5]);
            var thirdRowWin = (GameBoard[6] == GameBoard[7] && GameBoard[7] == GameBoard[8]);

            var firstColWin = (GameBoard[0] == GameBoard[3] && GameBoard[3] == GameBoard[6]);
            var secColWin = (GameBoard[1] == GameBoard[4] && GameBoard[4] == GameBoard[7]);
            var thirdColWin = (GameBoard[2] == GameBoard[5] && GameBoard[5] == GameBoard[8]);

            var diag1Win = (GameBoard[0] == GameBoard[4] && GameBoard[4] == GameBoard[8]);
            var diag2Win = (GameBoard[2] == GameBoard[4] && GameBoard[4] == GameBoard[6]);

            // if a winning condition is met
            // we're changing the value of "check" from 0 to 1

            //Horizontal First Row Win
            if (topRowWin)
            {
                return 1;
            }
            // Horizontal Second Row Win
            else if (secondRowWin)
            {
                return 1;
            }
            // Horizontal Third Row Win
            else if (thirdRowWin)
            {
                return 1;
            }
            // Vertical First Column Win
            else if (firstColWin)
            {
                return 1;
            }
            // Vertical Second Column Win
            else if (secColWin)
            {
                return 1;
            }
            //Vertical Third Column Win
            else if (thirdColWin)
            {
                return 1;
            }
            // Diagonal Top-Left-To-Bottom-Right Win
            else if (diag1Win)
            {
                return 1;
            }
            // Diagonal Top-Right-To-Bottom-Left Win
            else if (diag2Win)
            {
                return 1;
            }


            // Check for Draw - No Win matches
            // if NO winning condition is met
            // the value of "check" goes from 0 to -1
            else if (GameBoard[0] != '1' && GameBoard[1] != '2' && GameBoard[2] != '3' && GameBoard[3] != '4' &&
                     GameBoard[4] != '5' && GameBoard[5] != '6' && GameBoard[6] != '7' && GameBoard[7] != '8' &&
                     GameBoard[8] != '9')
            {
                return -1;
            }

            // if there isn't a winner
           // AND if there isn't a tie
           // keep the "check" value as 0
           // so that the game can continue
            else
            {
                return 0;
            }
        }

        private void WinnerMessage()
        {
            //  set up 2 different messages
            // depending on which player wins
            string player1WinMessage = ($"\t{Player1.Name} is the winner of this game!\n\tBetter luck next time, {Player2.Name}!");
            string player2WinMessage =
                $"\t{Player2.Name} is the winner of this game!\n\t\tBetter luck next time, {Player1.Name}!";

            // again, setting var for the spots
            // cuz its easier for me to just type "spot1"
            // plus it makes the if loop look better lmao
            var spot1 = GameBoard[0];
            var spot2 = GameBoard[1];
            var spot3 = GameBoard[2];

            var spot4 = GameBoard[3];
            var spot5 = GameBoard[4];
            var spot6 = GameBoard[5];

            var spot7 = GameBoard[6];
            var spot8 = GameBoard[7];
            var spot9 = GameBoard[8];

            // runs through the board and checks it
            // for a winning col/row/diagonal

            // first it checks for player 1's Xs
            // then it checks for player 2's Os

            // then it moves on to the next col/row/diagonal
            // if neither players had that as a winning col/row/diag

            if ((spot1 & spot2 & spot3) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot1 & spot2 & spot3) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }
            else if ((spot4 & spot5 & spot6) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot4 & spot5 & spot6) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }
            else if ((spot7 & spot8 & spot9) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot7 & spot8 & spot9) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }

            else if ((spot1 & spot4 & spot7) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot1 & spot4 & spot7) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }
            else if ((spot2 & spot5 & spot8) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot2 & spot5 & spot8) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }
            else if ((spot3 & spot6 & spot9) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot3 & spot6 & spot9) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }

            else if ((spot1 & spot5 & spot9) == 'X')
            {
                Console.WriteLine(player1WinMessage);
            }
            else if ((spot1 & spot5 & spot9) == 'O')
            {
                Console.WriteLine(player2WinMessage);
            }

            else if ((spot3 & spot5 & spot7) == 'X')
            {
                Console.WriteLine(player2WinMessage);
            }
        }

        private void PlayAgainCheck()
        {
            Console.WriteLine("Do you want to play again?\n");
            Console.WriteLine("Type 'Y' for YES\nType 'N' for NO");
            string playAgainAnswer = Console.ReadLine().ToUpper();

            if (playAgainAnswer == "N")
            {
                Console.WriteLine("Alrighty! Thanks again for playing!");
                Console.WriteLine("Hit ANY KEY to exit!");
                
            }
            else if (playAgainAnswer != "N" && playAgainAnswer != "Y")
            {
                Console.WriteLine("Oops! That was neither a Y nor an N!");
                Console.ReadLine();
                Console.Clear();
                PlayAgainCheck();
            }
            else if (playAgainAnswer == "Y")
            {
                Console.Clear();
                GameBoard[0] = '1';
                GameBoard[1] = '2';
                GameBoard[2] = '3';
                GameBoard[3] = '4';
                GameBoard[4] = '5';
                GameBoard[5] = '6';
                GameBoard[6] = '7';
                GameBoard[7] = '8';
                GameBoard[8] = '9';

                MainMenu.StartWelcome();
            }
        }
    }
}