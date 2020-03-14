using System;
using System.Threading;


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
            try
            {
                GameMode = Convert.ToByte(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
                GetGameMode();
            }
        }
        public void CreateArray()
        {
            byte mode = GameMode;
            switch (mode)
            {
                case 1:
                    arrayLength = 10;
                    int[] gameArray1 = new int[arrayLength];
                    averageGuesses = Math.Ceiling(Math.Log(arrayLength, 2));
                    gameArray = gameArray1;
                    break;
                case 2:
                    arrayLength = 1000;
                    int[] gameArray2 = new int[arrayLength];
                    averageGuesses = Math.Ceiling(Math.Log(arrayLength, 2));
                    gameArray = gameArray2;
                    break;
                case 3:
                    arrayLength = 100;
                    int[] gameArray3 = new int[arrayLength];
                    averageGuesses = Math.Ceiling(Math.Log(arrayLength, 2));
                    gameArray = gameArray3;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < gameArray.Length; i++) // Fill array with values
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
                    }
                    catch (Exception) { }
                    break;
                default:
                    break;
            }

        }
        public void GuessEngine()
        { // Game loop until the right number is guessed
            bool guessedNum = false;
            byte mode = GameMode;
            int leftLimit = 1;
            int rightLimit = gameArray.Length;
            string pronoun;
            do
            {
                Console.Clear();
                int guess;
                try
                {
                    switch (mode)
                    {
                        case 1:
                            pronoun = "YOU";
                            Console.Write($"Can you guess the number? [{leftLimit} to {rightLimit}]\r\n" +
                                          $"You've guessed {guessCounter} times\r\n" +
                                          $"(Please type your answer: ");
                            guess = Convert.ToInt32(Console.ReadLine());
                            guessedNum = BisectionalAlgorithm(guess);
                            break;
                        case 2:
                            pronoun = "you";
                            Console.Write($"Can you guess the number? [{leftLimit} to {rightLimit}]\r\n" +
                                          $"You've guessed {guessCounter} times\r\n" +
                                          $"(Please type your answer: ");
                            guess = Convert.ToInt32(Console.ReadLine());
                            guessedNum = BisectionalAlgorithm(guess);
                            break;
                        case 3:
                            pronoun = "THE COMPUTER";
                            guess = random.Next(leftLimit, rightLimit);
                            Console.Write($"Can the comupter guess your number?\r\n" +
                                          $"It's guessing from [{leftLimit} to {rightLimit}]\r\n" +
                                          $"And the computer guessed {guess}\r\n");
                            guessedNum = BisectionalAlgorithm(guess);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
            while (!guessedNum);

            bool BisectionalAlgorithm(int guess)
            {
                if (guess == chosenNum)
                {
                    Console.Clear();
                    string result;
                    guessCounter++;
                    if (guessCounter <= averageGuesses) { result = "won"; }
                    else { result = "lost"; }
                    Console.WriteLine($"The guess is right!\r\n" +
                                      $"{pronoun} took {guessCounter} guessess.\r\n" +
                                      $"The average is {averageGuesses} guessess.\r\n" +
                                      $"The results are that {pronoun} {result}.");
                    return true;
                }
                else if (guess < chosenNum)
                {
                    if (guess >= leftLimit)
                    {
                        guessCounter++;
                        leftLimit = guess;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The guess is too low");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        return false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Guess within the limits");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                else //guess > chosenNum 
                {
                    if (guess <= rightLimit)
                    {
                        guessCounter++;
                        rightLimit = guess;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The guess is too high");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        return false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Guess within the limits");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        return false;
                    }
                }
            }
        }
    }
}
