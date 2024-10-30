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

    private SpriteFont _font;

    public HudManager(SpriteFont font)
    {
        this._font = font;
        this.HudCoins = new HudCoins(0, _font);
        this.HudLevel = new HudLevel(1, 1, _font);
        this.HudLives = new HudLives(3, _font);
        this.HudScore = new HudScore(0, _font);
        this.HudTime = new HudTime(500, _font);
    }

    public void Update(GameTime gameTime, FollowCamera camera)
    {
        this.HudCoins.Update(gameTime, camera);
        this.HudLevel.Update(gameTime, camera);
        this.HudLives.Update(gameTime, camera);
        this.HudScore.Update(gameTime, camera);
        this.HudTime.Update(gameTime, camera);
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