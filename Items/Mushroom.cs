using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
public interface IMushroomObject : IEntity
{
  
    Boolean idleState();
    Boolean collectedState();
    Boolean roamingState();
    void draw(SpriteBatch sb, Texture2D texture);

}
public class Mushroom : IMushroomObject
{
    public Boolean idle;
    public Boolean collected;
    public Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private MushroomPower mp;

    public  Mushroom()
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
            this.mp = new MushroomPower(texture);
            this.mp.Draw(sB, position);
        }
        else if (this.collected)
        {

        }
        else if (this.roaming)
        {

        }
    }
    private void destroy()
    {
            this.mp = null;
      
    }

    public Rectangle GetDestination()
    {
        return this.mp.GetDestination(position);
    }


}