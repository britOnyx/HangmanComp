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
            


            char[] guess = new char[selectedWord.Length];

            for (int p = 0; p < selectedWord.Length; p++)
                guess[p] = '_' ;

            bool win = false;
            bool matchedWord = false; //used to flag if the guess words matchs

            int numbcorrect = 0; // used to count the number of correct letters
            while (attempts <6)
            {
                Console.WriteLine("Attempts: " + attempts);
                Console.WriteLine("Enter Character");

                
                char playerGuess = char.Parse(Console.ReadLine().ToLower());

                //go through each letter in the word
                for (int j = 0; j < selectedWord.Length; j++)
                {
                    //if the guess matches a letter in the word
                    if (playerGuess == selectedWord[j])
                    {
                        //add to the array
                        guess[j] = playerGuess;
                        numbcorrect++; //increment characters correct

                        //if all the characters have been guessed
                        if (numbcorrect == (selectedWord.Length))
                        {
                            //exit loop
                            attempts = 7;
                            win = true; //notify you won the game
                        }
                    }


                    //if the selected words match
                    if(selectedWord.Contains(playerGuess))
                    {
                        //set true
                        matchedWord = true;
                    }
                    


                }



                //if flag == won 
                if(win)
                {
                    //display text
                    Console.WriteLine("Game Over, You Win!");
                }

                //if matched word hasnt been flagged 
                if(!matchedWord)
                {
                    //increase attempt number
                    attempts++;
                   
                }
                

                Console.WriteLine(guess); //display array

                matchedWord = false; //reset flag
            }

            //if win flag hasnt been changed 
            if(!win)
            {
                //display text
                Console.WriteLine("Game Over, You Loose!");
                Console.WriteLine("Ans: " + selectedWord);
            }

        }


        private static String selectRandomWord(List<string> storedWords)
        {
            //create random gen
            Random r = new Random();

            //random number will be generated from 0 to length of stored words
            int position = r.Next(0, storedWords.Count);

            //return a word using the random generator
            return storedWords[position];
        }
    }
}
