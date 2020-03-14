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
        public int arrayLength;
        public int chosenNum;
        public int guessCounter;
        public double averageGuesses;

        Random random = new Random();

        public GameEngine() // Default Constructor
        {
            _gameMode = 0;
            chosenNum = 0;
            guessCounter = 0;
            averageGuesses = 0.0;
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
        public void ChooseRandom()
        {
            byte mode = GameMode;
            switch (mode)
            {
                case 1:
                    chosenNum = gameArray[random.Next(0, gameArray.Length)];
                    break;
                case 2:
                    chosenNum = gameArray[random.Next(0, gameArray.Length)];
                    break;
                case 3:
                    try
                    {
                        Console.Write("Choose a number for the Computer to guess:\r\n" +
                                      "(Please type your answer ) [ 1 to 100 ]: ");
                        chosenNum = Convert.ToInt32(Console.ReadLine());
                    } catch (Exception) {  }
                    break;
                default:
                    break;
            }
            
        }
        public void GuessEngine()
        {
            bool guessedNum = false;
            byte mode = GameMode;
            do
            {
                Console.Clear();
                int guess;
                switch (mode)
                {
                    case 1:
                        Console.Write($"Can you guess the number? [{gameArray[0]} to {gameArray[^1]}]\r\n" +
                                      $"You've guessed {guessCounter} times\r\n"+
                                      $"(Please type your answer: ");
                        guess = Convert.ToInt32(Console.ReadLine());
                        guessedNum = BisectionalAlgorithm(guess);
                        break;
                    case 2:
                        Console.Write($"Can you guess the number? [{gameArray[0]} to {gameArray[^1]}]\r\n" +
                                      $"You've guessed {guessCounter} times\r\n" +
                                      $"(Please type your answer: ");
                        guess = Convert.ToInt32(Console.ReadLine());
                        guessedNum = BisectionalAlgorithm(guess);
                        break;
                    case 3:
                        guess = gameArray[random.Next(0, gameArray.Length)];
                        Console.Write($"Can the comupter guess your number?\r\n" +
                                      $"It's guesses from {gameArray[0]} to {gameArray[gameArray.Length - 1]}]" +
                                      $"And the computer guessed {chosenNum}");
                        guessedNum = BisectionalAlgorithm(guess);
                        break;
                    default:
                        break;
                }


            }
            while (!guessedNum);

            bool BisectionalAlgorithm(int guess) // Working here to fix the game, computer mode is not functional yet, show more work
            {
                int counter = 0;
                if (guess < chosenNum) {
                    guessCounter++;
                    Console.WriteLine("The guess is too low");
                    for (int i = guess; i < arrayLength; i++)
                    {
                        counter++;
                    }
                    arrayLength = counter;
                    int[] dynamicArray = new int[arrayLength];
                    for (int i = guess; i < arrayLength; i++)
                    {
                        dynamicArray[i] = i;
                    }
                    gameArray = dynamicArray;
                    return false;
                }
                if (guess > chosenNum) {
                    guessCounter++;
                    Console.WriteLine("The guess is too high");
                    for (int i = 0; i < guess; i++)
                    {
                        counter++;
                    }
                    arrayLength = counter;
                    int[] dynamicArray = new int[arrayLength];
                    for (int i = 0; i < arrayLength; i++)
                    {
                        dynamicArray[i] = i;
                    }
                    gameArray = dynamicArray;
                    return false;
                }
                if (guess == chosenNum) {
                    Console.WriteLine("The guess is right!");
                    if (guessCounter <= averageGuesses) {
                        Console.WriteLine($"You won, you guessed less than the average of {averageGuesses}");
                    } else { Console.WriteLine($"You lost, you guessed more than the average of {averageGuesses}"); }
                    return true;
                }
                return false;
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
            Game.ChooseRandom();
            Game.GuessEngine();
        }
    }
}
