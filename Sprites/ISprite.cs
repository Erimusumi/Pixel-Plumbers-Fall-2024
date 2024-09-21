using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
public interface ISprite
{
    void Draw(SpriteBatch spriteBatch, Vector2 location);
    void Update(GameTime gameTime);
}
