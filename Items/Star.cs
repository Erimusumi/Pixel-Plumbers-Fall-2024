using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
public interface IStarObject : IEntity
{
    Boolean idleState();
    Boolean collectedState();
    Boolean roamingState();
    void draw();




}
public class Star : IStarObject
{
    public Boolean idle;
    public Boolean collected;
    public Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private StarPower sp;
    private SpriteBatch sB;
    private Texture2D texture;
    

    public Star(SpriteBatch sb,Texture2D text, Microsoft.Xna.Framework.Vector2 pos)
    {
        sp = new StarPower(texture);
        this.idle = true;
        this.collected = false;
        this.roaming = false;
        sB = sb;
        position = pos;
        texture = text;


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
    public void draw()
    {
        if (this.collected)
        {
            
        }
        else if (this.idle)
        {
            this.sp = new StarPower(texture);
            this.sp.Draw(sB, position);
        }
        else if (this.roaming)
        {

        }
    }

    public Rectangle GetDestination()
    {
        return this.sp.GetDestination(position);
    }


}