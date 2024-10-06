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
    private KeyboardControllerMovement keyboardControllerMovement;
    private Mario mario;

    public CommandControlCenter(Game1 game, Texture2D marioTexture, Mario mario)
    {
        this.game = game;
        this.mario = mario;
        this.marioTexture = marioTexture;
        this.keyboardController = new KeyboardController();
        this.keyboardControllerMovement = new KeyboardControllerMovement();
        game.SetKey(keyboardController);
        game.SetKeyMovement(keyboardControllerMovement);

        InitializeCommmands();
    }

    private void InitializeCommmands()
    {
        // commands for switching enemy
        ICommand EnemySwitch = new EnemySwitch(game);
        keyboardController.addCommand(Keys.P, EnemySwitch);
        keyboardController.addCommand(Keys.O, EnemySwitch);

        // commands for mario movement
        ICommand moveLeftCommand = new MarioMoveLeftCommand(mario);
        ICommand moveRightCommand = new MarioMoveRightCommand(mario);
        ICommand jumpCommand = new MarioJumpCommand(mario);
        ICommand crouchCommand = new MarioJumpCommand(mario);
        keyboardControllerMovement.addCommand(Keys.A, moveLeftCommand);
        keyboardControllerMovement.addCommand(Keys.D, moveRightCommand);
        keyboardControllerMovement.addCommand(Keys.W, jumpCommand);
        keyboardControllerMovement.addCommand(Keys.S, crouchCommand);
        keyboardControllerMovement.addCommand(Keys.Left, moveLeftCommand);
        keyboardControllerMovement.addCommand(Keys.Right, moveRightCommand);
        keyboardControllerMovement.addCommand(Keys.Up, jumpCommand);
        keyboardControllerMovement.addCommand(Keys.Down, crouchCommand);

        // commands to change mario state
        // ICommand setMarioSmallCommand = new SetMarioSmallCommand(game);
        // ICommand setMarioBigCommand = new SetMarioBigCommand(game);
        // ICommand setMarioFireCommand = new SetMarioFireCommand(game);
        // keyboardController.addCommand(Keys.D1, setMarioSmallCommand);
        // keyboardController.addCommand(Keys.D2, setMarioBigCommand);
        // keyboardController.addCommand(Keys.D3, setMarioFireCommand);

        // command for switching blocks
        ICommand blockTCommand = new blockTCommand(game);
        ICommand blockYCommand = new blockYCommand(game);
        keyboardController.addCommand(Keys.T, blockTCommand);
        keyboardController.addCommand(Keys.Y, blockYCommand);

        // command for other controls
        ICommand quitCommand = new quitCommand(game);
        ICommand resetCommand = new resetCommand(game);
        keyboardController.addCommand(Keys.Q, quitCommand);
        keyboardController.addCommand(Keys.R, resetCommand);
    }
}
