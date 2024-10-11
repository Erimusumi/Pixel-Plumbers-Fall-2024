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
    private PlayerMovementController playerMovementController;
    private Mario mario;

    public CommandControlCenter(Game1 game)
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
