using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

public interface ISprite
{
    public void Update();
    public void Draw(SpriteBatch spriteBatch, Vector2 location);
}