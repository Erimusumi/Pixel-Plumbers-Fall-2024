using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SprintZero
{
    public class MouseController : IController
    {
        private Game1 _game;

        public MouseController(Game1 game)
        {
            _game = game;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;
            int windowWidth = _game.GraphicsDevice.Viewport.Width;
            int windowHeight = _game.GraphicsDevice.Viewport.Height;

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                _game.Exit();
            }

            int quarterWidth = windowWidth / 2;
            int quarterHeight = windowHeight / 2;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseX < quarterWidth && mouseY < quarterHeight)
                {
                    _game.ShowSprite1 = true;
                    _game.ShowSprite2 = false;
                    _game.ShowSprite3 = false;
                    _game.ShowSprite4 = false;
                }
                else if (mouseX >= quarterWidth && mouseY < quarterHeight)
                {
                    _game.ShowSprite1 = false;
                    _game.ShowSprite2 = true;
                    _game.ShowSprite3 = false;
                    _game.ShowSprite4 = false;
                }
                else if (mouseX < quarterWidth && mouseY >= quarterHeight)
                {
                    _game.ShowSprite1 = false;
                    _game.ShowSprite2 = false;
                    _game.ShowSprite3 = false;
                    _game.ShowSprite4 = true;
                }
                else if (mouseX >= quarterWidth && mouseY >= quarterHeight)
                {
                    _game.ShowSprite1 = false;
                    _game.ShowSprite2 = false;
                    _game.ShowSprite3 = true;
                    _game.ShowSprite4 = false;
                }
            }
        }
    }
}
