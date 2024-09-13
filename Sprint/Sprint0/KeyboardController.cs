using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class KeyboardController : IController
{
    Game1 game1;

    public KeyboardController(Game1 game)
    {
        game1 = game;
    }

    public void Updates() {
        

        if (Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0))
        {
            game1.Exit();
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
        {
            game1.Set(new NonMovingNonAnimated());
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2))
        {
            game1.Set(new NonMoving());
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3))
        {
            game1.Set(new NonAnimated());
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
        {
            game1.Set(new MovingAnimated());
        }
        
    }


}
