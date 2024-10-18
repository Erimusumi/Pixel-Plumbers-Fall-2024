using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
public interface IStarObject : IEntity
{
    void idling();
    void collect();
    void roams();
    void draw();




}
public class Star : IStarObject
{
    private Boolean idle;
    private Boolean collected;
    private Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private StarPower sp;
    private SpriteBatch sB;
    private Texture2D texture;
    

    public Star(SpriteBatch sb,Texture2D text, Microsoft.Xna.Framework.Vector2 pos)
    {
        sp = new StarPower(texture);
        idle = true;
        collected = false;
        roaming = false;
        sB = sb;
        position = pos;
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
    public void draw()
    {
        if (this.collected)
        {
           
        }
        else if (this.idle)
        {
            sp = new StarPower(texture);
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