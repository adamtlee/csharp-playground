using System;
namespace dsa_lab
{
	public class DsaDogs
	{
		public DsaDogs()
		{
		}

		public void DsaDogRun()
		{
            // Arrays.
            string[] dogBreedsArray = new string[] { "German Shepherd", "Jindo", "Husky", "Pitbull" };

            Console.WriteLine("Array of dogs breeds: ");

            foreach (string breed in dogBreedsArray)
            {
                Console.WriteLine(breed);
            }

            Console.WriteLine();

            // Lists.
            List<string> dogBreedsList = new List<string>() { "German Shepherd", "Jindo", "Husky", "Pitbull" };

            Console.WriteLine("String Collection of Dog breeds: ");

            foreach (string breed in dogBreedsList)
            {
                Console.WriteLine(breed);
            }

            Console.WriteLine();

            // Dictionary.
            // Declare and initialize a Dictionary of dog breeds and their country of origin
            Dictionary<string, string> dogBreeds = new Dictionary<string, string>()
            {
                { "Labrador Retriever", "United Kingdom" },
                { "German Shepherd", "Germany" },
                { "Bulldog", "United Kingdom" },
                { "Beagle", "United Kingdom" },
                { "Poodle", "France" }
            };

            // Print the elements of the Dictionary
            Console.WriteLine("List of dog breeds and their country of origin:");
            foreach (KeyValuePair<string, string> breed in dogBreeds)
            {
                Console.WriteLine(breed.Key + ": " + breed.Value);
            }

            Console.WriteLine();

            // Queue.
            Queue<string> dogsWaitingToBeAdopted = new Queue<string>();
            dogsWaitingToBeAdopted.Enqueue("Labrador Retriever");
            dogsWaitingToBeAdopted.Enqueue("German Shepherd");
            dogsWaitingToBeAdopted.Enqueue("Bulldog");
            dogsWaitingToBeAdopted.Enqueue("Beagle");
            dogsWaitingToBeAdopted.Enqueue("Poodle");

            // Process the dogs waiting to be adopted one by one
            Console.WriteLine("Dogs waiting to be adopted:");
            while (dogsWaitingToBeAdopted.Count > 0)
            {
                string dog = dogsWaitingToBeAdopted.Dequeue();
                Console.WriteLine(dog);
            }

            Console.WriteLine();


            // Stack.
            // Declare and initialize a Stack of dogs that were adopted last
            Stack<string> dogsAdoptedLast = new Stack<string>();
            dogsAdoptedLast.Push("Labrador Retriever");
            dogsAdoptedLast.Push("German Shepherd");
            dogsAdoptedLast.Push("Bulldog");
            dogsAdoptedLast.Push("Beagle");
            dogsAdoptedLast.Push("Poodle");

            // Process the dogs adopted last one by one
            Console.WriteLine("Dogs adopted last:");
            while (dogsAdoptedLast.Count > 0)
            {
                string dog = dogsAdoptedLast.Pop();
                Console.WriteLine(dog);
            }

            Console.WriteLine();

            // Hashset.
            HashSet<string> uniqueDogs = new HashSet<string>();
            uniqueDogs.Add("Labrador Retriever");
            uniqueDogs.Add("German Shepherd");
            uniqueDogs.Add("Bulldog");
            uniqueDogs.Add("Beagle");
            uniqueDogs.Add("Poodle");
            uniqueDogs.Add("Labrador Retriever");  // This will not be added, as it's a duplicate

            // Process the unique dogs
            Console.WriteLine("Unique dogs:");
            foreach (string dog in uniqueDogs)
            {
                Console.WriteLine(dog);
            }

            Console.WriteLine();

            // Linked List
            // Declare and initialize a LinkedList of dogs in the order they were adopted
            LinkedList<string> dogsAdopted = new LinkedList<string>();
            dogsAdopted.AddLast("Labrador Retriever");
            dogsAdopted.AddLast("German Shepherd");
            dogsAdopted.AddLast("Bulldog");
            dogsAdopted.AddLast("Beagle");
            dogsAdopted.AddLast("Poodle");

            // Process the dogs adopted in order
            Console.WriteLine("Dogs adopted in order:");
            foreach (string dog in dogsAdopted)
            {
                Console.WriteLine(dog);
            }

            Console.WriteLine();

            // Declare and initialize a SortedList of dogs sorted by breed
            SortedList<string, string> dogsByBreed = new SortedList<string, string>();
            dogsByBreed.Add("Labrador Retriever", "Labrador");
            dogsByBreed.Add("German Shepherd", "German Shepherd");
            dogsByBreed.Add("Bulldog", "Bulldog");
            dogsByBreed.Add("Beagle", "Beagle");
            dogsByBreed.Add("Poodle", "Poodle");

            // Process the dogs sorted by breed
            Console.WriteLine("Dogs sorted by breed:");
            foreach (KeyValuePair<string, string> dog in dogsByBreed)
            {
                Console.WriteLine(dog.Key);
            }
        }
	}
}

