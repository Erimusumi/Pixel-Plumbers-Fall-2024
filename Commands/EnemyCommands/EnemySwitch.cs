using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System.Globalization;

public class EnemySwitch : ICommand
{
    Game1 game1;
    //0 is P, 1 is O
    int PorO;
    public EnemySwitch(Game1 game, int _PorO)
    {
        game1 = game;
        PorO = _PorO;
    }

    private enum CommandType {GoombaCommand, CheepRedCommand, KoopaCommand, CheepGreenCommand};
    private CommandType commandType = CommandType.GoombaCommand;

    public void Execute()
    {
        if (PorO == 0)
        {
            switch (commandType)
            {
                case CommandType.GoombaCommand:
                    game1.SetEnemyCommand(new CheepsCommand(game1.SetEnemy(new Cheeps(0, 480, 400))));
                    commandType = CommandType.CheepRedCommand;
                    break;
                case CommandType.CheepRedCommand:
                    game1.SetEnemyCommand(new KoopaCommand(game1.SetEnemy(new Koopa(480, 400))));
                    commandType = CommandType.KoopaCommand;
                    break;
                case CommandType.KoopaCommand:
                    game1.SetEnemyCommand(new CheepsCommand(game1.SetEnemy(new Cheeps(1, 480, 400))));
                    commandType = CommandType.CheepGreenCommand;
                    break;
                case CommandType.CheepGreenCommand:
                    game1.SetEnemyCommand(new GoombaCommand(game1.SetEnemy(new Goomba(480, 400))));
                    commandType = CommandType.GoombaCommand;
                    break;
            }
        } else
        {
            switch (commandType) {
                case CommandType.GoombaCommand:
                    game1.SetEnemyCommand(new CheepsCommand(game1.SetEnemy(new Cheeps(1, 480, 400))));
                    commandType = CommandType.CheepGreenCommand;
                    break;
                case CommandType.CheepRedCommand:
                    game1.SetEnemyCommand(new GoombaCommand(game1.SetEnemy(new Goomba(480, 400))));
                    commandType = CommandType.GoombaCommand;
                    break;
                case CommandType.KoopaCommand:
                    game1.SetEnemyCommand(new CheepsCommand(game1.SetEnemy(new Cheeps(0, 480, 400))));
                    commandType = CommandType.CheepRedCommand;
                    break;
                case CommandType.CheepGreenCommand:
                    game1.SetEnemyCommand(new KoopaCommand(game1.SetEnemy(new Koopa(480, 400))));
                    commandType = CommandType.KoopaCommand;
                    break;
                }
            }
    }
}