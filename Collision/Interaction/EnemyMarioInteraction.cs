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
        if (mario.HasStar())
        {
            enemy.beFlipped();
        } else if (Overlap.Width >= Overlap.Height)
        {
            enemy.beStomped();
            mario.marioVelocity.Y = 300;
        } else
        {
            mario.MarioTakeDamage();
        }
    }
}

