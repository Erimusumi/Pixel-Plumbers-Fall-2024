using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;
using System.Threading;

public class EnemySwitch : ICommand
{
    Game1 game1;
    public EnemySwitch(Game1 game)
    {
        game1 = game;
    }

    private int count;

    private enum CommandType {GoombaCommand, KoopaCommand};
    private CommandType commandType = CommandType.GoombaCommand;

    public void Execute()
    {
        if (count == 10) {
            switch (commandType)
            {
                case CommandType.GoombaCommand:
                    game1.SetEnemyCommand(new KoopaCommand(game1.SetEnemy(new Koopa())));
                    commandType = CommandType.KoopaCommand;
                    break;
                case CommandType.KoopaCommand:
                    game1.SetEnemyCommand(new GoombaCommand(game1.SetEnemy(new Goomba())));
                    commandType = CommandType.GoombaCommand;
                    break;
            }
            count = 0;
        }
        count++;

    }
}