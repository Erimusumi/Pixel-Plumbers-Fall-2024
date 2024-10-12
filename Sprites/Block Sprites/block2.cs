using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class obstacle2 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private int width;
    private int height;
    private Texture2D BlockTexture;

    public obstacle2(Texture2D BlockTexture)
    {
        this.BlockTexture = BlockTexture;
    }
    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(355, 186, 48, 40);
        width = 48;
        height = 40;
    }
    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        spriteBatch.Begin();
        spriteBatch.Draw(BlockTexture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }
    public void Load(GraphicsDeviceManager graphics)
    {
        throw new NotImplementedException();
    }
}
