using Sprint0;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Linq;

public class mouseController : IController
{
    Game1 game;
    Texture2D texture;
    SpriteBatch spriteBatch;
    public mouseController(Game1 g, Texture2D t, SpriteBatch _spriteBatch)
    {
        game = g;
        texture = t;
        spriteBatch = _spriteBatch;
    }
    public void Update()
    {
        MouseState mouseState = Mouse.GetState();
        Rectangle topLeftQuarter = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
        Rectangle topRightQuarter = new Rectangle(game.GraphicsDevice.Viewport.Width / 2, 0, game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
        Rectangle bottomLeftQuarter = new Rectangle(0, game.GraphicsDevice.Viewport.Height / 2, game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
        Rectangle bottomRightQuarter = new Rectangle(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2, game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);


        if (topLeftQuarter.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
        {
            game.Refresh(new singleFrameWithFixedPosition());
        }

        else if (topRightQuarter.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
        {
            game.Refresh(new animatedSpriteWithFixedPosition());
        }

        else if (bottomLeftQuarter.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
        {
            game.Refresh(new singleFrameWithMoving());
        }

        else if (bottomRightQuarter.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
        {
            game.Refresh(new animatedSpriteWithMoving());
        }

        else if (mouseState.RightButton == ButtonState.Pressed)
        {
            game.Exit();
        }
    }

}
