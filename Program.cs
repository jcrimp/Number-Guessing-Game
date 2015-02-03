using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    /***********************************************************
     * Jenny Crimp
     * 11/13/14
     * ITC 110 
     * Midterm
     * 
     * This program is a guessing game that will generate a random number,
     * prompt the user for a guess 10 times, tell them whether their guess is too high
     * or too low each time, and ask them if they want to play again.
     * It keeps track of the score for every game in an array, 
     * and will display their average score for all games 
     * if they choose not to play again.
     * *********************************************************/
    class Program
    {
        int number;//declare random number here so it can be global and passed through more easily
        int[] scores = new int[20];//array to store scores
        int counter = 0;//counter to know how many games they have played
        
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();

        }

        private void Start()
        {
            GenerateRandom();
            PromptAndGetGuess();
            PlayAgain();
        }

        private int GenerateRandom()
        {
            Random rand = new Random();
            number = rand.Next(1, 501);
            return number;
        }

        private void PromptAndGetGuess()
        {
            string guess;
            //Console.WriteLine(number);
            int score = 0;
           
            for(int j=10; j>=0; j--)
            {
                score = j;//the loop number j gets stored in the variable score
                Console.WriteLine(j + " guesses remaining. Guess a number between 1 and 500");
                guess = Console.ReadLine();
                int guessint = ValidateInt(guess);//here we pass the string "guess" to ValidateInt, and it returns it as an int "guessint"

                if (guessint == number)
                {
                    break;//breaks out of the loop when it is correct
                }    
            }

            
            DisplayScore(score);//pass the score down to KeepScore
        }

        private int ValidateInt(string checkguess)
        {
            int guessnum;
            bool GoodInt= true;


            GoodInt = int.TryParse(checkguess, out guessnum);
            if (GoodInt == false)
            {
                Console.WriteLine("Please enter a valid integer.");
                ValidateInt(Console.ReadLine());//allows user to enter another guess, and validate that entry
            }
            else
            {
                Compare(guessnum);//if it is a valid int, it goes to compare53
            }
            return guessnum;//to pass the int back to Prompt
        }

        private int Compare(int validint)
        {
            if(validint>number)
            {
                Console.WriteLine("Your guess was too high.");
            }
            else if(validint<number)
            {
                Console.WriteLine("Your guess was too low.");
            }
            else//do i need this if i have the break in PromptAndGetGuess?
            {
                Console.WriteLine("Congratulations");
            }
            return validint;
            
        }

        private void DisplayScore(int points)//score from Prompt becomes points
        {
            
            scores[counter] = points;//counter becomes the index of the array that will contain the points
            
            Console.WriteLine("Your score for this game is " + points);
            counter++;//increment counter here so I can be sure scores are stored at an index starting at 0
        }

        private void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? yes/no");
            string continueplay = Console.ReadLine();
            continueplay = continueplay.ToLower();
            if(continueplay == "yes")
            {
                Start();
            }
            else
            {
                AverageScore();
            }
            
        }

        private void AverageScore()
        {
            double total=0;
            double average=0;

            Console.WriteLine("Here are your scores for all games played.");
            for(int j=0; j<counter; j++)
            {
                Console.WriteLine(scores[j]);
                total += scores[j];
            }
            average = total / counter;
            Console.WriteLine("Your average score was " + average.ToString("#0.00"));
            EndProgram();
            
        }

        private void EndProgram()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
