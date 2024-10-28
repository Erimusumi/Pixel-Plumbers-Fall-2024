using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HudTime : IHudElement
{
    private int currTime;
    private float gameTicks;
    public HudTime(int startTime)
    {
        currTime = startTime;
    }

    public void SetTime(int newTime)
    {
        currTime = newTime;
    }

    public int GetTime() 
    {
        return currTime;
    }
    public void Update(GameTime gameTime)
    {
        this.gameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        if (this.gameTicks > 1000)
        {
            currTime -= 1;
            this.gameTicks = 0;
        }
    }

    public void Draw(SpriteBatch sb)
    {

    }
}
