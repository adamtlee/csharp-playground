using SCE.Services;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("string-converter-exercise");
        var stringConverter = new StrConverter();
        var string1 = "The answer is 42. What's the question?";
        var resultOne = StrConverter.ReplacePunctuationWithVowel(string1);

        Console.WriteLine(string1);
        Console.WriteLine(resultOne);

        var string2 = "Hola Amigo";
        var string3 = "aeiouAEIOU";
        var resultTwo = StrConverter.ReplaceVowelWithNumber(string3);
        Console.WriteLine(resultTwo);

        var resultThree = StrConverter.ConvertFirstEightCharsVowelsToNumbers(string2);
        Console.WriteLine(resultThree);
    }
}