using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class Goomba : ISpriteEnemy
{
    private GoombaStateMachine stateMachine;
	private float groundPosition = 385f;
	public Goomba(int posX, int posY, IPlayer player, GameTime gameTime)
	{
		stateMachine = new GoombaStateMachine(posX, posY, player, gameTime);
	}
	public Boolean IsFlipped()
	{
		return stateMachine.IsFlipped();
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
