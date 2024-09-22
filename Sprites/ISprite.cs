using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public interface ISprite
{
    public void Load(GraphicsDeviceManager graphics);
    public void Draw(SpriteBatch spriteBatch, Vector2 position);
    public void Update(GameTime gametime);
}