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
            string vowels = "aeiouAEIOU";

            foreach (char c in s)
            {
                if (vowelCounter >= 8)
                {
                    result += c;
                }
                else if (vowels.IndexOf(c) != -1)
                {
                    vowelCounter++;
                    switch (c)
                    {
                        case 'a':
                        case 'A':
                            result += '1';
                            break;
                        case 'e':
                        case 'E':
                            result += '2';
                            break;
                        case 'i':
                        case 'I':
                            result += '3';
                            break;
                        case 'o':
                        case 'O':
                            result += '4';
                            break;
                        case 'u':
                        case 'U':
                            result += '5';
                            break;
                    }
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
	}
}

