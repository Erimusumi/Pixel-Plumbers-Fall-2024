using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HudLives : IHudElement
{
    private int numLives;
    public HudLives(int startLives)
    {
        numLives = startLives;
    }

    public void AddLife()
    {
        numLives += 1;
    }

    public void LoseLife()
    {
        numLives -= 1;
    }

    public int GetNumLives()
    {
        return numLives;
    }

    public void SetNumLives(int newNumLives)
    {
        numLives = newNumLives;
    }
    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch sb)
    {

    }
}
