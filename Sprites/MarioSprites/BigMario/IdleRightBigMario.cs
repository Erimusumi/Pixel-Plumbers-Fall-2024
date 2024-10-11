using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightBigMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public IdleRightBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(209, 52, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {

    }
}