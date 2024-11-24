﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class EnemyPlayerInteraction
{
    ISpriteEnemy enemy;
    IPlayer player;
    Rectangle Overlap;
    List<IEntity> entitiesRemoved;
    public EnemyPlayerInteraction(ISpriteEnemy _enemy, IPlayer _player, Rectangle _Overlap, List<IEntity> _entitiesRemoved)
    {
        enemy = _enemy;
        player = _player;
        Overlap = _Overlap;
        entitiesRemoved = _entitiesRemoved;
    }
    public void Update()
    {
        if (player.HasStar())
        {
            enemy.beFlipped();
            entitiesRemoved.Add(enemy);

        } else if (Overlap.Width >= Overlap.Height)
        {
            enemy.beStomped();
            player.SetVelocityY(-450);
            entitiesRemoved.Add(enemy);

        } else
        {
            player.TakeDamage();
        }
    }
}
