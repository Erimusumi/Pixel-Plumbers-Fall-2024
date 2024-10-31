using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

public class HudTime : IHudElement
{
    private const float scale = 0.6f;
    private Vector2 screenPos;
    private int currTime;
    private float gameTicks;
    private SpriteFont _font;
    public HudTime(int startTime, SpriteFont font)
    {
        currTime = startTime;
        _font = font;
    }

    public void SetTime(int newTime)
    {
        currTime = newTime;
    }

    public int GetTime() 
    {
        return currTime;
    }
    public void Update(GameTime gameTime, FollowCamera camera)
    {
        screenPos = camera.position;

        this.gameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        if (this.gameTicks > 1000)
        {
            currTime -= 1;
            this.gameTicks = 0;
        }
    }

    public void Draw(SpriteBatch sb)
    {
        sb.DrawString(_font, "TIME:", new Vector2(screenPos.X + 650, screenPos.Y + 10), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        sb.DrawString(_font, currTime.ToString(), new Vector2(screenPos.X + 650, screenPos.Y + 30), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }
}
