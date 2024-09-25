﻿using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class GoombaCommand : IController
{
    int count = 0;
    private ISpriteEnemy _sprite;

    public GoombaCommand(ISpriteEnemy sprite1)
    {
        _sprite = sprite1;
    }

    public void Update(GameTime gameTime)
    {
        count++;
        if (count % 50 == 0)
        {
            _sprite.changeDirection();
        }
        if (count == 200)
        {
            _sprite.beFlipped();
        }
        if (count == 300)
        {
            _sprite.beStomped();
        }
        if (count == 400)
        {
            count = 0;
        }

    }
}
