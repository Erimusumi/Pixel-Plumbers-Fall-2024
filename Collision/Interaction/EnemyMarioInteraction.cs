using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class EnemyMarioInteraction
{
    ISpriteEnemy enemy;
    Mario mario;
    Rectangle Overlap;
    public EnemyMarioInteraction(ISpriteEnemy _enemy, Mario _mario, Rectangle _Overlap)
    {
        enemy = _enemy;
        mario = _mario;
        Overlap = _Overlap;
    }
    public void Update()
    {
        if (Overlap.X >= Overlap.Y)
        {
            enemy.beStomped();
            mario.marioVelocity.Y = 0;
        }
        else
        {
            //Not correct, I need star mario
            if(mario.HasStar())
            {
                enemy.beFlipped();
            } else
            {
                mario.MarioTakeDamage();
            }
        }
    }
}

