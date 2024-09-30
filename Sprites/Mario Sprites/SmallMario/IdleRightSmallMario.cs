using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightSmallMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public IdleRightSmallMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(211, 0, 13, 16);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }

}