using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BigTurningLeftMario : ISprite
{
    private Texture2D MarioTexture;
    public BigTurningLeftMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(329, 52, 344-329, 83-52);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}