using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DisplayText : ISprite
{
    private SpriteFont MyFont;
    public DisplayText(SpriteFont spriteFont)
    {
        this.MyFont = spriteFont;
    }

    public void Draw(GraphicsDeviceManager _graphics, SpriteBatch _spriteBatch)
    {
        _spriteBatch.DrawString(MyFont, "Credits:", new Vector2(100, 350), Color.Black);
        _spriteBatch.DrawString(MyFont, "Program Made By: Arun Ghimire", new Vector2(100, 370), Color.Black);
        _spriteBatch.DrawString(MyFont, "Sprites From: https://osu.instructure.com/courses/168410/assignments/4105902", new Vector2(100, 390), Color.Black);
    }

    public void LoadContent(GraphicsDeviceManager _graphics)
    {
    }

    public void Update(GameTime gameTime)
    {
    }
}