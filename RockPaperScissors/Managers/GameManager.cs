using RockPaperScissors.Exceptions;
using RockPaperScissors.Generators;
using RockPaperScissors.Helpers;
using RockPaperScissors.Regulators;

namespace RockPaperScissors.Managers;

public class GameManager
{
    private readonly string[] _moves;
    private readonly RulesRegulator _rulesRegulator;
    private string key = null!;
    private string hmac = null!;
    private string computerMove = null!;
    private string userMove = null!;

    public GameManager(string[] moves)
    {
        _moves = moves;
        _rulesRegulator = new RulesRegulator(moves);
    }

    public void Start()
    {
        if (!_rulesRegulator.CheckMoves())
        {
            PrintCorrectMovesExample();
            throw new WrongInputMovesException("Game has ended. Please restart !!!");
        }

        CalculateHmac();

        Console.WriteLine($"HMAC: {hmac}");
    }

    public void Process()
    {
        while (true)
        {
            PrintMenu();

            GetUserMove();

            var userMoveStatus = _rulesRegulator.CheckUserMove(userMove);
            if (userMoveStatus != (int)EUserMoveStatus.Error)
            {
                Console.WriteLine($"Your move: {_rulesRegulator.AviableMoves[userMove]}");

                if (userMoveStatus == (int)EUserMoveStatus.Help)
                    PrintHelpTable();
                else if (userMoveStatus == (int)EUserMoveStatus.Exit)
                    throw new GameExitException("Game has ended.");
                else
                    break;
            }
            else
                PrintCorrectMoveExample();
        }
    }

    public void End()
    {
        Console.WriteLine($"Computer move: {_rulesRegulator.AviableMoves[computerMove]}");

        var result = _rulesRegulator.FindWinner(computerMove, userMove);

        Console.WriteLine(result);

        Console.WriteLine($"HMAC key: {key}");
    }

    private void PrintCorrectMovesExample()
    {
        Console.WriteLine("!!! Wrong Input !!! \n" +
            "The number of entered moves must be odd and greater than 1 with no dublications \n" +
            "For example:\n" +
            "Rock\n" +
            "Rock Paper Scissors\n" +
            "Rock Paper Scissors Lizard Spock\n" +
            "and so on. Please try again !!!\n");
    }

    private void GetUserMove()
    {
        Console.Write("Enter your move: ");

        userMove = Console.ReadLine() ?? "";
    }

    private void PrintMenu()
    {
        Console.WriteLine("Aviable moves:");

        for (int i = 1; i <= _moves.Length; i++)
            Console.WriteLine($"{i} - {_moves[i - 1]}");

        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    private void PrintCorrectMoveExample()
    {
        Console.WriteLine("\nYou have entered wrong move. Please enter one of these: ");
        Console.WriteLine(string.Join(", ", _rulesRegulator.AviableMoves.Keys), "\n\n");
    }

    private void PrintHelpTable()
    {
        TableGenerator.GenerateHelpTable(_moves);
    }

    private void CalculateHmac()
    {
        key = KeyGenarator.GenerateKey();

        computerMove = new Random().Next(1, _moves.Length + 1).ToString();

        hmac = HmacGenerator.GenerateSHA2Hmac(key, _rulesRegulator.AviableMoves[computerMove]);
    }
}