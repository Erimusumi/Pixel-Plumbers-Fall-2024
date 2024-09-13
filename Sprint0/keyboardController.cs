using Sprint0;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class keyboardController : IController
{
    Game1 game;
    Texture2D texture;
    SpriteBatch spriteBatch;
    public keyboardController(Game1 g, Texture2D t, SpriteBatch _spriteBatch)
    {
        game = g;
        texture = t;
        spriteBatch = _spriteBatch;
    }
    public void Update()
    {

        if (Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0))
        {
            game.Exit();
        }

        else if (Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
        {
            game.Refresh(new singleFrameWithFixedPosition());
        }

        else if (Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2))
        {
            game.Refresh(new animatedSpriteWithFixedPosition());
        }

        else if (Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3))
        {
            game.Refresh(new singleFrameWithMoving());
        }

        else if (Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
        {
            game.Refresh(new animatedSpriteWithMoving());
        }
    }

}
