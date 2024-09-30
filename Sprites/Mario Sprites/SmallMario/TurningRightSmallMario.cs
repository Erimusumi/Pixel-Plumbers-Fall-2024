using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TurningRightSmallMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public TurningRightSmallMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(-1, -1, -1, -1);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }
}