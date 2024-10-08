﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
public interface IMushroomObject
{
    void mushroom();
    Boolean idleState();
    Boolean collectedState();
    Boolean roamingState();
    void draw(SpriteBatch sb, Texture2D texture);

}
public class MushroomObject : IMushroomObject
{
    private Boolean idle;
    private Boolean collected;
    private Boolean roaming;
    private Vector2 position;

    public void mushroom()
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
    public Boolean roamingState()
    {
        return this.roaming;
    }
    public void draw(SpriteBatch sB, Texture2D texture)
    {
        if (this.idle)
        {
            MushroomPower mp = new MushroomPower(texture);
            mp.Draw(sB, position);
        }
        else if (this.collected)
        {

        }
        else if (this.roaming)
        {

        }
    }


}