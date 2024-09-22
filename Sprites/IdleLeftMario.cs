using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleLeftMario : ISprite
{
        private Texture2D texture;
    public IdleLeftMario(Texture2D texture)
    {
        this.texture = texture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
    }

    public void Update(GameTime gameTime)
    {
    }
}