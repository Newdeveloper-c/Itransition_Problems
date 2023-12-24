using RockPaperScissors.Helpers;

namespace RockPaperScissors.Generators;

public static class TableGenerator
{
    public static void GenerateHelpTable(string[] moves)
    {
        Console.WriteLine("\nThis is help desk.\n" +
            "Right side is your moves and down computer's.\n" +
            "Above of Draws diagonal could be your results.\n");

        CalculateTable(moves, out string[,] table);

        DrawTable(moves, table);

        Console.WriteLine();
    }

    private static void DrawTable(string[] moves, string[,] table)
    {
        CalculateColLengths(moves, table, out int[] colLengths);

        for (int i = 0; i <= moves.Length; i++)
        {
            //Upper border of rows
            for (int k = 0; k <= moves.Length; k++)
                Console.Write("+" + (new string('-', colLengths[k])));
            Console.WriteLine("+");

            for (int j = 0; j <= moves.Length; j++)
            {
                Console.Write('|');
                //centering the string
                int padding = (colLengths[j] - table[i, j].Length) / 2;
                string centeredString = table[i, j].PadLeft(table[i, j].Length + padding).PadRight(colLengths[j]);
                Console.Write(centeredString);
            }
            Console.WriteLine("|");
        }

        //Last downside border
        for (int k = 0; k <= moves.Length; k++)
            Console.Write("+" + (new string('-', colLengths[k])));
        Console.WriteLine("+");
    }

    private static void CalculateColLengths(string[] moves, string[,] table, out int[] colLengths)
    {
        //Calculating lengths of each column
        colLengths = Enumerable.Range(0, table.GetLength(1))
                                  .Select(col => table[0, col].Length + 3)
                                  .ToArray();

        //Fixing too long move name for first moves column
        colLengths[0] = Math.Max(colLengths[0], moves.Max(x => x.Length));
    }

    private static void CalculateTable(string[] moves, out string[,] table)
    {
        table = new string[moves.Length + 1, moves.Length + 1];

        table[0, 0] = "v PC\\User >";
        for (int i = 1; i <= moves.Length; i++)
        {
            table[0, i] = moves[i - 1];
            table[i, 0] = moves[i - 1];
        }

        for (int i = 1; i <= moves.Length; i++)
            for (int j = 1; j <= moves.Length; j++)
                table[i, j] = StaticMembers.MoveResult(i - 1, j - 1, moves.Length) switch
                {
                    (int)EGameResult.Lose => "Lose",
                    (int)EGameResult.Draw => "Draw",
                    (int)EGameResult.Win => "Win",
                    _ => "Empty"
                };
    }

}
