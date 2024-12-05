﻿using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class BlooperStateMachine
{
    private enum BlooperState { Left, Right, Idle, Flipped, Start};
    private BlooperState _currentState = BlooperState.Start;
    private BlooperSprites _sprite;
    private Boolean _isFlipped = false;
    private IPlayer mario;
    private int RiseMore = 0;
    public BlooperStateMachine(int posX, int posY, IPlayer mario, IPlayer luigi)
    {
        _sprite = new BlooperSprites(posX, posY);
        this.mario = mario;
    }

    public Boolean IsFlipped()
    {
        return _isFlipped;
    }
    public void changeDirection()
    {
    }
    public void beStomped()
    {
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

        Rectangle holdSprite = _sprite.GetDestination();
        Rectangle holdMario = mario.GetDestination();
        Rectangle holdLuigi = mario.GetDestination();
        Rectangle goombaRec = _sprite.GetDestination();
        if (((goombaRec.X - holdMario.X) > 0) && ((goombaRec.X - holdMario.X) < 400) && (_currentState == BlooperState.Start))
        {
            _currentState = BlooperState.Left;
        }
        if (((goombaRec.X - holdLuigi.X) > 0) && ((goombaRec.X - holdLuigi.X) < 400) && (_currentState == BlooperState.Start))
        {
            _currentState = BlooperState.Left;
        }

        if (
            ((holdMario.X < holdSprite.X) && (Math.Abs(holdMario.X - holdSprite.X) > 5)) ||
            ((holdLuigi.X < holdSprite.X) && (Math.Abs(holdLuigi.X - holdSprite.X) > 5))
            )
        {
            _currentState = BlooperState.Left;
        } else if (
            ((holdMario.X > holdSprite.X) && (Math.Abs(holdMario.X - holdSprite.X) > 5)) ||
            ((holdLuigi.X > holdSprite.X) && (Math.Abs(holdLuigi.X - holdSprite.X) > 5))
            )
        {
            _currentState = BlooperState.Right;
        }else
        {
            _currentState = BlooperState.Idle;
        }

        RiseMore = 384 - holdMario.Y;

        switch (_currentState)
        {
            case BlooperState.Left:
                _sprite.LeftLogic(RiseMore);
                break;
            case BlooperState.Right:
                _sprite.RightLogic(RiseMore);
                break;
            case BlooperState.Idle:
                _sprite.Idle(RiseMore);
                break;
            case BlooperState.Flipped:
                _sprite.FlippedLogic();
                break;
            case BlooperState.Start:
                _sprite.StartLogic();
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
