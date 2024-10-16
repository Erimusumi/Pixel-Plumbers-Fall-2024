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
        Rectangle sourceRectangle = new Rectangle(331, 0, 14, 16);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }

    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 14, 16);


    }

}