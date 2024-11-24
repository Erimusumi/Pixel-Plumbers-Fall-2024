using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightSmallLuigi : ICharacter
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    private Color tint;

    public IdleRightSmallLuigi(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool HasStar)
    {
        if (HasStar) { tint = Color.Magenta; }
        else { tint = Color.White; }

        Rectangle sourceRectangle = new Rectangle(211, 0, 13, 16);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, tint, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {

    }

    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 13 * (int)scale, 16 * (int)scale);
    }
}