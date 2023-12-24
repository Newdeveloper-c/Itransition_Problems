using RockPaperScissors.Exceptions;
using RockPaperScissors.Managers;

var game = new GameManager(args);

try
{
    game.Start();
    game.Process();
    game.End();
}
catch (WrongInputMovesException ex)
{
    Console.WriteLine(ex.Message);
}
catch (GameExitException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}






