using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class BlackJackStateMachine
{
    private enum BlackJackState {table, top, cardPlayed};
    private BlackJackState _currentState = BlackJackState.table;
    private BlackJackSprites _sprite;
    private SoundEffect fwip;
    private int stand = 0;
    private int numberOfStands = 0;

    public BlackJackStateMachine(Texture2D TextureTable, Texture2D TextureTop, Texture2D TextureCards, SoundEffect fwip, SpriteFont font)
    {
        _sprite = new BlackJackSprites(TextureTable, TextureTop, TextureCards, font);
        this.fwip = fwip;
    }

    public void play()
    {
        _currentState = BlackJackState.top;
    }

    public void stop()
    {
        _currentState = BlackJackState.table;
    }

    public void Stand()
    {
        stand = 1;
        numberOfStands++;
    }
    public int StandNumber()
    {
        return numberOfStands;
    }
    public SoundEffect effect()
    {
        return fwip;
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
                _sprite.cards(stand);
                _currentState = BlackJackState.top;
                break;
        }
        if (stand == 1)
        {
            stand = 0;
        }
    }
    public Rectangle DestinationRectangle()
    {
        return _sprite.DestinationRectangle();
    }
    public void Draw(SpriteBatch sb)
    {
        _sprite.Draw(sb, numberOfStands);
    }
}
