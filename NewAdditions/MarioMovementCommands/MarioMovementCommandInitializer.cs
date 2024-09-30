using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class MarioMovementCommandInitializer
{
    private Game1 game;
    private KeyboardController keyboardController;

    public MarioMovementCommandInitializer(Game1 game)
    {
        this.game = game;
        keyboardController = new KeyboardController(game);
    }

    public KeyboardController InitializeMarioCommands(Texture2D marioTexture)
    {
        InitializeCommands(marioTexture);
        return keyboardController;
    }

    private void InitializeCommands(Texture2D marioTexture)
    {
        ICommand moveLeftCommand = new MoveLeftMarioCommand(game, marioTexture);
        ICommand moveRightCommand = new MoveRightMarioCommand(game, marioTexture);
        ICommand jumpCommand = new JumpMarioCommand(game, marioTexture);
        ICommand crouchCommand = new CrouchMarioCommand(game, marioTexture);
        ICommand idleCommand = new IdleMarioCommand(game, marioTexture);

        keyboardController.addCommand(Keys.A, moveLeftCommand);
        keyboardController.addCommand(Keys.D, moveRightCommand);
        keyboardController.addCommand(Keys.W, jumpCommand);
        keyboardController.addCommand(Keys.S, crouchCommand);
        keyboardController.addCommand(Keys.Q, idleCommand);
    }
}