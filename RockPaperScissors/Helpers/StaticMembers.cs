namespace RockPaperScissors.Helpers;

public static class StaticMembers
{
    public const string help = "?";
    public const string exit = "0";

    public static int MoveResult(int computerMove, int userMove, int movesCount)
    => Math.Sign((computerMove - userMove + (movesCount / 2) + movesCount) % movesCount - (movesCount / 2));
}