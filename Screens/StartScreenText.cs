using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Pixel_Plumbers_Fall_2024;

public class StartScreenText : ISprite
{
    private SpriteFont StartScreenFont;
    private Vector2 player1Position;
    private Vector2 player2Position;
    private Vector2 helpPosition;

    public StartScreenText(SpriteFont StartScreenFont)
    {
        this.StartScreenFont = StartScreenFont;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(StartScreenFont, "1 PLAYER", player1Position, Color.Black);
        spriteBatch.DrawString(StartScreenFont, "2 PLAYER", player2Position, Color.Black);
        spriteBatch.DrawString(StartScreenFont, "HELP", helpPosition, Color.Black);
    }

    public void Update(GameTime gameTime)
    {

    }
}
