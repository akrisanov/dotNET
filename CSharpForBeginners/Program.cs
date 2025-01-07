// Strings -----------------------------------------------------------------------------------------

using ConsoleApp1;

string firstName = "Andrey";
string lastName = "Krisanov";

Console.WriteLine($"My name is {firstName} {lastName}");

int age = 30;

Console.WriteLine($"I am {age} years old");

// Numbers -----------------------------------------------------------------------------------------

int a = 2_147_483_647;
int b = 2_147_483_647;
// will overflow anyway
long c = a + b;
// we could use the checked keyword to throw an exception if the result is too large
// long c = checked(a + b);
long d = (long)a + (long)b;

Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}");

double answer = 42.5; // double is a 64-bit floating-point number
float answer2 = 34.2f; // float is a 32-bit floating-point number
double result = answer + answer2;

decimal result2 = 42.5m + 34.2m; // decimal is a 128-bit floating-point number

Console.WriteLine($"double: {answer}, float: {answer2}");
Console.WriteLine($"double sum: {result}, decimal sum: {result2})");

// While loop --------------------------------------------------------------------------------------

int counter = 0;
while (counter < 5)
{
    counter++;
    Console.WriteLine($"Counter is {counter}");
}

do
{
    Console.WriteLine($"Counter is {counter}");
} while (counter < 5);

// For loop ----------------------------------------------------------------------------------------

for (int i = 0; i < 10; i++)
{
    Console.Write(i);
    Console.Write(" ");
    if (i == 3)
    {
        Console.WriteLine();
        break;
    }
}

// List<T> and Collections of data -----------------------------------------------------------------

var names = new List<string> { "Andrey", "Maria", "Mark" };
foreach (var name in names[..3]) // example of range operator
{
    Console.Write(name);
    Console.Write(" ");
}
Console.WriteLine("are family.");

names.Add("Mira");
// ^ operator is used to index from the end of the list
Console.WriteLine($"Added {names[^1]} to the family.");

var ages = new List<int> { 35, 36, 11 };
// sorting the list in place
ages.Sort();

// Arrays ------------------------------------------------------------------------------------------

var nameArray = new string[] { "Andrey", "Maria", "Mark" };
names = [.. names, "Mira"]; // using the spread operator to create a new list with the new element


// LINQ --------------------------------------------------------------------------------------------

List<int> scores = [3, 4, 100, 97, 100, 81, 60]; // using collection expression to initialize a list

for (int i = 0; i < scores.Count; i++)
{
    if (scores[i] > 80)
    {
        Console.WriteLine($"Score {scores[i]} is higher than 80");
    }
}

Console.WriteLine("Using LINQ:");

// define the query expression
// the query is not executed until it is evaluated in the foreach loop!
// compiles down to the sequence of method calls!
IEnumerable<int> scoreQuery =
    from score in scores
    where score > 80
    orderby score descending
    select score;

var scoreQueryWithMethodSyntax = scores
    .Where(s => s > 80)
    .OrderByDescending(s => s);

// execute the query
foreach (int score in scoreQueryWithMethodSyntax)
{
    Console.WriteLine($"Score {score} is higher than 80");
}

// this is the same as the previous query, but we form output strings in the select clause
IEnumerable<string> scoreQuery2 =
    from score in scores
    where score > 80
    orderby score descending
    select $"Score {score} is higher than 80";

// we can call methods on the query expression like so
// the query will be executed when we call the Count method!
var highScoreCount = scoreQuery.Count();

List<int> myScores = scoreQuery.ToList();

// Using custom types ------------------------------------------------------------------------------

List<Person> family =
[
    new Person("Andrey", "Krisanov", 35),
    new Person("Maria", "Krisanova", 36),
    new Person("Mark", "Krisanov", 11)
];

Console.WriteLine(family[0]);

family[^1].Pets.Add(new Cat("Murka"));

Console.WriteLine($"{family[^1].FirstName} has {family[^1].Pets.Count} pets.");

foreach (var p in family[^1].Pets)
{
    Console.WriteLine(p);
}
