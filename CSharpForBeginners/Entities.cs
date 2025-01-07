namespace ConsoleApp1;

// Defining a class with a primary constructor
public class Person(string firstName, string lastName, int age)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public int Age { get; } = age;

    public List<Pet> Pets { get; } = [];

    // override abstract ToString method
    public override string ToString() => $"{FirstName} {LastName} is {Age} years old.";
}

// -------------------------------------------------------------------------------------------------

// creating a blueprint for a pet
public abstract class Pet(string name)
{
    public string Name { get; } = name;
    public abstract string MakeNoise();

    public override string ToString() => $"{Name} says {MakeNoise()}";
}

public class Cat(string name) : Pet(name)
{
    public override string MakeNoise() => "Meow";
}

public class Dog(string name) : Pet(name)
{
    public override string MakeNoise() => "Bark";
}
