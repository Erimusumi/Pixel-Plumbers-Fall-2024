using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HudCoins : IHudElement
{
    private int numCoins;
    public HudCoins(int startCoins)
    {
        numCoins = startCoins;
    }

    public bool CollectCoin()
    {
        numCoins += 1;
        //Rollover number of coins from 100 to 0
        //If 100 coins collected, return true
        //HudManager will read this to update HudLives
        if (numCoins >= 100)
        {
            numCoins = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetNumCoins()
    {
        return numCoins;
    }

    public void SetNumCoins(int newNumCoins)
    {
        numCoins = newNumCoins;
    }
    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch sb)
    {

    }
}
