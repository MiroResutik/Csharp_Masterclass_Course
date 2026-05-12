// See https://aka.ms/new-console-template for more information
//Simple calculator and string formatting
/*


//DataType variable
using System.Diagnostics.CodeAnalysis;

double myNumber1 = 0;
double myNumber2 = 0;


Console.WriteLine("Enter 1st number: ");

string userInput = Console.ReadLine();
myNumber1 = double.Parse(userInput);

Console.WriteLine("Enter 2nd number: ");

userInput = Console.ReadLine();

myNumber2 = double.Parse(userInput);
double sum = myNumber1 + myNumber2;

//String concatination
Console.WriteLine("The result of " + myNumber1 + " and " +myNumber2+ " is: " +  sum);

//String interpolation
Console.WriteLine($"The result of {myNumber1} and {myNumber2} is :{sum}");

//String formatting
Console.WriteLine("The result of {0} and {1} is: {3} ", myNumber1, myNumber1, sum);

//Special characters in string
string s1 = "this is a \"string\"  with \na backslash \\ and colon: ";
Console.WriteLine(s1);

Console.ReadKey();
*/
// Conversions
/*
//implicit conversion

int myInt = 136436;
double myDouble = myInt;


long myLong = myInt;
myLong = 12363463451;

float myFloat = 123.123f;

myDouble = myFloat;

//explicit coversion
int myInt2 = (int)myLong;
Console.WriteLine(myInt2);

// explicit coversion with casting
int myInt3;
double myDouble3 = 13.5;
myInt3 = (int)myDouble3;
Console.WriteLine(myInt3);
Console.ReadKey();
*/
//Parse and convert
/*
// conversion helpers parse and convert

string numberString = "1321";
int result = int.Parse(numberString);   

string myBoolString = "false";
bool myBool = Convert.ToBoolean(myBoolString);

Console.WriteLine("myBool is " + myBool);

Console.ReadKey();
*/
//implicitly typed variable
/*


var myFavoriteNumber = 11;
var yourFavoriteNumber = 4;

var ourNumbersCombined = myFavoriteNumber + yourFavoriteNumber;

Console.WriteLine("Our numbers combined is " + ourNumbersCombined);


Console.ReadKey();
*/
//Order of Evaluation
/*


using System.Numerics;

int num1 = 5;
int num2 = 13;

Console.WriteLine("Addition num1 + num2 = " + (num1 + num2));
Console.WriteLine("Subtraciton num1 - num2 = " + (num1 - num2));

Console.WriteLine("Multiplication num1 * num2 =" + num1 * num2);
Console.WriteLine("Division num1 / num2 = " + num1 / num2);


Console.ReadKey();
*/
//Logic

//If statements, nested if statemenet and logical oprerators
// And && OR || NOT !

int num1 = 0;
int num2 = 0;
int age = 0;
string address = "";


//is eaqual
bool isEqual = num1 == num2;
bool isNotEqual = num1 != num2;

Console.WriteLine("Please enter a whole number: ");
if (num1 == int.Parse(Console.ReadLine()))
{
    Console.WriteLine("Numbers are equal");

    Console.WriteLine("Please enter your age: ");
    age = int.Parse(Console.ReadLine()); 
    if (age >= 18)
    {
        Console.WriteLine("Please enter your address so that we can send you the price!");
        address = Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Sorry you cant get the price due to your age");
    }
}
else
{
    Console.WriteLine("Number are not equal ");
}

/*
//relational operator < <= > >=
// bool is always initialized as false 
bool isHigher = num1 > num2;
int age = 13;
bool isWithParents = true;

if (age >= 13 && isWithParents)
{
    Console.WriteLine("Go party in the club with parents");
}
else if (age > 18)
{
    Console.WriteLine("You are over 18 - Go party in the club");
}
else
{
    Console.WriteLine("You are not over 18 - Go party in the kindergarden");
}
*/
/*
bool isRainy = false;
bool hasUmbrela = true;

if (isRainy || hasUmbrela)
{
    Console.WriteLine("I am protected agains the rain");
}

if (isRainy && hasUmbrela)
{
    Console.WriteLine("I am protected agains the rain");
}

if (isRainy && hasUmbrela)
{
    Console.WriteLine("I am getting wet ");
}


Console.WriteLine("Ay OK");
*/


Console.ReadKey();