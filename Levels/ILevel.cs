using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public interface ILevel
{
    public void LoadLevel(ContentManager content);
    public void UpdateLevel(GameTime gameTime);
    public void DrawLevel(SpriteBatch spriteBatch, FollowCamera camera);
}