using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp
{
    internal class Question
    {
        // Questions text 
        public string QuestionText { get; set; }

        public string[] Answers { get; set; }
        // Index of an Answer array to find which answer is the correct
        public int CorrestAnswerIndex { get; set; }

        // Constructor for questions answers and correct answer index 
        public Question(string questionText, string[] answers, int correctAnswerIndex)
        {
            QuestionText = questionText;    
            Answers = answers;
            CorrestAnswerIndex = correctAnswerIndex;
        }

        // Check correct answer method using int index in answers array
        public bool IsCorrectAnswer(int choice)
        {
            return CorrestAnswerIndex == choice;
        }
    }
}
