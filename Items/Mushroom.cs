using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

public class Mushroom :IItem
{
    public Boolean idle;
    public Boolean collected;
    public Boolean roaming;
    private Boolean movingRight;
    private Boolean movingLeft;
    private Microsoft.Xna.Framework.Vector2 position;
    private MushroomPower mp;
    private SpriteBatch sb;
    private Texture2D texture;
    private bool falling;
    public bool bump;
    

    public  Mushroom(SpriteBatch sB, Texture2D texture, Vector2 position)
    {
        mp = new MushroomPower(texture);
        this.idle = false;
        this.collected = false;
        this.roaming = true;
        this.position = position;
        this.texture = texture;
        this.sb = sB;
        movingRight = true;
    }
    public void idling()
    {
        idle = true;
        collected = false;
        roaming = false;
    }
    public void collect()
    {
        collected = true;
        idle = false;
        roaming = false;
      
    }
    public void roams()
    {
        roaming = true;
        idle = false;
        roaming = false;
        movingRight = true;
        movingLeft = false;
       
    }
    public void draw(Vector2 position)
    {
        if (this.idle || this.roaming)
        {
            this.mp = new MushroomPower(texture);
            
            this.mp.Draw(sb, position);
            
        }
        else if (this.collected)
        {
            position = new Microsoft.Xna.Framework.Vector2(900, 900);
            
        }
    }
    public void update(GameTime gameTime)
    {
        if (this.roaming)
        {
            if (movingRight)
            {
                position.X++;
            }else if (movingLeft)
            {
                position.X--;
            }
        }
    }
    public void swapDirection()
    {
        if (movingLeft){
            movingLeft = false;
            movingRight = true;
        }
        else if (movingRight)
        {
            movingRight = false;
            movingLeft = true;
        }
    }
    public void destroy()
    {
            this.mp = null;
      
    }

    public Rectangle GetDestination()
    {
        return this.mp.GetDestination(position);
    }
    public bool isFalling()
    {
        return falling;
    }
    public void NotFalling()
    {
        falling = false;
    }
    public void MakeFalling()
    {
        falling = true;
    }


}