using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public interface IObstacle : IEntity
{
    public void Draw(SpriteBatch spriteBatch, Vector2 position);
    public void Update(GameTime gametime);
}