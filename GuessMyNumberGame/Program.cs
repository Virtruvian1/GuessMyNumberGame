using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace GuessMyNumberGame
{
    class GameEngine
    {
        private byte _gameMode;
        public int[] gameArray;
        public double averageGuesses;

        public GameEngine() // Default Constructor
        {
            _gameMode = 0;
        }
        public byte GameMode // Set _gameMode
        {
            get { return _gameMode; }
            set
            {
                if (value >= 1 && value <= 3)
                {
                    _gameMode = value;
                }
                while (!(_gameMode == 1 || _gameMode == 2 || _gameMode == 3))
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Please Enter a valid Game Mode [ 1, 2, 3 ]:\r\n" +
                                      "(Please type your answer) Input: ");
                        byte userInput = Convert.ToByte(Console.ReadLine());
                        if (userInput >= 1 && userInput <= 3)
                        {
                            _gameMode = userInput;
                        }
                    }
                    catch (Exception)
                    {
                        Console.Write("Enter in 1, 2, or 3 for the correct game mode:");
                    }
                }
            }
        }
        public void GetGameMode()
        {
            Console.Title = "Guess My Number Game"; // Set Console Window Title
            Console.Write("Which Game Mode would you like to play [ 1, 2, 3 ]?\r\n\r\n" +
                          "Mode 1: Can you guess the right number 1 to 10?\r\n\r\n" +
                          "Mode 2: Can you guess the right number 1 to 1000?\r\n\r\n" +
                          "Mode 3: Can the computer guess your number 1 to 100?\r\n\r\n" +
                          "(Please type your answer) Input: ");
            try { GameMode = Convert.ToByte(Console.ReadLine()); }
            catch (Exception) { };
        }
        public void CreateArray()
        {
            byte mode = GameMode;
            int arrayLength;
            switch (mode)
            {
                case 1:
                    arrayLength = 10;
                    int[] gameArray1 = new int[arrayLength];
                    averageGuesses = Math.Log(arrayLength, 2);
                    gameArray = gameArray1;
                    break;
                case 2:
                    arrayLength = 1000;
                    int[] gameArray2 = new int[arrayLength];
                    averageGuesses = Math.Log(arrayLength, 2);
                    gameArray = gameArray2;
                    break;
                case 3:
                    arrayLength = 100;
                    int[] gameArray3 = new int[arrayLength];
                    averageGuesses = Math.Log(arrayLength, 2);
                    gameArray = gameArray3;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < gameArray.Length; i++)
            {
                gameArray[i] = i + 1;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            GameEngine Game = new GameEngine();
            Game.GetGameMode();
            Game.CreateArray();
        }
    }
}
