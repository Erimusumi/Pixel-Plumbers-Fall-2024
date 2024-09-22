using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WalkingRightMario : ISprite
{
    private Texture2D texture;
    public WalkingRightMario(Texture2D texture)
    {
        this.texture = texture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
    }

    public void Update(GameTime gameTime)
    {
    }
}