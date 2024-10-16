﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fireball : IProjectile
{
    /*
     * When a fireball hits the ground, it bounces up a little bit
     * Use isBouncing and bounceTimer to track this
    */
    private bool isBouncing;
    private bool goingRight;
    private int bounceTimer;
    private Vector2 pos;

    private FireballSprite sprite;
    private GameTime gameTime;
    private Game1 game;
    public Fireball(Vector2 marioPosition, Texture2D texture, GameTime gameTime, MarioStateMachine.MarioFaceState direction, Game1 game)
    {
        isBouncing = false;
        pos = marioPosition;
        sprite = new FireballSprite(texture);
        this.gameTime = gameTime;
        bounceTimer = 0;
        goingRight = (direction == MarioStateMachine.MarioFaceState.Right);
        this.game = game;
    }
    private void Move()
    {
        if (goingRight)
        {
            //If mario was facing right when shooting, move to the right
            pos.X += 1;
        }
        else
        {
            //Same as above, but for left
            pos.X += -1;
        }

        if (isBouncing)
        {
            //Move up some
            pos.Y += -1;
            bounceTimer += -5;
            if (bounceTimer <= 0)
            {
                isBouncing = false;
            }
        }
        else
        {
            //Move down some
            pos.Y += 1;
        }
    }
    public void Bounce()
    {
        //Call when top/bottom collision with a block
        isBouncing = true;
        bounceTimer = 200;
    }

    public void Remove()
    {
        game.fireballs.Remove(this);
    }
    public void Update(GameTime gameTime)
    {
        this.Move();
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch sb)
    {
        sprite.Draw(sb, pos);
    }

    public Rectangle GetDestination()
    {
        //All fireball sprites are 8*8
        return new Rectangle((int)pos.X, (int)pos.Y, 8, 8);
    }
}
