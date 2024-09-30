using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System.Globalization;
public class CommandControlCenter
{
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
        keyboardController.addCommand(Keys.A, moveLeftCommand);
        keyboardController.addCommand(Keys.D, moveRightCommand);
        keyboardController.addCommand(Keys.W, jumpCommand);
        keyboardController.addCommand(Keys.S, crouchCommand);
        keyboardController.addCommand(Keys.Left, moveLeftCommand);
        keyboardController.addCommand(Keys.Right, moveRightCommand);
        keyboardController.addCommand(Keys.Up, jumpCommand);
        keyboardController.addCommand(Keys.Down, crouchCommand);

        // commands to change mario state
        ICommand setMarioSmallCommand = new SetMarioSmallCommand(game);
        ICommand setMarioBigCommand = new SetMarioBigCommand(game);
        ICommand setMarioFireCommand = new SetMarioFireCommand(game);
        keyboardController.addCommand(Keys.D1, setMarioSmallCommand);
        keyboardController.addCommand(Keys.D2, setMarioBigCommand);
        keyboardController.addCommand(Keys.D3, setMarioFireCommand);

        // command for switching blocks
        ICommand blockTCommand = new blockTCommand(game);
        ICommand blockYCommand = new blockYCommand(game);
        keyboardController.addCommand(Keys.T, blockTCommand);
        keyboardController.addCommand(Keys.Y, blockYCommand);
    }


}
