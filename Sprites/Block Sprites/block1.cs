using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;


public class block1 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private Texture2D BlockTexture;

    public block1(Texture2D BlockTexture)
    {
        this.BlockTexture = BlockTexture;
    }

    public void Load(GraphicsDeviceManager graphics)
    {

    }
    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(86, 5, 80, 35);
        destinationRectangle = new Rectangle(310, 150, 80, 35);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(BlockTexture, destinationRectangle, sourceRectangle, Color.White);
    }
}
