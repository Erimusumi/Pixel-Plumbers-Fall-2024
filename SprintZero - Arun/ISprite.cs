using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface ISprite{
    public void LoadContent(GraphicsDeviceManager _graphics);
    public void Update(GameTime gameTime);
    public void Draw(GraphicsDeviceManager _graphics,SpriteBatch _spriteBatch);
}