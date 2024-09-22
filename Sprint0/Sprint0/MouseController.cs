using Microsoft.Xna.Framework.Input;
using System;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class MouseController : IController
{
    Game1 game1;

    public MouseController(Game1 game)
    {
        game1 = game;
    }
    public void Updates()
    {

        int X = Mouse.GetState().X;
        int Y = Mouse.GetState().Y;

        if (Mouse.GetState().RightButton == ButtonState.Pressed)
        {
            game1.Exit();
        }
        if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (X < 320) && (Y < 180))
        {
            game1.Set(new NonMovingNonAnimated());
        }
        if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (X >= 320) && (Y < 180))
        {
            game1.Set(new NonMoving());
        }
        if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (X < 320) && (Y >= 180))
        {
            game1.Set(new NonAnimated());
        }
        if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (X >= 320) && (Y >= 180))
        {
            game1.Set(new MovingAnimated());
        }



    }
}
