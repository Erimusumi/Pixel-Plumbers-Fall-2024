using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;


public class obstacle1 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private int width;
    private int height;
    private Texture2D BlockTexture;

    public obstacle1(Texture2D BlockTexture)
    {
        this.BlockTexture = BlockTexture;
    }

    public void Load(GraphicsDeviceManager graphics)
    {

    }
    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(86, 5, 80, 35);
        width = 80;
        height = 35;        
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        spriteBatch.Begin();
        spriteBatch.Draw(BlockTexture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }
}
