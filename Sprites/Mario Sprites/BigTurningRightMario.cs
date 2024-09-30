using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BigTurningRightMario : ISprite
{
    private Texture2D MarioTexture;
    public BigTurningRightMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        //TODO: get correct sprite source
        Rectangle sourceRectangle = new Rectangle(60, 52, 75-60, 83-52);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}