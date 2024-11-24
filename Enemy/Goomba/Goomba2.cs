﻿using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class Goomba2 : ISpriteEnemy
{
    private GoombaStateMachine2 stateMachine;
	private float groundPosition = 385f;
	public Goomba2(int posX, int posY, GameTime gameTime)
	{
		stateMachine = new GoombaStateMachine2(posX, posY, gameTime);
	}

	public void changeDirection()
	{
		stateMachine.changeDirection();
	}

	public void beStomped()
	{
		stateMachine.beStomped();
	}
	public void beFlipped()
	{
		stateMachine.beFlipped();
	}

	public void Updates()
	{
		stateMachine.Update();
	}

	public Rectangle GetDestination()
	{
		return stateMachine.GetDestination();
	}

    public void Draw(SpriteBatch sb, Texture2D Texture)
	{
        stateMachine.Draw(sb, Texture);
    }
	public void setGroundPosition(float x)
	{
		this.groundPosition = x;
	}

}