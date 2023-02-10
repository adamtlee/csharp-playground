

using System; 
using SCE;
using SCE.Services;

namespace string_converter_exercise_tests;

public class UnitTest1
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
}
