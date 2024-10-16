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
    void draw(SpriteBatch sb, Texture2D texture);




}
public class starPower : IStarObject
{
    private Boolean idle;
    private Boolean collected;
    private Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private StarPower sp;
    public starPower()
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
            this.sp = new StarPower(texture);
            this.sp.Draw(sB, position);
        }
        else if (this.collected)
        {

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