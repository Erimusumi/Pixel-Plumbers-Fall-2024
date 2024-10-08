﻿using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
public interface IFireObject
{
    Boolean idleState();
    Boolean collectedState();
    void draw(SpriteBatch sb, Texture2D texture);
}
public class firePower : IFireObject
{
    private Boolean idle;
    private Boolean collected;
    private Boolean roaming;
    private Vector2 position;
    private int x;
    private int y;

    public firePower()
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
            FirePower fp = new FirePower(texture);
            fp.Draw(sB, position);
        }
        else if (this.collected)
        {

        }
        else if (this.roaming)
        {

        }
    }


}