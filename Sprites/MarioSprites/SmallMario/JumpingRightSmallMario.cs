using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class JumpingRightSmallMario : IMarioSprite
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    public JumpingRightSmallMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(359, 0, 17, 16);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {
    }
    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 17, 16);


    }
}