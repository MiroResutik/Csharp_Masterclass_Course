namespace MyQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[] 
            {

                new Question("What is the capital of UK?", new string[] {"Paris", "London", "Berlin", "Madrid"}, 1),
                new Question("What is the capital of France?", new string[] {"Paris", "London", "Berlin", "Madrid"}, 0),
                new Question("What is the capital of Germany?", new string[] {"Paris", "London", "Berlin", "Madrid"}, 2),
                new Question("What is the capital of Spain?", new string[] {"Paris", "London", "Berlin", "Madrid"}, 3),
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
