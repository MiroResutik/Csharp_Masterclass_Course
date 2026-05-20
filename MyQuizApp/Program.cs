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
                new Question("What is the smallest planet in our solar system?", new string[] {"Mercury", "Mars", "Venus", "Pluto"}, 0),
                new Question("Which country is famous for the pyramids?", new string[] {"Mexico", "India", "Egypt", "Peru"}, 2),
                new Question("Who invented the telephone?", new string[] {"Albert Einstein", "Alexander Graham Bell", "Isaac Newton", "Nikola Tesla"}, 1),
                new Question("Which gas do plants absorb from the atmosphere?", new string[] {"Oxygen", "Hydrogen", "Carbon Dioxide", "Nitrogen"}, 2),
                new Question("What is the largest desert in the world?", new string[] {"Sahara Desert", "Gobi Desert", "Kalahari Desert", "Arctic Desert"}, 0),
                new Question("Which language is primarily spoken in Brazil?", new string[] {"Spanish", "Portuguese", "French", "English"}, 1),
                new Question("How many days are there in a leap year?", new string[] {"365", "366", "364", "367"}, 1),
                new Question("Which organ pumps blood through the human body?", new string[] {"Liver", "Brain", "Heart", "Lungs"}, 2),
                new Question("What is the boiling point of water in Celsius?", new string[] {"90", "95", "100", "110"}, 2),
                new Question("Who discovered gravity when observing a falling apple?", new string[] {"Galileo Galilei", "Isaac Newton", "Albert Einstein", "Thomas Edison"}, 1),
                new Question("Which continent is the largest by area?", new string[] {"Africa", "Europe", "Asia", "North America"}, 2),
                new Question("What is the hardest natural substance on Earth?", new string[] {"Gold", "Iron", "Diamond", "Silver"}, 2),
                new Question("Which instrument has 88 keys?", new string[] {"Guitar", "Violin", "Piano", "Drums"}, 2),
                new Question("What is the tallest mountain in the world?", new string[] {"K2", "Mount Everest", "Kilimanjaro", "Mont Blanc"}, 1),
                new Question("Which country invented pizza?", new string[] {"France", "Italy", "USA", "Spain"}, 1),
                new Question("What is the main gas found in the air we breathe?", new string[] {"Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen"}, 2),
                new Question("Which planet is closest to the Sun?", new string[] {"Venus", "Earth", "Mercury", "Mars"}, 2),
                new Question("Who wrote 'Harry Potter'?", new string[] {"J.R.R. Tolkien", "J.K. Rowling", "George R.R. Martin", "Stephen King"}, 1),
                new Question("What is the largest organ in the human body?", new string[] {"Heart", "Liver", "Skin", "Lungs"}, 2),
                new Question("Which country is known as the Land of the Rising Sun?", new string[] {"China", "Thailand", "South Korea", "Japan"}, 3),
                new Question("What is the main language spoken in Spain?", new string[] {"Spanish", "Portuguese", "Italian", "French"}, 0),
                new Question("Which planet is the largest in our solar system?", new string[] {"Earth", "Saturn", "Jupiter", "Neptune"}, 2),
                new Question("How many bones are in the adult human body?", new string[] {"206", "201", "208", "212"}, 0),
                new Question("Which continent is the Sahara Desert located in?", new string[] {"Asia", "Africa", "Australia", "Europe"}, 1),
                new Question("What is the capital of Germany?", new string[] {"Munich", "Berlin", "Hamburg", "Frankfurt"}, 1),
                new Question("Which instrument has keys, pedals, and strings?", new string[] {"Guitar", "Piano", "Drum", "Violin"}, 1),
                new Question("What is the process by which plants make food?", new string[] {"Respiration", "Digestion", "Photosynthesis", "Transpiration"}, 2),
                new Question("Which sport is known as the 'king of sports'?", new string[] {"Basketball", "Cricket", "Football (Soccer)", "Tennis"}, 2),
                new Question("Which metal is liquid at room temperature?", new string[] {"Iron", "Mercury", "Copper", "Aluminium"}, 1),
                new Question("What is the capital of France?", new string[] {"Paris", "Rome", "Madrid", "Berlin"}, 0),
                new Question("What is the square root of 64?", new string[] {"6", "7", "8", "9"}, 2),
                new Question("Who is known as the Father of Computers?", new string[] {"Charles Babbage", "Alan Turing", "Bill Gates", "Steve Jobs"}, 0),
                new Question("Which country hosted the 2012 Summer Olympics?", new string[] {"China", "UK", "Brazil", "USA"}, 1),
                new Question("What is the currency of Japan?", new string[] {"Yen", "Won", "Dollar", "Peso"}, 0),
                new Question("Which gas is most abundant in Earth's atmosphere?", new string[] {"Oxygen", "Nitrogen", "Carbon Dioxide", "Hydrogen"}, 1),
                new Question("How many sides does a hexagon have?", new string[] {"5", "6", "7", "8"}, 1),
                new Question("What is the capital of Spain?", new string[] {"Madrid", "Barcelona", "Seville", "Valencia"}, 0),
                new Question("Which animal is known as the King of the Jungle?", new string[] {"Tiger", "Lion", "Elephant", "Leopard"}, 1),
                new Question("What is H2SO4 commonly known as?", new string[] {"Hydrochloric acid", "Sulfuric acid", "Nitric acid", "Carbonic acid"}, 1),
                new Question("Which planet has the most moons?", new string[] {"Jupiter", "Saturn", "Mars", "Neptune"}, 1),
                new Question("What is the capital of Egypt?", new string[] {"Cairo", "Alexandria", "Giza", "Luxor"}, 0),

                // 10 New Questions
                new Question("Which vitamin is produced when the human skin is exposed to sunlight?", new string[] {"Vitamin A", "Vitamin B12", "Vitamin C", "Vitamin D"}, 3),
                new Question("What is the largest internal organ in the human body?", new string[] {"Heart", "Liver", "Kidney", "Lungs"}, 1),
                new Question("Which planet is known for its rings?", new string[] {"Mars", "Saturn", "Jupiter", "Venus"}, 1),
                new Question("What is the main ingredient in guacamole?", new string[] {"Tomato", "Avocado", "Onion", "Pepper"}, 1),
                new Question("Which blood type is known as the universal donor?", new string[] {"A", "B", "AB", "O"}, 3),
                new Question("Which element is the most abundant in the Earth's crust?", new string[] {"Oxygen", "Iron", "Silicon", "Aluminum"}, 0),
                new Question("What is the freezing point of water in Celsius?", new string[] {"0", "32", "-1", "100"}, 0),
                new Question("Which is the smallest bone in the human body?", new string[] {"Femur", "Stapes", "Tibia", "Humerus"}, 1),
                new Question("What is the largest continent by population?", new string[] {"Africa", "Asia", "Europe", "North America"}, 1),
                new Question("Which gas do humans exhale?", new string[] {"Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen"}, 1)
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
