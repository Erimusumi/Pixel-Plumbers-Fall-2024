using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class Cheeps : ISpriteEnemy
{
    private CheepsStateMachine stateMachine;
	public Cheeps(int color, int posX, int posY, IPlayer mario, IPlayer luigi)
	{
		stateMachine = new CheepsStateMachine(color, posX, posY, mario, luigi);
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
	//Needed in level one enemies
    public bool GetIsOnGround()
    {
		return true;
    }
    public void SetIsOnGround(bool val)
    {
    }
    public void Draw(SpriteBatch sb, Texture2D Texture)
	{
        stateMachine.Draw(sb, Texture);
    }
	public void setGroundPosition(float x)
	{

	}

}
