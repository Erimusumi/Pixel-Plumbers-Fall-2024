using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class JumpingRightFireLuigi : ICharacter
{
    private float scale = 2f;
    private Texture2D LuigiTexture;
    private Color tint;
    
    public JumpingRightFireLuigi(Texture2D LuigiTexture)
    {
        this.LuigiTexture = LuigiTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool HasStar)
    {
        if (HasStar) { tint = Color.Magenta; }
        else { tint = Color.White; }

        Rectangle sourceRectangle = new Rectangle(362, 122, 16, 32);
        spriteBatch.Draw(LuigiTexture, position, sourceRectangle, tint, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {
        
    }

    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 16 * (int)scale, 32 * (int)scale);


    }
}