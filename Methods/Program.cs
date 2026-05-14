//Methods

// Synatax - <Access Specifier> <Return Type> <Method Name> (Parameter List) { Method Body }
/*
//Declare method
void MyFirstMethod()
{
    Console.WriteLine("MyFirstMethod was called");
}

Console.WriteLine("This is outside of the method");

//Calling a Method
MyFirstMethod();

void WriteSomethingSpecific(string myString)
{


    Console.WriteLine("You passed this argument to me " +myString);
}
//Calling the method using an Argument
string myUsername = "Miro";
WriteSomethingSpecific("Stupid");
WriteSomethingSpecific(myUsername);
*/



int AddTwoValues(int value1, int value2)
{
    int result = value1 + value2;
    return result;
}

int SubtractTwoValues(int value1, int value2)
{
    int result = value1 - value2;
    return result;
}

Console.WriteLine("Enter an integer: ");
int num1 = int.Parse(Console.ReadLine());

int myResultAdd = AddTwoValues(num1, 10);
int myResultSubtract = SubtractTwoValues(num1, 10);
Console.WriteLine("The result is " +myResultAdd);
Console.WriteLine("The result is " + myResultSubtract);


Console.ReadKey();
