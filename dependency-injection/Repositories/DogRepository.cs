using System;
using DI.Models;

namespace DI.Repositories
{
	public class DogRepository : IDogRepository
	{
		public DogRepository()
		{
		}

		public List<Dog> dogs = new List<Dog>() {
			new Dog { Id = 1, Name = "Gatsby", Age = 2, Breed = "GSD" },
			new Dog { Id = 2, Name = "Smudge", Age = 3, Breed = "Jindo"}, 
		};

		public List<Dog> GetDogs()
		{
			return dogs; 
		}

		public Dog GetDogById(int id)
		{ 
			foreach(var d in dogs)
			{
				if(d.Id == id)
				{
					return d; 
				} 
			}

			return null;
		}
	}
}

