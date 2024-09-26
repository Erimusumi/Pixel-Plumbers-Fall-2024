using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class EnemySwitch : ICommand
{
    Game1 game1;
    public EnemySwitch(Game1 game)
    {
        game1 = game;
    }

    private enum CommandType {GoombaCommand, KoopaCommand};
    private CommandType commandType = CommandType.GoombaCommand;

    public void Execute()
    {
        switch (commandType)
        {
            case CommandType.GoombaCommand:
                game1.SetEnemyCommand(new KoopaCommand(game1.SetEnemy(new Koopa())));
                break;
            case CommandType.KoopaCommand:
                game1.SetEnemyCommand(new GoombaCommand(game1.SetEnemy(new Goomba())));
                break;
        }
    }
}