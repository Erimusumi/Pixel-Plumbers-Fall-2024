using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightFireMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public IdleRightFireMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(290, 122, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }
}