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
    public void update()
    {
        if (Overlap.X >= Overlap.Y)
        {
            enemy.beStomped();
            //make mario's velocity y, or slightly negative, so he can sort of bounce off the enemy.
            //mario.velocityy = 0;
        }
        else
        {
            //Not correct, I need star mario
            if(mario.GetType() == typeof(StarPower))
            {
                enemy.beFlipped();
            } else
            {
                mario.MarioTakeDamage();
            }
        }
    }
}

