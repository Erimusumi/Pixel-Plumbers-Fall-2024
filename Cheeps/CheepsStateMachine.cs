using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class CheepsStateMachine
{
	private enum CheepsState { Left, Right, Flipped};
	private CheepsState _currentState = CheepsState.Left;
	private CheepsSprites _sprite;

	public CheepsStateMachine(int color, int posX, int posY)
	{
		_sprite = new CheepsSprites(color, posX, posY);
	}
    public void changeDirection()
	{
		switch (_currentState)
		{
			case CheepsState.Left:
				_currentState = CheepsState.Right;
				break;
			case CheepsState.Right:
				_currentState = CheepsState.Left;
				break;
		}
	}

	public void beStomped()
	{

    }

	public void beFlipped()
	{
		if (_currentState != CheepsState.Flipped)
		{
			_currentState = CheepsState.Flipped;
		}
	}
    public void Update()
	{
        switch (_currentState)
		{
            case CheepsState.Left:
				_sprite.LeftLogic();
				break;
			case CheepsState.Right:
				_sprite.RightLogic();
				break;
			case CheepsState.Flipped:
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
