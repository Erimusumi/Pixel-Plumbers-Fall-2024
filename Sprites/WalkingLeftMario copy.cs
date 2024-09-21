using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WalkingLeftMario : ISprite
{
    
    private Texture2D texture;
    private Vector2 spritePosition;

    public WalkingLeftMario(Texture2D texture){
        this.texture = texture;
    }
    
    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
    }

    public void Update(GameTime gameTime)
    {
    }
}