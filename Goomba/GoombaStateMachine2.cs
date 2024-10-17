using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class GoombaStateMachine2
{
	private enum GoombaState {Left, Right, Stomped, Flipped};
	private GoombaState _currentState = GoombaState.Right;
	private GoombaSprites _sprite;

	public GoombaStateMachine2(int posX, int posY)
	{
		_sprite = new GoombaSprites(posX, posY);
	}
    public void changeDirection()
	{
		switch (_currentState)
		{
			case GoombaState.Left:
				_currentState = GoombaState.Right;
				break;
			case GoombaState.Right:
				_currentState = GoombaState.Left;
				break;
		}
	}

	public void beStomped()
	{
        if (_currentState != GoombaState.Stomped)
        {
            _currentState = GoombaState.Stomped;
        }

    }

	public void beFlipped()
	{
		if (_currentState != GoombaState.Flipped)
		{
			_currentState = GoombaState.Flipped;
		}
	}
    public void Update()
	{
        switch (_currentState)
		{
            case GoombaState.Left:
				_sprite.LeftLogic();
				break;
			case GoombaState.Right:
				_sprite.RightLogic();
				break;
			case GoombaState.Stomped:
				_sprite.StompedLogic();
				break;
			case GoombaState.Flipped:
				_sprite.FlippedLogic();
				break;
        }

    }
	public Rectangle GetDestination()
	{
		return _sprite.GetDestination();

    }
	public void Draw(SpriteBatch sb, Texture2D Texture)
	{
		_sprite.Draw(sb, Texture);
	}
}
