using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Block4 : ISprite
{

    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private Texture2D BlockTexture;

    public Block4(Texture2D BlockTexture)
    {
        this.BlockTexture = BlockTexture;
    }

    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(172, 236, 80, 81);
        destinationRectangle = new Rectangle(410, 150, 80, 81);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(BlockTexture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        throw new System.NotImplementedException();
    }
}
