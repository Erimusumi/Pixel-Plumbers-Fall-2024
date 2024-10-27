using System;
using System.Collections.Generic;
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
    List<IEntity> entitiesRemoved;
    public EnemyMarioInteraction(ISpriteEnemy _enemy, Mario _mario, Rectangle _Overlap, List<IEntity> _entitiesRemoved)
    {
        enemy = _enemy;
        mario = _mario;
        Overlap = _Overlap;
        entitiesRemoved = _entitiesRemoved;
    }
    public void Update()
    {
        if (mario.HasStar())
        {
            enemy.beFlipped();
            entitiesRemoved.Add(enemy);

        } else if (Overlap.Width >= Overlap.Height)
        {
            enemy.beStomped();
            mario.marioVelocity.Y = -450;
            entitiesRemoved.Add(enemy);

        } else
        {
            mario.MarioTakeDamage();
        }
    }
}

