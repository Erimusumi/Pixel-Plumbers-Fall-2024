using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class BlooperStateMachine
{
    private enum BlooperState { Left, Right, Stomped, Flipped };
    private BlooperState _currentState = BlooperState.Right;
    private BlooperSprites _sprite;
    private Boolean _isFlipped = false;

    public BlooperStateMachine(int posX, int posY, Mario mario)
    {
        _sprite = new BlooperSprites(posX, posY, mario);
    }

    public Boolean IsFlipped()
    {
        return _isFlipped;
    }
    public void changeDirection()
    {
        switch (_currentState)
        {
            case BlooperState.Left:
                _currentState = BlooperState.Right;
                break;
            case BlooperState.Right:
                _currentState = BlooperState.Left;
                break;
        }
    }

    public void beStomped()
    {
        if (_currentState != BlooperState.Stomped)
        {
            _currentState = BlooperState.Stomped;
        }

    }

    public void beFlipped()
    {
        if (_currentState != BlooperState.Flipped)
        {
            _currentState = BlooperState.Flipped;
        }
    }
    public void Update()
    {
        switch (_currentState)
        {
            case BlooperState.Left:
                _sprite.LeftLogic();
                break;
            case BlooperState.Right:
                _sprite.RightLogic();
                break;
            case BlooperState.Stomped:
                _sprite.StompedLogic();
                break;
            case BlooperState.Flipped:
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
