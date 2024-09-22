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
        spriteBatch.Begin();

        Rectangle sourceRectangle = new Rectangle(209, 52, 16, 32);
        spriteBatch.Draw(texture, location, sourceRectangle, Color.White);
       
        spriteBatch.End();

    }

    public void Update(GameTime gameTime)
    {
    }
}