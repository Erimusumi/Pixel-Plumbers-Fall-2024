﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class Star:IItem
{
    private Boolean idle;
    private Boolean collected;
    private Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private StarPower sp;
    private SpriteBatch sB;
    private Texture2D texture;
    private Boolean movingLeft;
    private Boolean movingRight;
    private Boolean falling;
    

    public Star(SpriteBatch sb,Texture2D text)
    {
        sp = new StarPower(texture);
        idle = true;
        collected = false;
        roaming = false;
        sB = sb;
        texture = text;


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
        collected = false;
        idle = false;
    }
    public void draw(Vector2 pos)
    {
        if (this.collected)
        {
           
        }
        else if (this.idle)
        {
            sp = new StarPower(texture);
            this.sp.Draw(sB, pos);
        }
        else if (this.roaming)
        {

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
        this.sp = null;
    }
    public void update(GameTime gameTime)
    {
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

    public Rectangle GetDestination()
    {
        return this.sp.GetDestination(position);
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