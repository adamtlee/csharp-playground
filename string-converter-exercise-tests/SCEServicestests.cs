

using System; 
using SCE;
using SCE.Services;

namespace string_converter_exercise_tests;

public class SCEServicestTests
{
    [Fact]
    public void ConvertFirstEightVowels_Success()
    {
        // Arrange
        var testStringOne = "Hola Amigo";

        // Act
        var sut = StrConverter.ReplaceVowelWithNumber(testStringOne);

        // Assert
        Assert.Equal("H4l1 1m3g4", sut); 

    }

    [Theory]
    [InlineData("The answer is 42. What's the question?", "Th211nsw2r13s1422aWhatosatheaquestionu")]
    [InlineData("These are not the droids you're looking for!", "Th2s211r21n4t1theadroidsayouorealookingafori")]
    public void ConvertPunctuationToVowels_Success(string testString, string expectedResult)
    {

        // Act
        // Not really idea, should probably add a method call inside ReplacePunctuationWithVowel()
        // that calls ReplaceVowelwithNumber() after completion.
        var sut = StrConverter.ReplacePunctuationWithVowel(testString);
        var result = StrConverter.ReplaceVowelWithNumber(sut);

        // Assert
        Assert.Equal(result, expectedResult);

    }

    [Theory]
    [InlineData("Hola Amigo", "H4l1 1m3go")]
    public void ConvertFirstEightCharsVowelsToNumbers_Success(string testString, string expectedResult)
    {
        // At the moment this test case is failing
        var sut = StrConverter.ConvertFirstEightCharsVowelsToNumbers(testString);

        // Assert
        Assert.Equal(sut, expectedResult); 
    }
}
