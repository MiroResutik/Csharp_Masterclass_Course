// See https://aka.ms/new-console-template for more information
/*
//Simple calculator

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

Console.ReadKey();
*/
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
/*
// conversion helpers parse and convert

string numberString = "1321";
int result = int.Parse(numberString);   

string myBoolString = "false";
bool myBool = Convert.ToBoolean(myBoolString);

Console.WriteLine("myBool is " + myBool);

Console.ReadKey();
*/
/*
//implicitly typed variable

var myFavoriteNumber = 11;
var yourFavoriteNumber = 4;

var ourNumbersCombined = myFavoriteNumber + yourFavoriteNumber;

Console.WriteLine("Our numbers combined is " + ourNumbersCombined);


Console.ReadKey();
*/

//Order of Evaluation

using System.Numerics;

int num1 = 5;
int num2 = 13;

Console.WriteLine("Addition num1 + num2 = " + (num1 + num2));
Console.WriteLine("Subtraciton num1 - num2 = " + (num1 - num2));

Console.WriteLine("Multiplication num1 * num2 =" + num1 * num2);
Console.WriteLine("Division num1 / num2 = " + num1 / num2);


Console.ReadKey();