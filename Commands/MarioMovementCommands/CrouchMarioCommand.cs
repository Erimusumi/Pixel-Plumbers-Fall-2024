using MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class CrouchMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand crouchingLeftBigMario;
    private ICommand crouchingRightBigMario;
    private ICommand crouchingLeftFireMario;
    private ICommand crouchingRightFireMario;

    public CrouchMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        crouchingLeftBigMario = new CrouchLeftBigMarioCommand(game, marioTexture);
        crouchingRightBigMario = new CrouchRightBigMarioCommand(game, marioTexture);
        crouchingLeftFireMario = new CrouchLeftFireMarioCommand(game, marioTexture);
        crouchingRightFireMario = new CrouchRightFireMarioCommand(game, marioTexture);
    }

    public void Execute()
    {
        if (!game.isJumping)
        {
            switch (game.currentMarioState)
            {
                case Game1.MarioState.Big:
                    if (game.facingRight)
                    {
                        crouchingRightBigMario.Execute();
                    }
                    else
                    {
                        crouchingLeftBigMario.Execute();
                    }
                    break;
                case Game1.MarioState.Fire:
                    if (game.facingRight)
                    {
                        crouchingRightFireMario.Execute();
                    }
                    else
                    {
                        crouchingLeftFireMario.Execute();
                    }
                    break;
            }
        }
    }
}
