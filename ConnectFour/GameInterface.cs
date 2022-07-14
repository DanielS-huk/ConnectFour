using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    public class GameInterface
    {
        GamePeice gamePeice = new GamePeice();
        int[,] gameBoard = new int[6, 7];
        bool isWinner = false;
        public void StartGame()
        {
            int[] oldNumbers = new int[] { 1, 1, 2, 3, 5, 8 };
            int[] newNumbers = oldNumbers;
            newNumbers[3] = 13;
            SetBoardToEmpty();

            DisplayBoardState();
            
            while (!isWinner)
            {
                PlayerMove(1);
                DisplayBoardState();
                CheckWinCondition(1);
                if (isWinner)
                {
                    return;
                }
                PlayerMove(2);
                DisplayBoardState();
                CheckWinCondition(2);
            
                if (isWinner)
                {
                    return;
                }
                
            }

        }
        
        private void SetBoardToEmpty()
        {

            //set game board to empty
            for (int i = 0; i<gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j<gameBoard.GetLength(1); j++)
                {
                    gameBoard[i, j] = 0;
                }
            }
        }

        
        private void DisplayBoardState()
        {
            Console.WriteLine($" ");
            Console.WriteLine($"------------------------------------------- ");
            Console.WriteLine($" ");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == 0)
                    {
                        Console.Write("|");
                        gamePeice.NoGamePeice();
                    }
                    if (gameBoard[i, j] == 1)
                    {
                        Console.Write("|");
                        gamePeice.GreenGamePeice();
                    }
                    if (gameBoard[i, j] == 2)
                    {
                        Console.Write("|");
                        gamePeice.RedGamePeice();
                    }
                    if (j == 6)
                    {
                        Console.Write("|");
                        Console.Write($"\n");
                    }
                }
            }
            Console.WriteLine($" ");
            Console.WriteLine($"------------------------------------------- ");
            Console.WriteLine($" ");
        }
        
        public void PlayerMove(int playerNumber)
        {
            bool playerIsChoosing = true;
            //DisplayBoardState();
            while (playerIsChoosing)
            {
                if (playerNumber == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("player one choose a column");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else if (playerNumber == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("player two choose a column");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                int.TryParse(Console.ReadLine(), out int playerMove);
                if (playerMove > 0 && playerMove < 8)
                {
                    if (gameBoard[0, playerMove - 1] > 0)
                    {
                        Console.WriteLine("illegal move!");
                        continue;
                    }
                    playerIsChoosing = false;

                    PlayerTurn(playerMove, playerNumber);
                }
                else
                {
                    Console.WriteLine("not a real move");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    //DisplayBoardState();
                    continue;
                }
            }
        }

        public void PlayerTurn(int column, int playerNumber)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (j == column - 1)
                    {
                        if ((gameBoard[i, j] != 0) && (i > 0))
                        {
                            gameBoard[i - 1, j] = playerNumber;
                            return;
                        }
                    }
                }
            }
            gameBoard[5, column - 1] = playerNumber;
        }

        public void CheckWinCondition(int player)
        {
            //int consecutive1 = 0;
            //int playernumber = 1;
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if ((j >= 3) && (gameBoard[i, j] == player)
                    && (gameBoard[i, j-1] == player)
                    && (gameBoard[i, j-2] == player)
                    && (gameBoard[i, j-3] == player))
                    {
                        //last player to move has won (row)  
                        Console.WriteLine($"Player {player} has won!");
                        isWinner = true;
                        return;

                    }
                    if ((i >= 3) && (gameBoard[i, j] == player)
                    && (gameBoard[i-1, j] == player)
                    && (gameBoard[i-2, j] == player)
                    && (gameBoard[i-3, j] == player))
                    {
                        //last player to move has won (colum)
                        Console.WriteLine($"Player {player} has won!");
                        isWinner = true;
                        return;
                    }
                    if (((i >= 3) && (j <= 3)) && (gameBoard[i, j] == player)
                    && (gameBoard[i - 1, j + 1] == player)
                    && (gameBoard[i - 2, j + 2] == player)
                    && (gameBoard[i - 3, j + 3] == player))
                    {
                        Console.WriteLine($"Player {player} has won!");
                        isWinner = true;
                        return;
                    }
                    if (((i <=2 ) && (j <= 3)) && (gameBoard[i, j] == player)
                    && (gameBoard[i + 1, j + 1] == player)
                    && (gameBoard[i + 2, j + 2] == player)
                    && (gameBoard[i + 3, j + 3] == player))
                    {
                        Console.WriteLine($"Player {player} has won!");
                        isWinner = true;
                        return;
                    }
                }
            }
            return;
        }

        //public void PlayerTurn(int column, int playerNumber)
        //{

        //    switch (column)
        //    {
        //        case 1:
        //            if (gameBoard[0, 0] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //                for (int i = 0; i < gameBoard.GetLength(0); i++)
        //                {
        //                    for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                    {
        //                        if (j == 0)
        //                        {
        //                            if ((gameBoard[i, j] != 0) && (i > 0))
        //                            {
        //                                gameBoard[i - 1, j] = playerNumber;
        //                                goto LoopEnd1;
        //                            }

        //                        }
        //                    }
        //                }
        //            gameBoard[5, 0] = playerNumber;
        //        LoopEnd1:
        //            break;
        //        case 2:
        //            if (gameBoard[0, 1] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //            for (int i = 0; i < gameBoard.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                {
        //                    if (j == 1)
        //                    {
        //                        if ((gameBoard[i, j] != 0) && (i > 0))
        //                        {
        //                            gameBoard[i - 1, j] = playerNumber;
        //                            goto LoopEnd2;
        //                        }

        //                    }
        //                }
        //            }
        //            gameBoard[5, 1] = playerNumber;
        //        LoopEnd2:
        //            break;
        //        case 3:
        //            if (gameBoard[0, 2] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //            for (int i = 0; i < gameBoard.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                {
        //                    if (j == 2)
        //                    {
        //                        if ((gameBoard[i, j] != 0) && (i > 0))
        //                        {
        //                            gameBoard[i - 1, j] = playerNumber;
        //                            goto LoopEnd3;
        //                        }

        //                    }
        //                }
        //            }
        //            gameBoard[5, 2] = playerNumber;
        //        LoopEnd3:
        //            break;
        //        case 4:
        //            if (gameBoard[0, 3] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //            for (int i = 0; i < gameBoard.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                {
        //                    if (j == 3)
        //                    {
        //                        if ((gameBoard[i, j] != 0) && (i > 0))
        //                        {
        //                            gameBoard[i - 1, j] = playerNumber;
        //                            goto LoopEnd4;
        //                        }

        //                    }
        //                }
        //            }
        //            gameBoard[5, 3] = playerNumber;
        //        LoopEnd4:
        //            break;
        //        case 5:
        //            if (gameBoard[0, 4] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //            for (int i = 0; i < gameBoard.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                {
        //                    if (j == 4)
        //                    {
        //                        if ((gameBoard[i, j] != 0) && (i > 0))
        //                        {
        //                            gameBoard[i - 1, j] = playerNumber;
        //                            goto LoopEnd5;
        //                        }

        //                    }
        //                }
        //            }
        //            gameBoard[5, 4] = playerNumber;
        //        LoopEnd5:
        //            break;
        //        case 6:
        //            if (gameBoard[0, 5] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //            for (int i = 0; i < gameBoard.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                {
        //                    if (j == 5)
        //                    {
        //                        if ((gameBoard[i, j] != 0) && (i > 0))
        //                        {
        //                            gameBoard[i - 1, j] = playerNumber;
        //                            goto LoopEnd6;
        //                        }

        //                    }
        //                }
        //            }
        //            gameBoard[5, 5] = playerNumber;
        //        LoopEnd6:
        //            break;
        //        case 7:
        //            if (gameBoard[0, 6] > 0)
        //            {
        //                Console.WriteLine("illegal move! Lose your turn!");
        //                goto LoopEnd1;
        //            }
        //            else
        //            for (int i = 0; i < gameBoard.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < gameBoard.GetLength(1); j++)
        //                {
        //                    if (j == 6)
        //                    {
        //                        if ((gameBoard[i, j] != 0) && (i > 0))
        //                        {
        //                            gameBoard[i - 1, j] = playerNumber;
        //                            goto LoopEnd7;
        //                        }

        //                    }
        //                }
        //            }
        //            gameBoard[5, 6] = playerNumber;
        //        LoopEnd7:
        //            break;
        //        default:
        //            Console.WriteLine("error");
        //            break;


        //    }
        //}
        private void ConfigueGamePeices()
        {
            gameBoard[0, 0] = 0;
            gameBoard[0, 1] = 0;
            gameBoard[0, 2] = 0;
            gameBoard[0, 3] = 0;
            gameBoard[0, 4] = 0;
            gameBoard[0, 5] = 0;
            gameBoard[0, 6] = 0;

            gameBoard[1, 0] = 0;
            gameBoard[1, 1] = 0;
            gameBoard[1, 2] = 0;
            gameBoard[1, 3] = 0;
            gameBoard[1, 4] = 0;
            gameBoard[1, 5] = 0;
            gameBoard[1, 6] = 0;

            gameBoard[2, 0] = 0;
            gameBoard[2, 1] = 0;
            gameBoard[2, 2] = 2;
            gameBoard[2, 3] = 2;
            gameBoard[2, 4] = 2;
            gameBoard[2, 5] = 0;
            gameBoard[2, 6] = 0;


            gameBoard[3, 0] = 1;
            gameBoard[3, 1] = 0;
            gameBoard[3, 2] = 2;
            gameBoard[3, 3] = 0;
            gameBoard[3, 4] = 0;
            gameBoard[3, 5] = 1;
            gameBoard[3, 6] = 2;
            gameBoard[3, 0] = 0;

            gameBoard[4, 0] = 1;
            gameBoard[4, 1] = 0;
            gameBoard[4, 2] = 2;
            gameBoard[4, 3] = 0;
            gameBoard[4, 4] = 0;
            gameBoard[4, 5] = 0;
            gameBoard[4, 6] = 1;


            gameBoard[5, 0] = 1;
            gameBoard[5, 1] = 1;
            gameBoard[5, 2] = 1;
            gameBoard[5, 3] = 1;
            gameBoard[5, 4] = 0;
            gameBoard[5, 5] = 0;
            gameBoard[5, 6] = 1;


        }

        



                    //public void PlayerOneTurn(int column)
                    //{

                    //    switch (column)
                    //    {
                    //        case 1:
                    //            if (gameBoard[0, 0] > 0)
                    //            {
                    //                Console.WriteLine("illegal move! Lose your turn!");
                    //                goto LoopEnd1;
                    //            }
                    //            else
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 0)
                    //                    {
                    //                        if ((gameBoard[i,j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd1;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 0] = 1;
                    //        LoopEnd1:
                    //            break;
                    //        case 2:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 1)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd2;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 1] = 1;
                    //        LoopEnd2:
                    //            break;
                    //        case 3:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 2)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd3;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 2] = 1;
                    //        LoopEnd3:
                    //            break;
                    //        case 4:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 3)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd4;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 3] = 1;
                    //        LoopEnd4:
                    //            break;
                    //        case 5:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 4)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd5;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 4] = 1;
                    //        LoopEnd5:
                    //            break;
                    //        case 6:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 5)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd6;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 5] = 1;
                    //        LoopEnd6:
                    //            break;
                    //        case 7:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 6)
                    //                    {
                    //                        if ((gameBoard[i,j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 1;
                    //                            goto LoopEnd7;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 6] = 1;
                    //        LoopEnd7:
                    //            break;
                    //        default:
                    //            Console.WriteLine("error");
                    //            break;


                    //    }
                    //}

                    //public void PlayerOneMove()
                    //{
                    //    bool playerIsChoosing = true;
                    //    //DisplayBoardState();
                    //    while (playerIsChoosing)
                    //    {
                    //        Console.BackgroundColor = ConsoleColor.Green;
                    //        Console.ForegroundColor = ConsoleColor.Black;
                    //        Console.Write("player one choose a column");
                    //        Console.ResetColor();
                    //        Console.WriteLine();
                    //        int playerMove = int.Parse(Console.ReadLine());
                    //        if (playerMove > 0 && playerMove < 8)
                    //        {
                    //            playerIsChoosing = false;
                    //            PlayerOneTurn(playerMove);
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("not a real move");
                    //            Console.WriteLine();
                    //            Console.WriteLine();
                    //            Console.WriteLine();
                    //            Console.WriteLine();
                    //            //DisplayBoardState();
                    //            continue;
                    //        }
                    //    }

                    //}
                    //public void PlayerTwoMove()
                    //{
                    //    bool playerIsChoosing = true;
                    //    //DisplayBoardState();
                    //    while (playerIsChoosing)
                    //    {
                    //        Console.BackgroundColor = ConsoleColor.Red;
                    //        Console.ForegroundColor = ConsoleColor.Black;
                    //        Console.Write("player two choose a column");
                    //        Console.ResetColor();
                    //        Console.WriteLine();
                    //        int playerMove = int.Parse(Console.ReadLine());
                    //        if (playerMove > 0 && playerMove < 8)
                    //        {
                    //            playerIsChoosing = false;
                    //            PlayerTwoTurn(playerMove);
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("not a real move");
                    //            Console.WriteLine();
                    //            Console.WriteLine();
                    //            Console.WriteLine();
                    //            Console.WriteLine();
                    //            //DisplayBoardState();
                    //            continue;
                    //        }
                    //    }

                    //}
                    //public void PlayerTwoTurn(int column)
                    //{

                    //    switch (column)
                    //    {
                    //        case 1:
                    //            if (gameBoard[0, 0] > 0)
                    //            {
                    //                Console.WriteLine("illegal move! Lose your turn!");
                    //                goto LoopEnd1;
                    //            }
                    //            else
                    //                for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //                {
                    //                    for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                    {
                    //                        if (j == 0)
                    //                        {
                    //                            if ((gameBoard[i, j] != 0) && (i > 0))
                    //                            {
                    //                                gameBoard[i - 1, j] = 2;
                    //                                goto LoopEnd1;
                    //                            }

                    //                        }
                    //                    }
                    //                }
                    //            gameBoard[5, 0] = 2;
                    //        LoopEnd1:
                    //            break;
                    //        case 2:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 1)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 2;
                    //                            goto LoopEnd2;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 1] = 2;
                    //        LoopEnd2:
                    //            break;
                    //        case 3:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 2)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 2;
                    //                            goto LoopEnd3;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 2] = 2;
                    //        LoopEnd3:
                    //            break;
                    //        case 4:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 3)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 2;
                    //                            goto LoopEnd4;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 3] = 2;
                    //        LoopEnd4:
                    //            break;
                    //        case 5:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 4)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 2;
                    //                            goto LoopEnd5;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 4] = 2;
                    //        LoopEnd5:
                    //            break;
                    //        case 6:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 5)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 2;
                    //                            goto LoopEnd6;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 5] = 2;
                    //        LoopEnd6:
                    //            break;
                    //        case 7:
                    //            for (int i = 0; i < gameBoard.GetLength(0); i++)
                    //            {
                    //                for (int j = 0; j < gameBoard.GetLength(1); j++)
                    //                {
                    //                    if (j == 6)
                    //                    {
                    //                        if ((gameBoard[i, j] != 0) && (i > 0))
                    //                        {
                    //                            gameBoard[i - 1, j] = 2;
                    //                            goto LoopEnd7;
                    //                        }

                    //                    }
                    //                }
                    //            }
                    //            gameBoard[5, 6] = 2;
                    //        LoopEnd7:
                    //            break;
                    //        default:
                    //            Console.WriteLine("error");
                    //            break;


                    //    }
                    //}
                    //custom config for testing and what not
            }
}
