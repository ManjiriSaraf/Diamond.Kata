namespace DiamondArt;

/// <summary>
/// Creates Diamond shape using Upper case letters
/// </summary>
public static class Diamond
{
    /// <summary>
    /// Convert Diamond List to string for printable output
    /// <typeparam name="inputCharacter" type="char">input character provided by user</typeparam>
    /// </summary>
    public static string DrawDiamondKata(char inputCharacter)
    {
        // Validate input
        if (!Char.IsUpper(inputCharacter))
        {
            // Ideally in real systems, this is where the exception will be thrown (as shown in comments below) if validation fails and it will be then handled by middlware
            // throw new Exception("Incorrect input character. Please enter Upper case letters between A-Z");

            // For the excersize purpose ONLY, returning error string
            return ("Incorrect input character. Please enter Upper case letters between A-Z");
        }

        return string.Join("\n", GenerateDiamondKata(inputCharacter).Select(x => x.ToString()));
    }

    /// <summary>
    /// Returns string which can be printed to display Diamond shape formed by sequence of characters derived from input character
    /// <typeparam name="inputCharacter" type="char">input character provided by user</typeparam>
    /// </summary>
    public static List<string> GenerateDiamondKata(char inputCharacter)
    {
        int maxWidthOfDimond = inputCharacter - 'A' + 1;
        List<string> listOfCharsInDiamond = new List<string>();

        foreach (var line in GetAllDiamondCharsInSequence(maxWidthOfDimond))
        {
            listOfCharsInDiamond.Add(GetLine(maxWidthOfDimond, line));
        }

        return listOfCharsInDiamond;
    }

    /// <summary>
    /// Returns a tuple with character and its position in sequence depending upton max width of the Diamond 
    /// <typeparam name="maxWidthOfDimond" type="int">represents max width for the Diamond shape</typeparam>
    /// </summary>
    private static (char, int)[] GetAllDiamondCharsInSequence(int maxWidthOfDimond)
    {
        // Get letters for upper half of the Diamond
        var upperHalfLetters = Enumerable
                   .Range('A', maxWidthOfDimond)
                   .Select((c, i) => ((char)c, i))
                   .ToArray();

        // Concate upper half letters to lower half letters of the Diamond to get complete set of letter collection in required sequence
        var diamondLettersCollection = upperHalfLetters.Concat(upperHalfLetters.Reverse().Skip(1)).ToArray();
        return diamondLettersCollection;
    }

    /// <summary>
    /// Returns a string which corresponds to the combination of char and the row on which it needs to be printed
    /// <typeparam name="maxWidthOfDimond" type="int">represents max width for the Diamond shape</typeparam>
    /// <typeparam name="charOnRow" type="(char, int)">tuple which provides the char and row position in Diamond shape</typeparam>
    /// </summary>
    private static string GetLine(int maxWidthOfDimond, (char, int) charOnRow)
    {
        var (c, row) = charOnRow;
        var sidePadding = "".PadRight(maxWidthOfDimond - row - 1);
        var inBetweenSpace = "".PadRight(row == 0 ? 0 : row * 2 - 1);
        return c == 'A' ? $"{sidePadding}{c}{sidePadding}" : $"{sidePadding}{c}{inBetweenSpace}{c}{sidePadding}";
    }
}

