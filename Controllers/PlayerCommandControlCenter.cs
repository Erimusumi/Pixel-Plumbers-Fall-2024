using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class PlayerCommandControlCenter
{
    private Mario mario;
    private PlayerMovementController playerMovementController;

    public PlayerCommandControlCenter(Mario mario, PlayerMovementController playerMovementController)
    {
        this.mario = mario;
        this.playerMovementController = playerMovementController; // Use the passed instance

        InitializeCommands(); // Correct method name
    }

    private void InitializeCommands()
    {
        // Create commands
        IPlayerCommand marioMoveRight = new MarioMoveRightCommand(mario);
        IPlayerCommand marioMoveLeft = new MarioMoveLeftCommand(mario);
        IPlayerCommand marioJumpCommand = new MarioJumpCommand(mario);
        IPlayerCommand marioCrouchCommand = new MarioCrouchCommand(mario);
        IPlayerCommand marioPowerUpCommand = new MarioPowerUpCommand(mario);
        IPlayerCommand marioTakeDamageCommand = new MarioTakeDamageCommand(mario);

        // Add commands to the existing playerMovementController
        playerMovementController.addCommand(Keys.Right, marioMoveRight);
        playerMovementController.addCommand(Keys.Left, marioMoveLeft);
        playerMovementController.addCommand(Keys.Up, marioJumpCommand);
        playerMovementController.addCommand(Keys.Down, marioCrouchCommand);

        playerMovementController.addCommand(Keys.D1, marioPowerUpCommand);
        playerMovementController.addCommand(Keys.D2, marioTakeDamageCommand);
    }
}
