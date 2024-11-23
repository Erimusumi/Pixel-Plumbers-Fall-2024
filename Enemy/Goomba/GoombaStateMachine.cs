using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class GoombaStateMachine
{
	private enum GoombaState {Left, Right, Stomped, Flipped, Start};
	private GoombaState _currentState = GoombaState.Start;
	private GoombaSprites _sprite;
	private Boolean _isFlipped = true;
	private IPlayer player;
	GameTime gameTime;

    public GoombaStateMachine(int posX, int posY, IPlayer player, GameTime gameTime)
	{
		_sprite = new GoombaSprites(posX, posY);
		this.player = player;
		this.gameTime = gameTime;
	}

    public Boolean IsFlipped()
    {
        return _isFlipped;
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
		Rectangle pHold = player.GetDestination();
		Rectangle goombaRec = _sprite.GetDestination();
        if (((goombaRec.X - pHold.X) > 0) && ((goombaRec.X - pHold.X) < 400) && (_currentState == GoombaState.Start)){
            _currentState = GoombaState.Left;
        }
        _sprite.ApplyGravity(gameTime);

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
				_sprite.FlippedLogic(0);
				break;
			case GoombaState.Start:
				_sprite.FlippedLogic(1);
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
