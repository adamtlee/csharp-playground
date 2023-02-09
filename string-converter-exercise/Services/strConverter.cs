using System;
namespace SCE.Services
{
	public class strConverter
	{
		public strConverter()
		{
		}

		public static string ReplacePunctuationWithVowel(string s)
		{
			var result = s
					.Replace(" ", "a")
					.Replace(".", "e")
					.Replace("!", "i")
					.Replace("\'", "o")
					.Replace("?", "u");

			return result; 
		}

		public static string ReplaceVowelWithNumber(string s)
		{
			int vowelCounter = 0;
			string result = "";
			foreach(char c in s)
			{
				if(c.Equals('a') && vowelCounter > 9)
				{
					vowelCounter++;
					result.Replace(c, '1');
				}
			}

			return result;
		}
	}
}

