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
    Rectangle enemyDestination;
    Rectangle marioDestination;
    public EnemyMarioInteraction(ISpriteEnemy _enemy, Mario _mario, Rectangle _enemyDestination, Rectangle _marioDestination)
    {
        enemy = _enemy;
        mario = _mario;
        enemyDestination = _enemyDestination;
        marioDestination = _marioDestination;
    }
    public void update()
    {
        if (((int)Math.Abs(enemyDestination.X-marioDestination.X)) >= ((int)Math.Abs(enemyDestination.Y - marioDestination.Y)))
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

