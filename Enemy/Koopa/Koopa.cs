﻿using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;


public class Koopa : ISpriteEnemy
{
    private KoopaStateMachine stateMachine;
	private float groundPosition = 385f;
	public Koopa(int posX, int posY)
	{
		stateMachine = new KoopaStateMachine(posX, posY);
	}

	public Boolean IsMovingShell()
	{
		return stateMachine.IsMovingShell();
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