using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CrouchRightBigMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public CrouchRightBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(389, 57, 16, 22);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {

    }
}