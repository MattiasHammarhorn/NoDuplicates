using System;
using System.ComponentModel;

namespace NoDuplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Console.WriteLine("This is a game where you type a phrase and try not to repeat a word while the program tries to see if you did.");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();

            bool gameIsRunning = true;

            do
            {
                Console.Clear();
                string userInput = GetUserInput();

                string[] words = userInput.ToUpper().Split(' ');
                bool noDuplicates = CheckIfWordsContainNoDuplicates(words);

                Console.WriteLine(noDuplicates ? "yes" : "no");
                Console.ReadLine();

                bool playAgain = CheckIfUserWantsToPlayAgain();

                gameIsRunning = playAgain ? true : false;

            } while (gameIsRunning);
        }

        static string GetUserInput()
        {
            string userInput = "";
            bool inputIsValid = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter a line containing no more than 80 characters.");
                userInput = Console.ReadLine();

                inputIsValid = CheckIfPhraseIsValid(userInput);
            } while (!inputIsValid);

            return userInput;
        }

        static bool CheckIfPhraseIsValid(string userInput)
        {
            if (userInput.ToCharArray().Length > 80)
            {
                Console.WriteLine("Error: The line exceeded 80 characters! Press enter to try again.");
                Console.ReadLine();
                return false;
            }
            else if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Error: The line must not be empty! Press enter to try again.");
                Console.ReadLine();
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool CheckIfWordsContainNoDuplicates(string[] words)
        {
            // For each word, check if it occurs again
            // by checking the rest of the words array
            // and comparing it word-by-word.
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i+1; j < words.Length; j++)
                {
                    Console.WriteLine("i: {0} j:{1}", i, j);
                    if (words[i] == words[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool CheckIfUserWantsToPlayAgain()
        {
            string userInput = "";
            bool userInputIsValid = false;
            bool playAgain = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Play again? y/n");
                userInput = Console.ReadLine();

                if (userInput == "y")
                {
                    playAgain = true;
                    userInputIsValid = true;
                }
                else if (userInput == "n")
                {
                    playAgain = false;
                    userInputIsValid = true;
                }
                else
                {
                    Console.WriteLine("Error: please answer only with 'y' or 'n'.");
                    Console.ReadLine();
                }
            } while (!userInputIsValid);

            return playAgain;
        }
    }
}
