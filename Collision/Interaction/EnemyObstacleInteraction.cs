using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class EnemyObstacleInteraction
{
    private ISpriteEnemy enemy;
    private IObstacle obstacle;
    private Rectangle enemyRect;
    private Rectangle obstacleRect;

    public EnemyObstacleInteraction(ISpriteEnemy enemy, IObstacle obstacle)
    {
        this.enemy = enemy;
        this.obstacle = obstacle;
        enemyRect = enemy.GetDestination();
        obstacleRect = obstacle.GetDestination();
    }
    public void update()
    {
        float overlapLeft = enemyRect.Right - obstacleRect.Left;
        float overlapRight = obstacleRect.Right - enemyRect.Left;
        float overlapTop = enemyRect.Bottom - obstacleRect.Top;
        float overlapBottom = obstacleRect.Bottom - enemyRect.Top;

        // Determine the smallest overlap to find the collision side
        float minOverlap = Math.Min(Math.Min(overlapLeft, overlapRight), Math.Min(overlapTop, overlapBottom));

       if (minOverlap == overlapLeft)
        {
            // Collision from the left
            enemy.changeDirection();
        }
        else if (minOverlap == overlapRight)
        {
            // Collision from the right
            enemy.changeDirection();
        }

    }
}

