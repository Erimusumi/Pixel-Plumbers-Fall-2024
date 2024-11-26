using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class MarioControlCenter
{
    private Mario mario;
    private PlayerMovementController playerMovementController;

    public MarioControlCenter(Mario mario, PlayerMovementController playerMovementController)
    {
        this.mario = mario;
        this.playerMovementController = playerMovementController;

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        IPlayerCommand marioMoveRight = new MarioMoveRightCommand(mario);
        IPlayerCommand marioMoveLeft = new MarioMoveLeftCommand(mario);
        IPlayerCommand marioJumpCommand = new MarioJumpCommand(mario);
        IPlayerCommand marioCrouchCommand = new MarioCrouchCommand(mario);
        IPlayerCommand marioFireballCommand = new MarioFireballCommand(mario);
        IPlayerCommand marioPowerUpCommand = new MarioPowerUpCommand(mario);
        IPlayerCommand marioTakeDamageCommand = new MarioTakeDamageCommand(mario);
        IPlayerCommand marioStarCommand = new MarioStarCommand(mario);
        IPlayerCommand DisablePlayer = new DisablePlayerCommand(playerMovementController);

        playerMovementController.addCommand(Keys.D, marioMoveRight);
        playerMovementController.addCommand(Keys.A, marioMoveLeft);
        playerMovementController.addCommand(Keys.W, marioJumpCommand);
        playerMovementController.addCommand(Keys.S, marioCrouchCommand);

        playerMovementController.addCommand(Keys.D1, marioPowerUpCommand);
        playerMovementController.addCommand(Keys.D2, marioTakeDamageCommand);

        playerMovementController.addCommand(Keys.LeftShift, marioFireballCommand);
        playerMovementController.addCommand(Keys.RightShift, marioStarCommand);

        playerMovementController.addCommand(Keys.D0, DisablePlayer);
    }
}
