﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

public class HudLevel : IHudElement
{
    private const float scale = 0.6f;
    private Vector2 screenPos;
    private int worldNum;
    private int levelNum;
    private SpriteFont _font;
    public HudLevel(int startWorld, int startLevel, SpriteFont font)
    {
        worldNum = startWorld;
        levelNum = startLevel;
        _font = font;
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
    public void Update(GameTime gameTime, FollowCamera camera)
    {
        screenPos = camera.position;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.DrawString(_font, "WORLD", new Vector2(screenPos.X + 330, screenPos.Y + 10), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        sb.DrawString(_font, worldNum.ToString() + "-" + levelNum.ToString(), new Vector2(screenPos.X + 330, screenPos.Y + 30), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }
}
