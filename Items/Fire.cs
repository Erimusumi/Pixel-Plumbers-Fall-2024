﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
public interface IFireObject : IEntity
{
    Boolean idleState();
    Boolean collectedState();
    void draw(SpriteBatch sb, Texture2D texture);

}
public class Fire : IFireObject
{
    public Boolean idle;
    public Boolean collected;
    public Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private int x;
    private int y;
    private FirePower fp;

    public Fire()
    {
        this.idle = false;
        this.collected = false;
        this.roaming = false;
    }
    public Boolean idleState()
    {
        return this.idle;
    }
    public Boolean collectedState()
    {

        return this.collected;
    }
    public void draw(SpriteBatch sB, Texture2D texture)
    {
        if (this.idle)
        {
            this.fp = new FirePower(texture);
            this.fp.Draw(sB, position);
        }
         if (this.collected)
        {

        }
         if (this.roaming)
        {

        }
    }
    private void destroy()
    {
        if (this.collected)
        {
            this.fp = null;
        }
    }
    
    

    public Rectangle GetDestination()
    {
        return this.fp.GetDestination(position);
    }


}