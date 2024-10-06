﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    private int bounceTimer;
    private Vector2 pos;

    private FireballSprite sprite;
    private GameTime gameTime;
    public Fireball(Vector2 marioPosition, Texture2D texture, GameTime gameTime)
    {
        isBouncing = false;
        pos = marioPosition;
        sprite = new FireballSprite(texture);
        this.gameTime = gameTime;
    }
    private void Move()
    {
        //TODO: Move right some amount
        if (isBouncing)
        {
            //Move up some
        }
        else
        {
            //Move down some
        }
    }
    public void Bounce()
    {
        //Call when top/bottom collision with a block
        isBouncing = true;
        bounceTimer = 200;
    }
    public void Update()
    {
        this.Move();
        sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch sb)
    {
        sprite.Draw(sb, pos);
    }
}
