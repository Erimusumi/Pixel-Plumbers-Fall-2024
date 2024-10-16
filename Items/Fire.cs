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
    void draw();

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
    private SpriteBatch sB;
    private Texture2D texture;

    public Fire(SpriteBatch sB, Texture2D texture, Microsoft.Xna.Framework.Vector2 pos)
    {
        fp = new FirePower(texture);
        idle = true;
        collected = false;
        roaming = false;
        sB = sB;
        texture = texture;
        position = pos;
    }
    public Boolean idleState()
    {
        return this.idle;
    }
    public Boolean collectedState()
    {

        return this.collected;
    }
    public void draw()
    {
         if (this.collected)
        {

        }
        else if(this.idle) {
            fp = new FirePower(texture);
            fp.Draw(this.sB, position);
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