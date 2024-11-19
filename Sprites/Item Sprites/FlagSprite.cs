using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class FlagSprite
{

    private Texture2D FlagTexture;
    private SpriteBatch sb;
    private Vector2 position;
    private Rectangle destinationRectangle;

    public FlagSprite(SpriteBatch spriteBatch, Texture2D flagTexture, Vector2 position)
    {
        this.FlagTexture = flagTexture;
        this.sb = spriteBatch;
        this.position = position;
    }
    public void update(GameTime gametime)
    {
    }
    public void draw()
    {
        Rectangle sourceRectangle = new Rectangle(3157, 38, 32, 152);
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 31, 31);
        sb.Draw(FlagTexture, destinationRectangle, sourceRectangle, Color.White);

    }


    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
}

