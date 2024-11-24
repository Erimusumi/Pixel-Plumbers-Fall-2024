using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface ICharacter
{
    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool hasStar);
    public void Update(GameTime gameTime);
    public Rectangle GetDestination(Vector2 position);
}