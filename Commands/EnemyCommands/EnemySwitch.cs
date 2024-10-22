using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;
using System.Xml.Linq;

public class EnemySwitch : ICommand
{
    Game1 game1;
    //0 is P, 1 is O
    int PorO;
    List<ISpriteEnemy> enemies;
    public EnemySwitch(Game1 game, int _PorO, List<ISpriteEnemy> _enemies)
    {
        game1 = game;
        PorO = _PorO;
        enemies = _enemies;
    }
    private ISpriteEnemy current;
    private ISpriteEnemy lastSprite;

    public void Execute()
    {
        lastSprite = enemies[0];
        current = enemies[0];
        //P
        if (PorO == 0)
        {
            enemies.RemoveAt(0);
            enemies.Add(current);
        } else
        {
            for (int i = enemies.Count - 1; i > 0; i--)
            {
                ISpriteEnemy hold1 = enemies[i];
                ISpriteEnemy hold2 = enemies[i-1];
                enemies[i-1] = hold1;
                enemies[i] = hold2;
            }
        }
        current = enemies[0];
        if (current.GetType() == typeof(Goomba) || current.GetType() == typeof(Koopa))
        {
            game1.SetEnemy((ISpriteEnemy)Activator.CreateInstance(current.GetType(), 480, 400));
        } else if ((lastSprite.GetType() == typeof(Goomba)) && (PorO == 0) || (lastSprite.GetType() == typeof(Koopa)) && (PorO != 0))
        {
            game1.SetEnemy((ISpriteEnemy)Activator.CreateInstance(current.GetType(), 0, 480, 400));
        } else
        {
            game1.SetEnemy((ISpriteEnemy)Activator.CreateInstance(current.GetType(), 1, 480, 400));
        }
    }

}