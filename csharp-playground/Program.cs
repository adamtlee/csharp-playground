namespace csharp_playground;

abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void MakeNoise();
}

class Dog : Animal
{
    public Dog(string name, int age) : base(name, age) { }

    public override void MakeNoise()
    {
        Console.WriteLine("Woof woof!");
    }
}


class Program
{
    public static void Main(string[] args)
    {
        Dog dog = new Dog("Gatsby", 2);
        Console.WriteLine($"Dog Name: {dog.Name} - Dog Age: {dog.Age}");
        dog.MakeNoise(); 
    }
}
