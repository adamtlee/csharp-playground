using System;
using DI.Models;

namespace DI.Repositories
{
	public interface IDogRepository
	{
        public List<Dog> GetDogs();

        public Dog GetDogById(int id);

    }
}

