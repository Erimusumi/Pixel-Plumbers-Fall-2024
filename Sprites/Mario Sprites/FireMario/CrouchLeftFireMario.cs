using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CrouchLeftFireMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public CrouchLeftFireMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 127, 16, 22);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }
}