using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class FlagSprite: IEntity
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
     private int  drawPole(int x, int y)
    {
        Rectangle poleSourceRectangle = new Rectangle(80,33,15,15);
        int currY = y;
        for(int i = 0; i < 8; i++)
        {
            
            Rectangle destinationRect = new Rectangle(x, (currY), 30, 30);
            sb.Draw(FlagTexture, destinationRect, poleSourceRectangle, Color.White);
            destinationRectangle = Rectangle.Union(destinationRect, destinationRectangle);
            currY = currY - 30;
        }
        int y1 = y - (30 * 7);
        return y1;
    }
    public void draw()
    {
        Rectangle flagSourceRectangle = new Rectangle(128, 32, 15, 15);
       
        int y = drawPole((int)position.X, (int)position.Y);
         Rectangle flagDestinationRectangle = new Rectangle((int)position.X-16, y, 30, 30);
        destinationRectangle = Rectangle.Union(destinationRectangle,flagDestinationRectangle);
       
        sb.Draw(FlagTexture, flagDestinationRectangle, flagSourceRectangle, Color.White);

    }


    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
}

