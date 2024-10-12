using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IMarioSprite : IEntity
{
    public void Draw(SpriteBatch spriteBatch, Vector2 position);
    public void Update(GameTime gameTime);

    public Rectangle GetDestinationRectangle(Vector2 position);
}