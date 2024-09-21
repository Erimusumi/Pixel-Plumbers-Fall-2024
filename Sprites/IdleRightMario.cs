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
    }
    public void Update(GameTime gameTime)
    {
    }
}