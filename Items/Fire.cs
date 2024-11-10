using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class Fire
{
    public Boolean idle;
    public Boolean collected;
    public Boolean roaming;
    Boolean spawning;
    private Microsoft.Xna.Framework.Vector2 position;
    private int x;
    private int y;
    private FirePower fp;
    private SpriteBatch sB;
    private Texture2D texture;
    private Boolean movingLeft;
    private Boolean movingRight;
    private Boolean falling;
    private int yPositionCount;
    private int groundPosition;

    public Fire(SpriteBatch sb, Texture2D text, Microsoft.Xna.Framework.Vector2 pos)
    {
        fp = new FirePower(sb, texture, pos);
        idle = true;
        this.spawning = true;
        collected = false;
        roaming = false;
        sB = sb;
        texture = text;
        position = pos;
        movingLeft = false;
        movingRight = false;
    }
    public void idling()
    {
        idle = true;
        roaming = false;
        collected = false;
    }
    public void collect()
    {
        collected = true;
        roaming = false;
        idle = false;
    }
    public void roams()
    {
        roaming = true;
        collected = false;
        idle = false;
    }
    public void draw(Vector2 blockPosition)
    {
         if (this.collected)
        {

        }
        else if(this.idle) {
            fp = new FirePower(sB, texture, position);
            fp.draw();
        }
        else if (this.roaming)
        {

        }
    }
    public void update(GameTime gameTime)
    {
        if (this.spawning)
        {
            this.position.Y++;
            this.yPositionCount++;
            if (yPositionCount > 16)
            {
                this.spawning = false;
                this.roaming = true;
                this.movingRight = true;
            }
        }
        if (this.roaming)
        {
            if (movingRight)
            {
                position.X++;
            }
            else if (movingLeft)
            {
                position.X--;
            }
        }
    }
    public void swapDirection()
    {
        if (movingLeft)
        {
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
     
            this.fp = null;
    
    }
    
    

    public Rectangle GetDestination()
    {
        return this.fp.GetDestination();
    }
    public void setGroundPosition(int newGroundPosition)
    {
        this.groundPosition = newGroundPosition;
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