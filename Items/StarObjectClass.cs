using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.InteropServices;
public interface IStarObject
{
    void star();
    Boolean idleState();
    Boolean collectedState();
    void draw(SpriteBatch sb, Texture2D texture);




}
public class StarObject : IStarObject
{
    private Boolean idle;
    private Boolean collected;

    public void star()
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

