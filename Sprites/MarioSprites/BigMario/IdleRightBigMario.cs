using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightBigMario : IMarioSprite
{
    private float scale = 2f;
    private Vector2 _position;
    private Texture2D MarioTexture;
    public IdleRightBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(209, 52, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {

    }
    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)_position.X, (int)_position.Y, 16, 32);
    }

}