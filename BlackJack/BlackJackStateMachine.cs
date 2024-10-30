using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class BlackJackStateMachine
{
    private enum BlackJackState {table, top, cardPlayed};
    private BlackJackState _currentState = BlackJackState.table;
    private BlackJackSprites _sprite;

    public BlackJackStateMachine(Texture2D TextureTable, Texture2D TextureTop, Texture2D TextureCards)
    {
        _sprite = new BlackJackSprites(TextureTable, TextureTop, TextureCards);
    }

    public void play()
    {
        _currentState = BlackJackState.top;
    }

    public void stop()
    {
        _currentState = BlackJackState.table;
    }

    public void playACard()
    {
        _currentState = BlackJackState.cardPlayed;
    }

    public void Update()
    {
        switch (_currentState)
        {
            case BlackJackState.table:
                _sprite.table();
                break;
            case BlackJackState.top:
                _sprite.tabletop();
                break;
            case BlackJackState.cardPlayed:
                _sprite.cards();
                _currentState = BlackJackState.top;
                break;
        }
    }
    public Rectangle DestinationRectangle()
    {
        return _sprite.DestinationRectangle();
    }
    public void Draw(SpriteBatch sb)
    {
        _sprite.Draw(sb);
    }
}
