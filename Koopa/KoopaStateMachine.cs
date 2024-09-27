﻿using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;


public class KoopaStateMachine
{
	private enum KoopaState {Left, Right, StompedLeft, StompedRight, Flipped};
	private KoopaState _currentState = KoopaState.Left;
	private KoopaSprites _sprite;

	public KoopaStateMachine()
	{
		_sprite = new KoopaSprites();
	}
    public void changeDirection()
	{
		switch (_currentState)
		{
			case KoopaState.Left:
				_currentState = KoopaState.Right;
				break;
			case KoopaState.Right:
				_currentState = KoopaState.Left;
				break;
            case KoopaState.StompedLeft:
                _currentState = KoopaState.Left;
                break;
            case KoopaState.StompedRight:
                _currentState = KoopaState.Right;
                break;
        }
	}

	public void beStomped()
	{
		switch (_currentState)
		{
			case KoopaState.Left:
				_currentState = KoopaState.StompedLeft;
				break;
			case KoopaState.Right:
				_currentState = KoopaState.StompedRight;
				break;
		}

	}

	public void beFlipped()
	{
		if (_currentState != KoopaState.Flipped)
		{
			_currentState = KoopaState.Flipped;
		}
	}
    public void Update()
	{
        switch (_currentState)
		{
            case KoopaState.Left:
				_sprite.LeftLogic();
				break;
			case KoopaState.Right:
				_sprite.RightLogic();
				break;
			case KoopaState.StompedLeft:
				_sprite.StompedLogic();
				break;
            case KoopaState.StompedRight:
                _sprite.StompedLogic();
                break;
            case KoopaState.Flipped:
				_sprite.FlippedLogic();
				break;
        }

    }
	public void Draw(SpriteBatch sb, Texture2D Texture)
	{
		_sprite.Draw(sb, Texture);
	}
}