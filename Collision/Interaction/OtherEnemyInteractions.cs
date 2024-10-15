using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class OtherEnemyInteraction
{
    ISpriteEnemy enemy;
    Mario mario;
    public OtherEnemyInteraction(ISpriteEnemy _enemy)
    {
        enemy = _enemy;
    }
    public void update()
    {
        enemy.changeDirection();
    }
}

