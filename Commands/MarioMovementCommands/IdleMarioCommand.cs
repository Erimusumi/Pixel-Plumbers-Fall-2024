using MarioGame;
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
        idleRightSmallMario = new IdleLeftSmallMarioCommand(game, marioTexture);
        idleLeftBigMario = new IdleLeftSmallMarioCommand(game, marioTexture);
        idleRightBigMario = new IdleLeftSmallMarioCommand(game, marioTexture);
        idleLeftFireMario = new IdleLeftSmallMarioCommand(game, marioTexture);
        idleRightFireMario = new IdleLeftSmallMarioCommand(game, marioTexture);

    }

    public void Execute()
    {
        game.marioPosition.X -= 10;
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
