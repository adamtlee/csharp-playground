using DI.Services;
using DI.Models;
using DI.Repositories;

namespace dependency_injection;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Dogs Rule!");

        IDogRepository dr = new DogRepository(); 

        DogServices ds = new DogServices(dr);

        var serviceResult = ds.GroomDog(1);

        Console.WriteLine(serviceResult);
        Console.WriteLine();

        var result = dr.GetDogs();

        foreach(var r in result)
        {
            Console.WriteLine(r.Name);
            Console.WriteLine(r.Age);
            Console.WriteLine(r.Breed);
            Console.WriteLine();
        }

        var dogOne = dr.GetDogById(2);

        Console.WriteLine(dogOne.Name);
        Console.WriteLine(dogOne.Age);
        Console.WriteLine(dogOne.Breed);



    }
}

