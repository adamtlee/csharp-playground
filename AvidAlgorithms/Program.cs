namespace AvidAlgorithms;
class Program
{
    public static void Main(string[] args)
    {
        string[] words = { "baby", "referee", "cat", "dada", "dog", "bird", "ax", "baz" };
        var noteOne = "ctay";

        var noteTwo = "bcanihjsrrrferet";

        var result = FindMatchWords(words, noteTwo);
        Console.WriteLine(result);
    }

    public static string FindMatchWords(string[] words, string note)
    {
        // Sort the characters in the note string in alphabetical order
        char[] noteChars = note.ToCharArray();
        Array.Sort(noteChars);
        note = new string(noteChars);

        // Iterate through each word in the words array
        foreach (string word in words)
        {
            // Sort the characters in the current word in alphabetical order
            char[] wordChars = word.ToCharArray();
            Array.Sort(wordChars);
            string sortedWord = new string(wordChars);

            // Check if the sorted word matches the sorted note string
            if (sortedWord.Equals(note))
            {
                // If there is a match, return the word and exit the method
                return word;
            }
        }

        // If no matches were found, return "-"
        return "-";
    }

    public static string FindMatch(string[] words, string note1)
    {
        foreach (string word in words)
        {
            // Check if the word can be formed using the letters in note1
            bool isMatch = true;
            foreach (char c in word)
            {
                if (note1.IndexOf(c) == -1)
                {
                    isMatch = false;
                    break;
                }
                note1 = note1.Remove(note1.IndexOf(c), 1);
            }

            if (isMatch)
            {
                return word;
            }

            // Reset note1 for the next word
            note1 = new string(note1.OrderBy(c => c).ToArray());
        }

        // If no matches were found, return "-"
        return "-";
    }

    static bool isScramble(string S1, string S2)
    {

        // Strings of non-equal length
        // cant' be scramble strings
        if (S1.Length != S2.Length)
        {
            return false;
        }

        int n = S1.Length;

        // Empty strings are scramble strings
        if (n == 0)
        {
            return true;
        }

        // Equal strings are scramble strings
        if (S1.Equals(S2))
        {
            return true;
        }

        // Converting string to 
        // character array
        char[] tempArray1 = S1.ToCharArray();
        char[] tempArray2 = S2.ToCharArray();

        // Checking condition for Anagram
        Array.Sort(tempArray1);
        Array.Sort(tempArray2);

        string copy_S1 = new string(tempArray1);
        string copy_S2 = new string(tempArray2);

        if (!copy_S1.Equals(copy_S2))
        {
            return false;
        }

        for (int i = 1; i < n; i++)
        {

            // Check if S2[0...i] is a scrambled
            // string of S1[0...i] and if S2[i+1...n]
            // is a scrambled string of S1[i+1...n]
            if (isScramble(S1.Substring(0, i),
                           S2.Substring(0, i)) &&
                isScramble(S1.Substring(i, n - i),
                           S2.Substring(i, n - i)))
            {
                return true;
            }

            // Check if S2[0...i] is a scrambled
            // string of S1[n-i...n] and S2[i+1...n]
            // is a scramble string of S1[0...n-i-1]
            if (isScramble(S1.Substring(0, i),
                           S2.Substring(n - i, i)) &&
                isScramble(S1.Substring(i, n - i),
                           S2.Substring(0, n - i)))
            {
                return true;
            }
        }

        // If none of the above
        // conditions are satisfied
        return false;
    }

    public static string Find(string[] words, string note)
    {
        foreach(string w in words)
        {
            if(new HashSet<char>(w) .SetEquals(note) && w.OrderBy(c => c).SequenceEqual(note.OrderBy(c => c)))
            {
                return w;
            }
        }
        return "why";
    }

}

