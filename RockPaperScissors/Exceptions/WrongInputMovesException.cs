namespace RockPaperScissors.Exceptions;

public class WrongInputMovesException : Exception
{
    public WrongInputMovesException()
    {
    }

    public WrongInputMovesException(string? message) : base(message)
    {
    }
}