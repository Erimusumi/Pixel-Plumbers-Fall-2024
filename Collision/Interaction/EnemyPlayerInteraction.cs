using System;
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
        PlayerStateMachine playerStateMachine = player.getStateMachine();
        Rectangle playersR = player.GetDestination();
        Rectangle enemyR = enemy.GetDestination();

        if (playerStateMachine.HasStar())
        {
            enemy.beFlipped();
            entitiesRemoved.Add(enemy);
            player.AddScore(100);
        } else if ((Overlap.Width >= Overlap.Height) && (Math.Abs(playersR.Height - playersR.Y) < Math.Abs(enemyR.Height -enemyR.Y)))
        {
            enemy.beStomped();
            player.SetVelocityY(-450);
            if (enemy.GetType() != typeof(Koopa))
            {
                entitiesRemoved.Add(enemy);
                player.AddScore(100);
            }

        } else
        {
            player.TakeDamage();
        }
    }
}

