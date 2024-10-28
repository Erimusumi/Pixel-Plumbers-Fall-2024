using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HudManager
{
    private HudCoins HudCoins;
    private HudLevel HudLevel;
    private HudLives HudLives;
    private HudScore HudScore;
    private HudTime HudTime;

    public HudManager()
    {
        this.HudCoins = new HudCoins(0);
        this.HudLevel = new HudLevel(1, 1);
        this.HudLives = new HudLives(3);
        this.HudScore = new HudScore(0);
        this.HudTime = new HudTime(500);
    }

    public void Update(GameTime gameTime)
    {
        this.HudCoins.Update(gameTime);
        this.HudLevel.Update(gameTime);
        this.HudLives.Update(gameTime);
        this.HudScore.Update(gameTime);
        this.HudTime.Update(gameTime);
    }

    public void Draw(SpriteBatch sb)
    {
        this.HudCoins.Draw(sb);
        this.HudLevel.Draw(sb);
        this.HudLives.Draw(sb);
        this.HudScore.Draw(sb);
        this.HudTime.Draw(sb);
    }
}