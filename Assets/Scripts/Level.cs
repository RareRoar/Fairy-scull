
public static class Level
{
    private static string[][] matrix;

    static Level()
    {
        matrix = new string[7][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new string[7];
        }
        CurrentPosition = new Pair(3, -1);
    }

    public static Pair CurrentPosition { get; set; }

    public static void Initialize(string[][] inMatrix)
    {
        for (int i = 0; i < inMatrix.Length; i++)
        {
            for (int j = 0; j < inMatrix[i].Length; j++)
            {
                    matrix[i][j] = inMatrix[i][j];
                
            }
        }
    }

    public static string Matrix()
    {
        if (CurrentPosition.Y == -1)
        {
            return "Enter";
        }
        return matrix[CurrentPosition.X][CurrentPosition.Y];
    }

    public static string Matrix(int i, int j) {
        return matrix[i][j];
    }
}
