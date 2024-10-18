using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class Goomba2 : ISpriteEnemy
{
    private GoombaStateMachine2 stateMachine;
	public Goomba2(int posX, int posY)
	{
		stateMachine = new GoombaStateMachine2(posX, posY);
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

}
