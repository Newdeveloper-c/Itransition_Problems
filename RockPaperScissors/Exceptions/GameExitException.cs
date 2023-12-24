namespace RockPaperScissors.Exceptions;

public class GameExitException : Exception
{
    public GameExitException()
    {
    }

    public GameExitException(string? message) : base(message)
    {
    }
}