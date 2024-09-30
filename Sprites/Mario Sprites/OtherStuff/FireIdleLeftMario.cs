using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FireIdleLeftMario : ISprite
{
    private Texture2D MarioTexture;
    public FireIdleLeftMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        //TODO: Get correct sprite source
        Rectangle sourceRectangle = new Rectangle(180, 122, 16, 32);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}