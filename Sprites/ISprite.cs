using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface ISprite
{
    public void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch, Vector2 location);
}