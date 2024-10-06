using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
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
    private int x;
    private int y;

    public firePower()
    {
        this.idle = false;
        this.collected = false;
    }
    public Boolean idleState()
    {
        return this.idle;
    }
    public Boolean collectedState()
    {

        return this.collected;
    }
    public void draw(SpriteBatch sb, Texture2D texture)
    {
        if (this.idle)
        {

        }
        else if (this.collected)
        {

        }
    }


}