using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SmallIdleRightMario : ISprite
{
    private Texture2D MarioTexture;
    public SmallIdleRightMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        //TODO: Get correct sprite source
        Rectangle sourceRectangle = new Rectangle(211, 0, 12, 15);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}