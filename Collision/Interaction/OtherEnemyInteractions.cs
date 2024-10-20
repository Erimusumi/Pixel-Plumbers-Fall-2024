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
    public OtherEnemyInteraction(ISpriteEnemy _enemy, IEntity _item2)
    {
        enemy = _enemy;
        item2 = _item2;
    }
    public void Update()
    {
        //System.Diagnostics.Debug.WriteLine("entered?");

        if (item2.GetType() == typeof(Koopa))
        {
            Koopa koopa = (Koopa)item2;
            if (koopa.IsMovingShell())
            {
                enemy.beFlipped();
                koopa.changeDirection();
            } else
            {
                enemy.changeDirection();
            }
        } else
        {
            enemy.changeDirection();
        }
        
    }
}

