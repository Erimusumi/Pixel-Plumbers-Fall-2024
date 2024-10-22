using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StartScreenSprite : ISprite
{
    private float scale = 2f;
    private Texture2D StartScreenTexture;
    public StartScreenSprite(Texture2D StartScreenTexture)
    {
        this.StartScreenTexture = StartScreenTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 0, 176, 88);
        spriteBatch.Draw(StartScreenTexture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gametime)
    {
    }
}