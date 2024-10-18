using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StartScreenText : ISprite
{
    private SpriteFont MyFont;
    public StartScreenText(SpriteFont spriteFont)

    {
        this.MyFont = spriteFont;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(MyFont, "SUPER MARIO", new Vector2(100, 200), Color.Black);
        spriteBatch.DrawString(MyFont, "BY THE PIXEL PLUMBERS", new Vector2(100, 230), Color.Black);
        spriteBatch.DrawString(MyFont, "PRESS 0 TO START THE GAME", new Vector2(100, 260), Color.Black);
        spriteBatch.DrawString(MyFont, "PRESS 3 TO PAUSE", new Vector2(100, 290), Color.Black);
        spriteBatch.DrawString(MyFont, "PRESS R TO RESET", new Vector2(100, 320), Color.Black);
        spriteBatch.DrawString(MyFont, "PRESS Q TO QUIT", new Vector2(100, 350), Color.Black);
    }

    public void Update(GameTime gametime)
    {
        throw new System.NotImplementedException();
    }
    public Rectangle GetDestination()
    {
        return new Rectangle();
    }
}