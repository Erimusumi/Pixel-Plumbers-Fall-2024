using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DeadLuigi : ICharacter
{
    private float scale = 2f;
    private Texture2D LuigiTexture;
    
    public DeadLuigi(Texture2D LuigiTexture)
    {
        this.LuigiTexture = LuigiTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool hasStar)
    {
        Rectangle sourceRectangle = new Rectangle(0, 16, 15, 14);
        spriteBatch.Draw(LuigiTexture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {

    }

    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 15 * (int)scale, 14 * (int)scale);
    }
}