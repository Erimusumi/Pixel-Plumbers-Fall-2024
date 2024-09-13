using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class OneFrameFixedSprite : ISprite
{
    public Vector2 Position;
    private Texture2D marioTexture;

    public OneFrameFixedSprite(Texture2D marioTexture)
    {
        this.marioTexture = marioTexture;
    }

    public void Draw(GraphicsDeviceManager _graphics, SpriteBatch _spriteBatch)
    {
        Rectangle sourceRectangle = new Rectangle(209, 52, 16, 32);
        _spriteBatch.Draw(marioTexture, Position, sourceRectangle, Color.White);
    }

    public void LoadContent(GraphicsDeviceManager _graphics)
    {
        Position.X = _graphics.PreferredBackBufferWidth / 2;
        Position.Y = _graphics.PreferredBackBufferHeight / 2;
    }

    public void Update(GameTime gameTime)
    {
    }
}