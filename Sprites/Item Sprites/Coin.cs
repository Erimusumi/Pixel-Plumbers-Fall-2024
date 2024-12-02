using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Coin
{
    private Texture2D CoinTexture;
    private SpriteBatch sb;
    private Vector2 position;
    private Rectangle destinationRectangle;
    private Rectangle[] frames;
    private int[] frameWidths;

    public Coin(SpriteBatch spriteBatch, Texture2D CoinTexture, Vector2 position)
    {
        frames = new Rectangle[5];
        frames[0] = new Rectangle(0, 0, 0, 0);
        frames[1] = new Rectangle(0, 0, 0, 0);
        frames[2] = new Rectangle(0, 0, 0, 0);
        frames[3] = new Rectangle(0, 0, 0, 0);
        frames[4] = new Rectangle(0, 0, 0, 0);

        this.CoinTexture = CoinTexture;
        this.sb = spriteBatch;
        this.position = position;
    }
    public void update(GameTime gametime)
    {
    }
    public void draw()
    {
        Rectangle sourceRectangle = new Rectangle(0, 33, 16, 16);
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 31, 31);
        sb.Draw(CoinTexture, destinationRectangle, sourceRectangle, Color.White);

    }


    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
}

