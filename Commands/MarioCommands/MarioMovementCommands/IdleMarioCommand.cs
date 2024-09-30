using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;

public class IdleMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand idleLeftSmallMario;
    private ICommand idleRightSmallMario;
    private ICommand idleLeftBigMario;
    private ICommand idleRightBigMario;
    private ICommand idleLeftFireMario;
    private ICommand idleRightFireMario;

    public IdleMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        idleLeftSmallMario = new IdleLeftSmallMarioCommand(game, marioTexture);
        idleRightSmallMario = new IdleRightSmallMarioCommand(game, marioTexture);
        idleLeftBigMario = new IdleLeftBigMarioCommand(game, marioTexture);
        idleRightBigMario = new IdleRightBigMarioCommand(game, marioTexture);
        idleLeftFireMario = new IdleLeftFireMarioCommand(game, marioTexture);
        idleRightFireMario = new IdleRightFireMarioCommand(game, marioTexture);
    }

    public void Execute()
    {
        switch (game.currentMarioState)
        {
            case Game1.MarioState.Small:
                if (game.facingRight)
                {
                    idleRightSmallMario.Execute();
                }
                else
                {
                    idleLeftSmallMario.Execute();
                }
                break;

            case Game1.MarioState.Big:
                if (game.facingRight)
                {
                    idleRightBigMario.Execute();
                }
                else
                {
                    idleLeftBigMario.Execute();
                }
                break;

            case Game1.MarioState.Fire:
                if (game.facingRight)
                {
                    idleRightFireMario.Execute();
                }
                else
                {
                    idleLeftFireMario.Execute();
                }
                break;
        }
    }
}
