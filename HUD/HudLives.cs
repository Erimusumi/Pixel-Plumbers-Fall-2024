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

    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch sb)
    {

    }
}
