using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BigIdleRightMario : ISprite
{
    private Texture2D MarioTexture;
    public BigIdleRightMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(209, 52, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        
    }

    public void Update(GameTime gametime)
    {
       
    }
}