using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class KeyboardController : IController
{
    private int count = 0;
    Game1 game1;
    private IController current = new GoombaCommand(new Goomba());

    public KeyboardController(Game1 game)
    {
        game1 = game;
    }

    public void Updates() {

        count++;
        if (Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0))
        {
            game1.Exit();
        }
        
        if ((Keyboard.GetState().IsKeyDown(Keys.O) || Keyboard.GetState().IsKeyDown(Keys.P)) && (count >= 20))
        {
            switch (current)
            {
                case GoombaCommand:
                    current = new KoopaCommand(game1.SetEnemy(new Koopa()));
                    game1.Set2(current);
                    break;
                case KoopaCommand:
                    current = new GoombaCommand(game1.SetEnemy(new Goomba()));
                    game1.Set2(current);
                    break;
                default:
                    break;
            }
            count = 0;


        }
        
    }


}
