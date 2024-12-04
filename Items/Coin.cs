﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


    public class Coin: IEntity
{
    SpriteBatch spriteBatch;
    CoinInstance coinInstance;
    Microsoft.Xna.Framework.Vector2 position;
    Texture2D texture;
    public Coin(SpriteBatch sB, Texture2D texture, Microsoft.Xna.Framework.Vector2 position)
    {
        this.spriteBatch = sB;
        this.texture = texture;
        this.position = position;
        coinInstance = new CoinInstance(texture, position);
    }
    public void Draw()
    {
        coinInstance.Draw(spriteBatch, position);
    }
    public Rectangle GetDestination()
    {
        return coinInstance.GetDestination();
    }
}

