using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Block3 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private Texture2D BlockTexture;

    public Block3(Texture2D BlockTexture)
    {
        this.BlockTexture = BlockTexture;
    }
    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(84, 321, 62, 128);
        destinationRectangle = new Rectangle(410, 250, 62, 128);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 Position)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(BlockTexture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        throw new NotImplementedException();
    }
}
