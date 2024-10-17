using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class OtherEnemyInteraction
{
    ISpriteEnemy enemy;
    IEntity item2;
    Mario mario;
    public OtherEnemyInteraction(ISpriteEnemy _enemy, IEntity _item2)
    {
        enemy = _enemy;
        item2 = _item2;
    }
    public void update()
    {
        if (item2.GetType() == typeof(ISpriteEnemy) && item2.GetType().GetType() == typeof(Koopa))
        {
            Koopa temp = (Koopa)item2;
            if (temp.IsMovingShell())
            {
                enemy.beFlipped();
            }
        }
        enemy.changeDirection();
    }
}

