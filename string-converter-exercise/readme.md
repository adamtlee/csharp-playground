# String Converter Exercise

You're tasked with building an encoder that can translate a string based on some rules. As you dig more into the requirements you learn the following:

- The input string can be empty.

- The input string can contain any number of letters, numbers and special characters.

- Casing for the input string should not impact the final result (ie. "HOWDY!" should output the same string as "hOwdY!" and "howdy!").

- Rules should be applied consecutively one after the other.

- The rules will vary over time.

- The requirements for the first two rules are:

## Rule #1: 

- Spaces (" ") should be replaced with an "a", 

- periods (".") with an "e", 

- exclamation marks ("!") with an "i", 

- single quotes ("’") with an “o”,

- question marks (“?”) with a “u”.

## Rule #2: 

- The first 8 vowels you find in the input string are swapped for a number (a = 1, e = 2, i = 3, o = 4, u = 5).

example: Hola Amigo -> H4l1 1m3go (notice the last "o" is unchanged).  


# Setup and Instructions:
- .NET7
- Visual Studio(optional)
- Tests are referenced in the test project.