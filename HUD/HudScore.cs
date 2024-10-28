using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HudScore : IHudElement
{
    private int numScore;
    public HudScore(int startScore)
    {
        numScore = startScore;
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
    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch sb)
    {

    }
}
