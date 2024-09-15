using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mario0
{
    public class Controller
    {
        //Mouse mouse = new Mouse();
        public int Cue;
        public Controller()
        {
            Cue = -1;
        }


        public void UpdateCue()
        {

            var kstate = Keyboard.GetState();
            var mstate = Mouse.GetState();


            if (kstate.IsKeyDown(Keys.D0) || mstate.RightButton == ButtonState.Pressed)
            {
                Cue = 0;
            }
            if (kstate.IsKeyDown(Keys.D1) || (mstate.LeftButton == ButtonState.Pressed && (mstate.X < 400 && mstate.Y < 240)))
            {
                Cue = 1;

            }
            if (kstate.IsKeyDown(Keys.D2) || (mstate.LeftButton == ButtonState.Pressed && (mstate.X > 400 && mstate.Y < 240)))
            {
                Cue = 2;

            }
            if (kstate.IsKeyDown(Keys.D3) || (mstate.LeftButton == ButtonState.Pressed && (mstate.X < 400 && mstate.Y > 240)))
            {
                Cue = 3;

            }
            if (kstate.IsKeyDown(Keys.D4) || (mstate.LeftButton == ButtonState.Pressed && (mstate.X > 400 && mstate.Y > 240)))
            {
                Cue = 4;

            }




        }
    }
}
