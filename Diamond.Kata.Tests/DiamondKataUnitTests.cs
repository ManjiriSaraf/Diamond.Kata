using Xunit;

namespace Diamond.Kata.Tests;

public class DiamondKataUnitTests
{

    /// <summary>
    /// Checks if validation error message is displayed when unsupportted input char is provided as input. 
    /// </summary>
    [Theory]
    [InlineData('0')]
    [InlineData('?')]
    [InlineData('a')]
    public void TestIfValidationErrorOnInvalidInput(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.DrawDiamondKata(inputChar);
        string errorMessage = "Incorrect input character";

        Assert.Contains(errorMessage, outputDiamond);
    }

    /// <summary>
    /// Checks output is not empty
    /// </summary>
    [Theory]
    [InlineData('A')]
    [InlineData('I')]
    [InlineData('Z')]
    public void TestIfOutputIsNotEmpty(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.DrawDiamondKata(inputChar);

        Assert.False(string.IsNullOrEmpty(outputDiamond));
    }

    /// <summary>
    /// Check if output string size test.
    /// </summary>
    [Fact]
    public void TestIfOutputStringSizeIsCorrect()
    {
        Assert.Equal(1, DiamondArt.Diamond.DrawDiamondKata('A').Replace(" ", string.Empty).Replace("\n", string.Empty).Length);
        Assert.Equal(4, DiamondArt.Diamond.DrawDiamondKata('B').Replace(" ", string.Empty).Replace("\n", string.Empty).Length);
        Assert.Equal(8, DiamondArt.Diamond.DrawDiamondKata('C').Replace(" ", string.Empty).Replace("\n", string.Empty).Length);
    }

    /// <summary>
    /// Checks if output is correct for input 'A'. 
    /// </summary>
    [Fact]
    public void TestIfOutputIsCorrectForInput_A()
    {
        var outputDiamond = DiamondArt.Diamond.GenerateDiamondKata('A');

        Assert.True(outputDiamond.Count == 1);
        Assert.True(outputDiamond[0] == ('A').ToString());
    }

    /// <summary>
    /// Check if first and last character is A
    /// </summary>
    [Theory]
    [InlineData('A')]
    [InlineData('I')]
    [InlineData('Z')]
    public void TestIfFirstAndLastCharIsA(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.GenerateDiamondKata(inputChar);

        Assert.True(outputDiamond.First().Contains('A'));
        Assert.True(outputDiamond.Last().Contains('A'));
    }

    /// <summary>
    /// Checks if Diamond's width and height is equal
    /// </summary>
    [Theory]
    [InlineData('A')]
    [InlineData('I')]
    [InlineData('Z')]
    public void TestIfDiamondWidthAndHeightIsEuqal(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.GenerateDiamondKata(inputChar);

        Assert.True(outputDiamond.All(row => row.Length == outputDiamond.Count));
    }

    /// <summary>
    /// Checks if Diamond shape is correctely drawn with the accurate data 
    /// </summary>
    [Theory]
    [InlineData('A')]
    [InlineData('B')]
    [InlineData('I')]
    [InlineData('O')]
    [InlineData('Y')]
    [InlineData('Z')]
    public void TestIfDiamondShapeDataIsCorrect(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.GenerateDiamondKata(inputChar);
        int middleRow = (outputDiamond.Count / 2) + 1;
        bool result = true;

        for (int i = 1; i < middleRow; i++)
        {
            if(!(outputDiamond[middleRow - i - 1].SequenceEqual(outputDiamond[middleRow + i - 1])))
                result = false;
        }

        Assert.True(result);
    }

    /// <summary>
    /// Checks if spaces count on left and right side of the letter in a row matches. 
    /// </summary>
    [Theory]
    [InlineData('A')]
    [InlineData('I')]
    [InlineData('Z')]
    public void TestIfSpacesCountOnLeftAndRightOfLetterInRowMatches(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.GenerateDiamondKata(inputChar);

        Assert.True(outputDiamond.All(line => LeftPaddingFirstOccuranceOfLetterCount(line) == RightPaddingFirstOccuranceOfLetterCount(line)));
    }


    /// <summary>
    /// Checks if spaces count on left and right side of the letter in a row matches. 
    /// IMP NOTE*** This test case does not apply to input 'A'
    /// </summary>
    [Theory]
    [InlineData('B')]
    [InlineData('I')]
    [InlineData('Z')]
    public void TestIfInnerPaddingForMiddleRowIsCorrect(char inputChar)
    {
        var outputDiamond = DiamondArt.Diamond.GenerateDiamondKata(inputChar);
        int middleRow = (outputDiamond.Count / 2) + 1;

        Assert.True(RightPaddingFirstOccuranceOfLetterCount(outputDiamond[middleRow]) 
                == LeftPaddingFirstOccuranceOfLetterCount(outputDiamond[middleRow]));
    }



    #region Supporting Functions

    /// <summary>
    /// Returns spaces on left side of first occurance of the letter in the string
    /// <typeparam name="s" type="string">string input</typeparam>
    /// </summary>
    private static int LeftPaddingFirstOccuranceOfLetterCount(string s)
    {
        return s.IndexOf(s.First(x => x != ' '));
    }

    /// <summary>
    /// Returns spaces on right side of first occurance of the letter in the string
    /// <typeparam name="s" type="string">string input</typeparam>
    /// </summary>
    private static int RightPaddingFirstOccuranceOfLetterCount(string s)
    {
        var i = s.LastIndexOf(s.First(x => x != ' '));
        return s.Length - i - 1;
    }

    /// <summary>
    /// Returns spaces on left side of last occurance of the letter in the string
    /// <typeparam name="s" type="string">string input</typeparam>
    /// </summary>
    private static int LeftPaddingLastOccuranceOfLetterCount(string s)
    {
        return s.IndexOf(s.Last(x => x != ' '));
    }

    /// <summary>
    /// Returns spaces on right side of last occurance of the letter in the string
    /// <typeparam name="s" type="string">string input</typeparam>
    /// </summary>
    private static int RightPaddingLastOccuranceOfLetterCount(string s)
    {
        var i = s.LastIndexOf(s.Last(x => x != ' '));
        return s.Length - i - 1;
    }

    #endregion

}