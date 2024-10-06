using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TurningLeftFireMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public TurningLeftFireMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(337, 122, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }

}