using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Transactions;

public class TurningLeftBigMario : ICharacter
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    private Color tint;
    
    public TurningLeftBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool HasStar)
    {
        if (HasStar) { tint = Color.Magenta; }
        else { tint = Color.White; }

        Rectangle sourceRectangle = new Rectangle(329, 52, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, tint, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {

    }

    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 16 * (int)scale, 32 * (int)scale);
    }
}