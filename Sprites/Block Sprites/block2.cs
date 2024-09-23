using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Block2 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private Texture2D BlockTexture;

    public Block2(Texture2D BlockTexture)
    {
        this.BlockTexture = BlockTexture;
    }
    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(355, 186, 48, 40);
        destinationRectangle = new Rectangle(310, 150, 48, 40);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(BlockTexture, destinationRectangle, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        throw new NotImplementedException();
    }
}
