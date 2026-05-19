namespace MyQuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[] 
            {

                new Question("What is the capital of UK?", new string[] {"Paris", "London", "Berlin", "Madrid"}, 1),
                new Question("What is the fastest land animal?", new string[] {"Cheetah", "Lion", "Horse", "Kangaroo"}, 0),
                new Question("Which element has the chemical symbol 'Au'?", new string[] {"Silver", "Gold", "Oxygen", "Iron"}, 1),
                new Question("Who painted the Mona Lisa?", new string[] {"Vincent van Gogh", "Leonardo da Vinci", "Pablo Picasso", "Claude Monet"}, 1),
                new Question("Which ocean is the largest on Earth?", new string[] {"Atlantic Ocean", "Indian Ocean", "Pacific Ocean", "Arctic Ocean"}, 2),
                new Question("In which year did the first man land on the moon?", new string[] {"1965", "1969", "1972", "1959"}, 1),
                new Question("What is the capital of Italy?", new string[] {"Rome", "Milan", "Naples", "Venice"}, 0),
                new Question("What is the capital of Japan?", new string[] {"Tokyo", "Kyoto", "Osaka", "Hiroshima"}, 0),
                new Question("What is the capital of Canada?", new string[] {"Toronto", "Vancouver", "Ottawa", "Montreal"}, 2),
                new Question("What is the capital of Australia?", new string[] {"Sydney", "Melbourne", "Canberra", "Brisbane"}, 2),
                new Question("What is the capital of Brazil?", new string[] {"Rio de Janeiro", "São Paulo", "Brasília", "Salvador"}, 2),
                new Question("Which planet is known as the Red Planet?", new string[] {"Earth", "Mars", "Jupiter", "Venus"}, 1),
                new Question("What is the chemical symbol for water?", new string[] {"H2O", "O2", "CO2", "HO"}, 0),
                new Question("Who wrote the play 'Romeo and Juliet'?", new string[] {"William Shakespeare", "Charles Dickens", "Mark Twain", "Jane Austen"}, 0),
                new Question("Which animal is the largest mammal on Earth?", new string[] {"Elephant", "Blue Whale", "Giraffe", "Hippopotamus"}, 1),
                new Question("How many continents are there on Earth?", new string[] {"5", "6", "7", "8"}, 2),
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
