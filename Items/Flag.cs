using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


    public class Flag: IEntity
{
    FlagSprite flagSprite;
    Vector2 position;
    Rectangle destinationRectangle;
    //DancePole dance;
    Boolean isWinFlag = false;

    public Flag(Vector2 position, Texture2D flagTexture, Texture2D danceTexture, SpriteBatch spriteBatch)
    {
        this.position = position;
    
        flagSprite = new FlagSprite(spriteBatch, flagTexture,danceTexture, position);
    }
    public void Update()
    {
        if (this.isWinFlag)
        {
            flagSprite.update();
        }
        
    }
   public void Draw()
    {
        if (isWinFlag)
        {
            flagSprite.drawDanceFlag();
        }
        else
        {
            flagSprite.drawIdleFlag();
        }  
        
    }
    public Rectangle GetDestination()
    {
        return flagSprite.GetDestination();
    }
    public void makeWinFlag()
    {
        isWinFlag = true;
    }
    public void resetFlag()
    {
        isWinFlag = false;
    }
}

