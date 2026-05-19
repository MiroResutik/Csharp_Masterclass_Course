using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp
{
    internal class Quiz
    {
        // Array of questions - here questions is a varaiable
        private Question[] _questions;
        private int _score;
        //Constructor for questions
        //We want questions to be passed to quiz directly
        //Here questions is a parameter therefore it needs to have this. at the front so the system can see
        // the pirvate questions variable from above
        public Quiz(Question[] questions) //Parameter questions
        {
            this._questions = questions;
            _score = 0;
        }

        // Method to start quiz and hadle questions
        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1; // display question numbers
            // loop through question array Question[]
            foreach (Question question in _questions)
            {
                Console.WriteLine($"\nQuestion {questionNumber++}");
                DispayQuestion(question);
                //Get user choice using GetUserChoice() method
                int userChoice = GetUserChoice(); // checking wether user put valid choice
                //using boolean method IsCorrectAnswer
                if (question.IsCorrectAnswer(userChoice))

                {
                    Console.WriteLine("Correct!");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer was: {question.Answers[question.CorrestAnswerIndex]}");
                }
            }
            DispalyResults();

        }
        // Display correct score
        private void DispalyResults()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"Quiz finished. Your score is: {_score} out of {_questions.Length}");

            double percentage = (double) _score/_questions.Length;
            if (percentage >=0.8)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Excelent Work!");
            }else if (percentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort!");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Need More Practice!");
            }
            Console.ResetColor ();
        }
        // Method to display questions - private as we don't need to dispaly outside of the quiz 
        private void DispayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);

            // Interested in amount of answers in string
            for (int i = 0; i < question.Answers.Length; i++)
            {
                //Style the answers useng ForegroudColor
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" ");
                Console.Write(i +1);
                Console.ResetColor(); //Resest the color

                // Dispaly answers in any given question
                Console.WriteLine($". {question.Answers[i]}");
            }
            //if (GetUserChoice() == question.CorrestAnswerIndex)
            //{
            //    Console.WriteLine("Correct!");

            //}
            //else
            //{
            //    Console.WriteLine("Incorrect");
            //}
        }
        
        //Method to get users imput choice
        private int GetUserChoice()
        {
            Console.WriteLine("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse( input, out choice) || choice < 1 || choice >4) 
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4: ");
                input = Console.ReadLine();
            }
            return choice -1; // adjust to 0 index array
        }
    }
}
