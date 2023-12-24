namespace RockPaperScissors.Helpers;

public static class StaticMembers
{
    public const string help = "?";
    public const string exit = "0";

    public static int MoveResult(int userMove, int computerMove, int movesCount)
    => Math.Sign((userMove - computerMove + (movesCount / 2) + movesCount) % movesCount - (movesCount / 2));
}