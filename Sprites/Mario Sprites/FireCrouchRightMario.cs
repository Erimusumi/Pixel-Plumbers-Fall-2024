using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FireCrouchRightMario : ISprite
{
    private Texture2D MarioTexture;
    public FireCrouchRightMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        //TODO: get correct sprite source
        Rectangle sourceRectangle = new Rectangle(389, 127, 16, 22);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}