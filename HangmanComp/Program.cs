using System;
using System.Collections.Generic;
using System.IO;

namespace HangmanComp
{
    class Program
    {

        private static string selectedWord;

        private static List<String> storedWords;

        private static int attempts;
        private static List<string> correctLetters;

        static void Main(string[] args)
        {
            storedWords = new List<string>();
            attempts = 0;
            /*StreamReader txtFile = new StreamReader("words.txt");

            Console.WriteLine(txtFile.ReadLine());*/

            Console.WriteLine("Hangman");
            Console.WriteLine("You have 6 attempts!");

            storedWords.Add("Test");
            storedWords.Add("Happy");
            storedWords.Add("Genes");
            storedWords.Add("bye");
            storedWords.Add("four");
            storedWords.Add("ground");
            storedWords.Add("generate");

            selectedWord = selectRandomWord(storedWords).ToLower();
            //Console.WriteLine(selectedWord);


            char[] guess = new char[selectedWord.Length];

            for (int p = 0; p < selectedWord.Length; p++)
                guess[p] = '_' ;

            bool flag = false;
            while (attempts <6)
            {
                Console.WriteLine("Attempts: " + attempts);
                Console.WriteLine("Enter Character");
                char playerGuess = char.Parse(Console.ReadLine());
                //go through each letter in the word
                for (int j = 0; j < selectedWord.Length; j++)
                {
                    //if the guess matches a letter in the word
                    if (playerGuess == selectedWord[j])
                    {
                        //display text
                        guess[j] = playerGuess;
                        
                    }
                    else
                    {
                        flag = false;
                    }

                }

                if(!flag)
                {
                    attempts++;
                }
                Console.WriteLine(guess);

            }

            
            Console.WriteLine("Game Over!");
            Console.WriteLine("Ans: " + selectedWord);
        }


        private static String selectRandomWord(List<string> storedWords)
        {

            Random r = new Random();

            int position = r.Next(0, storedWords.Count);

            return storedWords[position];
        }
    }
}
