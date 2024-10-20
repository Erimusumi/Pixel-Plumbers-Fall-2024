using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
public interface IFireObject : IEntity
{
    void idle();
    void collect();
    void roams();
    void draw();

}
public class Fire : IFireObject
{
    public Boolean idling;
    public Boolean collected;
    public Boolean roaming;
    private Microsoft.Xna.Framework.Vector2 position;
    private int x;
    private int y;
    private FirePower fp;
    private SpriteBatch sB;
    private Texture2D texture;

    public Fire(SpriteBatch sb, Texture2D text, Microsoft.Xna.Framework.Vector2 pos)
    {
        fp = new FirePower(texture);
        idling = true;
        collected = false;
        roaming = false;
        sB = sb;
        texture = text;
        position = pos;
    }
    public void idle()
    {
        idling = true;
        roaming = false;
        collected = false;
    }
    public void collect()
    {
        collected = true;
        roaming = false;
        idling = false;
    }
    public void roams()
    {
        roaming = true;
        collected = false;
        idling = false;
    }
    public void draw()
    {
         if (this.collected)
        {

        }
        else if(this.idling) {
            fp = new FirePower(texture);
            fp.Draw(this.sB, position);
        }
        else if (this.roaming)
        {

        }
    }
    private void destroy()
    {
     
            this.fp = null;
    
    }
    
    

    public Rectangle GetDestination()
    {
        return this.fp.GetDestination(position);
    }


}