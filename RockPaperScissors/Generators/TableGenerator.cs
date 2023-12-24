namespace RockPaperScissors.Generators;

public class TableGenerator
{
    private readonly string[] _moves;
    private string[,] table;

    public TableGenerator(string[] moves)
    {
        _moves = moves;
    }

    public void GenerateHelpTable()
    {
        CalculateTable();

        DrawTable();
    }

    private void DrawTable()
    {
        int tblLength = _moves.Length;

        CalculateColLengths(out int[] colLengths);

        for (int i = 0; i <= tblLength; i++)
        {
            //Upper border of rows
            for (int k = 0; k <= tblLength; k++)
                Console.Write("+" + (new string('-', colLengths[k])));
            Console.WriteLine("+");

            for (int j = 0; j <= tblLength; j++)
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
        for (int k = 0; k <= tblLength; k++)
            Console.Write("+" + (new string('-', colLengths[k])));
        Console.WriteLine("+");
    }

    private void CalculateColLengths(out int[] colLengths)
    {
        //Calculating lengths of each column
        colLengths = Enumerable.Range(0, table.GetLength(1))
                                  .Select(col => table[0, col].Length + 3)
                                  .ToArray();

        //Fixing too long move name for first moves column
        colLengths[0] = Math.Max(colLengths[0], _moves.Max(x => x.Length));
    }


    private void CalculateTable()
    {
        int numbOf_moves = _moves.Length;
        int halfNumb = numbOf_moves / 2;
        table = new string[numbOf_moves + 1, numbOf_moves + 1];

        table[0, 0] = "v PC\\User >";
        for (int i = 1; i <= numbOf_moves; i++)
        {
            table[0, i] = _moves[i - 1];
            table[i, 0] = _moves[i - 1];
        }

        for(int i = 1;i <= numbOf_moves; i++)
            for (int j = 1; j <= numbOf_moves; j++)
                table[i, j] = Math.Sign((j - i + halfNumb + numbOf_moves) % numbOf_moves - halfNumb) switch
                {
                    -1 => "Lose",
                    0 => "Draw",
                    1 => "Win"
                };
    }
}
