using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleLeftMario : ISprite
{
    private Texture2D MarioTexture;
    public IdleLeftMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(180, 52, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        throw new System.NotImplementedException();
    }

    public void Update(GameTime gametime)
    {
        throw new System.NotImplementedException();
    }
}