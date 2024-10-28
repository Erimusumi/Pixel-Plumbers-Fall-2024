using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HudLevel : IHudElement
{
    private int worldNum;
    private int levelNum;
    public HudLevel(int startWorld, int startLevel)
    {
        worldNum = startWorld;
        levelNum = startLevel;
    }

    public void ChangeWorld(int newWorldNum)
    {
        this.worldNum = newWorldNum;
    }
    public void ChangeLevel(int newLevelNum)
    {
        this.levelNum = newLevelNum;
    }

    public int GetLevel()
    {
        return this.levelNum;
    }

    public int GetWorld()
    {
        return this.worldNum;
    }
    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch sb)
    {

    }
}
