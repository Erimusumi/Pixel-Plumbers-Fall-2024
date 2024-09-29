using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FireIdleRightMario : ISprite
{
    private Texture2D MarioTexture;
    public FireIdleRightMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        //TODO: Get correct sprite source
        Rectangle sourceRectangle = new Rectangle(-1, -1, -1, -1);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}