
Console.WriteLine("Text Adventure Game Excercise using loops\n\n");
Console.WriteLine("Welcome to the Adentrue Game!");
Console.WriteLine("Enter your character's name: ");
string playerName = Console.ReadLine();

Console.WriteLine("Choose your character type (Warrior, Wizard, Archer)");
string characterType = Console.ReadLine();

Console.WriteLine($"You, {playerName} the {characterType} find yourself at the edge of the forest!");
Console.WriteLine("Do you enter the forest or camp outside? (Enter/Camp)");

string choice1 = Console.ReadLine();

if(choice1.ToLower() == "enter")
{
    Console.WriteLine("You bravely enter the forest");
}
else
{
    Console.WriteLine("You decide to camp out and wait for daylight. ");
}

bool gameCountinues = true;

while (gameCountinues)
{
    Console.WriteLine("You come to a fork in the road. Go left or right?");
    string direction = Console.ReadLine();
    if (direction.ToLower() == "left" )
    {
        Console.WriteLine("You found a treasure!!!");
        gameCountinues = false;
    }
    else
    {
        Console.WriteLine("YOu encouter a wild beast!!!");
        Console.WriteLine("Fight or flee? (Fight/Flee)");
        string fightChoice = Console.ReadLine();

        if (fightChoice.ToLower() == "fight")
        {
            Random random = new Random();
            int luck = random.Next(1, 11);
            if (luck > 5)
            {
                Console.WriteLine("You beat the wild beast!");
                if (luck > 8)
                {
                    Console.WriteLine("The wild beast dropped a treasure!");
                }
                if (luck >3)
                {
                    Console.WriteLine("The wild beast run away with treasure!!!");
                    gameCountinues = false;
                }
                else
                {
                    Console.WriteLine("The beast attacked you.....You are dead!!!");
                    gameCountinues = false;
                }
            }
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("You are a coward for fleeing. See you never!!!");
            gameCountinues= false;
        }

    }
}

Console.WriteLine("Game Over!!!");
Console.WriteLine($"Thank you for playing the game {playerName} the {characterType}");


Console.ReadKey();  