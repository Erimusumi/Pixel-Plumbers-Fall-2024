using Microsoft.Xna.Framework;

public class QuitGameCommand : ICommand
{
    private Game game;
    public QuitGameCommand(Game game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.Exit();
    }
}