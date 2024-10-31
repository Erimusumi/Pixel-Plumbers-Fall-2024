using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Formats.Asn1.AsnWriter;

public class HudScore : IHudElement
{
    private const float scale = 0.6f;
    private Vector2 screenPos;
    private int numScore;
    private SpriteFont _font;
    public HudScore(int startScore, SpriteFont font)
    {
        numScore = startScore;
        this._font = font;
    }

    public void AddScore(int scoreAmt)
    {
        numScore += scoreAmt;
    }

    public int GetScore()
    {
        return numScore;
    }
    public void SetScore(int scoreAmt)
    {
        numScore = scoreAmt;
    }
    public void Update(GameTime gameTime, FollowCamera camera)
    {
        screenPos = camera.position;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.DrawString(_font, "SCORE", new Vector2(screenPos.X + 490, screenPos.Y + 10), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        sb.DrawString(_font, numScore.ToString(), new Vector2(screenPos.X + 490, screenPos.Y + 30), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }
}
