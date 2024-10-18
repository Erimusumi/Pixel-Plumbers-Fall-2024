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
        spriteBatch.DrawString(MyFont, "SUPER MARIO", new Vector2(100, 350), Color.Black);
        spriteBatch.DrawString(MyFont, "BY THE PIXEL PLUMBERS", new Vector2(100, 370), Color.Black);
        spriteBatch.DrawString(MyFont, "PRESS 0 TO START THE GAME", new Vector2(100, 390), Color.Black);
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