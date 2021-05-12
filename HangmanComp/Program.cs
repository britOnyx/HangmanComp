using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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


           // file = bin/Debug/netscoreapp3.1/words.txt
           string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"words.txt");

            ReadFile(path);

            Console.WriteLine("Hangman");
            Console.WriteLine("You have 6 attempts!");

            selectedWord = selectRandomWord(storedWords).ToLower();

            //Console.WriteLine("Ans: " + selectedWord + " Length: " + storedWords.Count);

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

        private static void ReadFile(string path)
        {
            //open text file
            using(StreamReader sr = new StreamReader(path))
            {
                //read text file
                sr.ReadLine();

                //create variable to store textfile data
                string word;

                //while there is text in the document
                //store the line into vairable
                while((word = sr.ReadLine()) != null)
                {
                    //add to list and repeat
                    storedWords.Add(word);
                }
            }
            Console.WriteLine("Words Stored");
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
