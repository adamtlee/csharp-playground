using System;
using DI.Models;
using DI.Repositories;

namespace DI.Services
{
	public class DogServices
	{
		private readonly IDogRepository _dogRepository;
		
		public DogServices(IDogRepository dogRepository)
		{
            _dogRepository = dogRepository; 
		}

		public string GroomDog(int id)
		{
            List<Dog> dogs = _dogRepository.GetDogs();
			foreach(var d in dogs)
			{
				if(d.Id == id)
				{
					return $"Grooming {d.Name} !";
				}
			}
            return "No dogs to groom!";
        }

	}
}

