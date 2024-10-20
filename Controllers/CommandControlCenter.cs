using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System.Globalization;
public class CommandControlCenter
{
    private Game1 game;
    private KeyboardController keyboardController;

    public CommandControlCenter(Game1 game)
    {
        this.game = game;
        this.keyboardController = new KeyboardController();
        game.SetKey(keyboardController);
        InitializeCommmands();
    }

    private void InitializeCommmands()
    {
        // commands for switching enemy
        List<ISpriteEnemy> enemies = new List<ISpriteEnemy>();
        enemies.Add(new Goomba(480, 400));
        enemies.Add(new Cheeps(0, 480, 400));
        enemies.Add(new Koopa(480, 400));
        enemies.Add(new Cheeps(1, 480, 400));

        ICommand EnemySwitchP = new EnemySwitch(game, 0, enemies);
        ICommand EnemySwitchO = new EnemySwitch(game, 1, enemies);
        keyboardController.addCommand(Keys.P, EnemySwitchP);
        keyboardController.addCommand(Keys.O, EnemySwitchO);

        // command for switching blocks
        ICommand blockTCommand = new blockTCommand(game);
        ICommand blockYCommand = new blockYCommand(game);
        keyboardController.addCommand(Keys.T, blockTCommand);
        keyboardController.addCommand(Keys.Y, blockYCommand);
    }
}
