using System;
namespace dsa_lab
{
	public class Soda
	{
		public void sodaPop()
		{
			List<int> soda = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

			foreach(int n in soda)
			{
				if(n % 3 == 0 && n % 5 == 0)
				{
					Console.WriteLine($"{n} FizzBuzz"); 
				}
				else if (n % 3 == 0)
				{
					Console.WriteLine($"{n} Fizz");
				}
				else if (n % 5 == 0)
				{
					Console.WriteLine($"{n} Buzz");
				}
				else
				{
					Console.WriteLine($"{n}");
				}
			}
			
		}
	}
}

