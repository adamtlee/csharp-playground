using System;
namespace dsa_lab
{
	public class Fanta
	{
		public void FantaPop()
		{
			List<int> soda = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
			// var result = string.Empty;
			var newLineInsert = false; 
			foreach (int n in soda)
			{

				if (n % 3 == 0 && n % 5 == 0)
				{
					// result += $" {n} FizzBuzz";
					Console.WriteLine("FizzBuzz");
					newLineInsert = true;
				}
				else if (n % 3 == 0)
				{
					// result += $" {n} Fizz ";
					Console.WriteLine("Fizz");
					newLineInsert = true;
				}
				else if (n % 5 == 0)
				{
					// result += $" {n} Buzz";
					Console.WriteLine("Buzz");
					newLineInsert = true;
				}
				else
				{
					// result += $" {n} ";
					Console.WriteLine(n);
					newLineInsert = true;
				}
			}
			if (newLineInsert)
			{
				Console.WriteLine(Environment.NewLine);
			}
			// Console.WriteLine(result);
		}
	}
}

