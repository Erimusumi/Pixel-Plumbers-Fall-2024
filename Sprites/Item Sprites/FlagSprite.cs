using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;


public class FlagSprite
{
    
    private Texture2D FlagTexture;
    private Texture2D DanceTexture;
    private SpriteBatch sb;
    private Vector2 position;
    private Rectangle destinationRectangle;

    DancePole dance;

    public FlagSprite(SpriteBatch spriteBatch, Texture2D flagTexture,Texture2D danceTexture, Vector2 position)
    {
        this.DanceTexture = danceTexture;
        this.FlagTexture = flagTexture;
        this.sb = spriteBatch;
        this.position = position;
        dance = new DancePole(new Vector2(position.X-30, position.Y-250));
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
    public void drawIdleFlag()
    {
        Rectangle flagSourceRectangle = new Rectangle(128, 32, 15, 15);
       
        int y = drawPole((int)position.X, (int)position.Y);
         Rectangle flagDestinationRectangle = new Rectangle((int)position.X-16, y, 30, 30);
        destinationRectangle = Rectangle.Union(destinationRectangle,flagDestinationRectangle);
       
        sb.Draw(FlagTexture, flagDestinationRectangle, flagSourceRectangle, Color.White);

    }
   
    public void update()
    {   
        dance.Updates();
    }
    public void drawDanceFlag()
    {

        dance.Draw(sb, DanceTexture);
    }


    public Rectangle GetDestination()
    {
        //return destinationRectangle;
        return new Rectangle((int)position.X, (int)position.Y, 30, 240);
    }
}

