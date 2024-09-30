using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System.Globalization;
public class CommandControlCenter
{

    private ICommand blockTCommand;
    private ICommand blockYCommand;

    private Texture2D marioTexture;
    private Game1 game;
    private KeyboardController keyboardController;

    public CommandControlCenter(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        this.keyboardController = new KeyboardController();
        game.SetKey(keyboardController);
        InitializeCommmands();
    }

    private void InitializeCommmands()
    {
        // commands for switching enemy
        ICommand EnemySwitch = new EnemySwitch(game);
        keyboardController.addCommand(Keys.P, EnemySwitch);
        keyboardController.addCommand(Keys.O, EnemySwitch);

        // commands for mario movement
        ICommand moveLeftCommand = new MoveLeftMarioCommand(game, marioTexture);
        ICommand moveRightCommand = new MoveRightMarioCommand(game, marioTexture);
        ICommand jumpCommand = new JumpMarioCommand(game, marioTexture);
        ICommand crouchCommand = new CrouchMarioCommand(game, marioTexture);
        ICommand idleCommand = new IdleMarioCommand(game, marioTexture);
        keyboardController.addCommand(Keys.A, moveLeftCommand);
        keyboardController.addCommand(Keys.D, moveRightCommand);
        keyboardController.addCommand(Keys.W, jumpCommand);
        keyboardController.addCommand(Keys.S, crouchCommand);

        // command for switching blocks
        keyboardController.addCommand(Keys.T, blockTCommand);
        keyboardController.addCommand(Keys.Y, blockYCommand);
    }


}
