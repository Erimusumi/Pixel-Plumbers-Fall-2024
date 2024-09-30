using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DeadMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public DeadMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 16, 14, 29 - 16);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }


    public void Update(GameTime gametime)
    {
    }


}