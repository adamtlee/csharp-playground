using System;
namespace SCE.Services
{
	public class StrConverter
	{
		public StrConverter()
		{
		}

        public static string ConvertFirstEightCharsVowelsToNumbers(string s)
        {
            int length = s.Length;
            int n = length > 8 ? 8 : length;

            string output = "";
            for (int i = 0; i < n; i++)
            {
                char c = s[i];
                switch (c)
                {
                    case 'a':
                    case 'A':
                        output += '1';
                        break;
                    case 'e':
                    case 'E':
                        output += '2';
                        break;
                    case 'i':
                    case 'I':
                        output += '3';
                        break;
                    case 'o':
                    case 'O':
                        output += '4';
                        break;
                    case 'u':
                    case 'U':
                        output += '5';
                        break;
                    default:
                        output += c;
                        break;
                }
            }

            Console.WriteLine("Converted string: " + output + s.Substring(n));
            return output + s.Substring(n); 
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

