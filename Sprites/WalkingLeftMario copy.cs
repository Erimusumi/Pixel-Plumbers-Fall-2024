using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WalkingLeftMario : ISprite
{
    
    private Texture2D texture;
    public WalkingLeftMario(Texture2D texture){
        this.texture = texture;
    }
    
    public void Draw(SpriteBatch spriteBatch, Vector2 positon)
    {
    }

    public void Update(GameTime gameTime)
    {
    }
}