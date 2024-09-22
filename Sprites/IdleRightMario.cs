using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightMario : ISprite
{
    private Texture2D texture;
    public IdleRightMario(Texture2D texture)
    {
        this.texture = texture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        Rectangle sourceRectangle = new Rectangle(209, 52, 16, 32);
        Rectangle destRectangle = new Rectangle(100, 100, 100, 100);
        spriteBatch.Draw(texture, destRectangle, sourceRectangle, Color.White);
    }

    public void Update(GameTime gameTime)
    {
    }
}