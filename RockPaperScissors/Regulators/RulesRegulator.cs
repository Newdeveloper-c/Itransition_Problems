using RockPaperScissors.Helpers;

namespace RockPaperScissors.Regulators;

public class RulesRegulator
{
    private readonly string[] _moves;
    public Dictionary<string, string> AviableMoves { get; init; } = new();    

    public RulesRegulator(string[] moves)
    {
        _moves = moves;

        for (int i = 1; i <= _moves.Length; i++)
            AviableMoves.Add(i.ToString(), _moves[i - 1]);
        AviableMoves.Add("0", "exit");
        AviableMoves.Add("?", "help");
    }

    private bool CheckForDublicates() => _moves.GroupBy(x => x).Any(group => group.Count() > 1);

    public bool CheckMoves() => _moves.Length > 1 && _moves.Length % 2 != 0 && !CheckForDublicates();

    public int CheckUserMove(string userMove)
    {
        if (!AviableMoves.ContainsKey(userMove))
            return (int)EUserMoveStatus.Error;

        if (userMove == StaticMembers.help)
            return (int)EUserMoveStatus.Help;

        if(userMove == StaticMembers.exit)
            return (int)EUserMoveStatus.Exit;

        return (int)EUserMoveStatus.Success;
    }

    public string FindWinner(string computerMove, string userMove) 
    {
        int result = StaticMembers.MoveResult(int.Parse(userMove) - 1, int.Parse(computerMove) - 1, _moves.Length);
        return result == (int)EGameResult.Draw ? "Draw!" 
            : result == (int)EGameResult.Win ? "You win!"
            : "Computer win!";
    }
}
