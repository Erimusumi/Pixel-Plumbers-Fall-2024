using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.Design.Serialization;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
public interface IMushroomObject : IEntity
{
  
    void idling();
    void collect();
    void roams();
    void draw();

}
public class Mushroom : IMushroomObject
{
    public Boolean idle;
    public Boolean collected;
    public Boolean roaming;
    private Boolean movingRight;
    private Boolean movingLeft;
    private Microsoft.Xna.Framework.Vector2 position;
    private MushroomPower mp;
    private SpriteBatch sb;
    private Texture2D texture;
    

    public  Mushroom(SpriteBatch sB, Texture2D texture, Microsoft.Xna.Framework.Vector2 position)
    {
        mp = new MushroomPower(texture);
        this.idle = true;
        this.collected = false;
        this.roaming = false;
        this.position = position;
        this.texture = texture;
        this.sb = sB;
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
        idle = false;
        roaming = false;
       
    }
    public void draw()
    {
        if (this.idle)
        {
            this.mp = new MushroomPower(texture);
            this.mp.Draw(sb, position);
            
        }
        else if (this.collected)
        {
            position = new Microsoft.Xna.Framework.Vector2(900, 900);
            
        }
        else if (this.roaming)
        {
            movingRight = true;
            movingLeft = false;
        }
    }
    public void update()
    {
        if (this.roaming)
        {
            if (movingRight)
            {
                position.X++;
            }else if (movingLeft)
            {
                position.X--;
            }
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