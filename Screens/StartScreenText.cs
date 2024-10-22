using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Pixel_Plumbers_Fall_2024;

public class StartScreenText : ISprite
{
    private SpriteFont MyFont;
    private Vector2 player1Position;
    private Vector2 player2Position;
    private Vector2 helpPosition;

    public StartScreenText(SpriteFont spriteFont)
    {
        this.MyFont = spriteFont;
        player1Position = new Vector2(100, 230);
        player2Position = new Vector2(100, 260);
        helpPosition = new Vector2(100, 290);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(MyFont, "1 PLAYER", player1Position, Color.Black);
        spriteBatch.DrawString(MyFont, "2 PLAYER", player2Position, Color.Black);
        spriteBatch.DrawString(MyFont, "HELP", helpPosition, Color.Black);
    }

    public void Update(GameTime gameTime)
    {
    }

    public Rectangle GetPlayer1Region()
    {
        return new Rectangle((int)player1Position.X, (int)player1Position.Y, (int)MyFont.MeasureString("1 PLAYER").X, (int)MyFont.MeasureString("1 PLAYER").Y);
    }

    public Rectangle GetPlayer2Region()
    {
        return new Rectangle((int)player2Position.X, (int)player2Position.Y, (int)MyFont.MeasureString("2 PLAYER").X, (int)MyFont.MeasureString("2 PLAYER").Y);
    }

    public Rectangle GetHelpRegion()
    {
        return new Rectangle((int)helpPosition.X, (int)helpPosition.Y, (int)MyFont.MeasureString("HELP").X, (int)MyFont.MeasureString("HELP").Y);
    }
}
