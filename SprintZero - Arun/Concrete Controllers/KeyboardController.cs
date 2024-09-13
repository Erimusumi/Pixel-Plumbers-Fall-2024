using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SprintZero
{
    public class KeyboardController : IController
    {
        private Game1 _game;
        public KeyboardController(Game1 game)
        {
            _game = game;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.D0))
            {
                _game.Exit();
            }

            if (keyboardState.IsKeyDown(Keys.D1))
            {
                _game.ShowSprite1 = true;
                _game.ShowSprite2 = false;
                _game.ShowSprite3 = false;
                _game.ShowSprite4 = false;
            }

            if (keyboardState.IsKeyDown(Keys.D2))
            {
                _game.ShowSprite1 = false;
                _game.ShowSprite2 = true;
                _game.ShowSprite3 = false;
                _game.ShowSprite4 = false;
            }

            if (keyboardState.IsKeyDown(Keys.D3))
            {
                _game.ShowSprite1 = false;
                _game.ShowSprite2 = false;
                _game.ShowSprite3 = false;
                _game.ShowSprite4 = true;
            }

            if (keyboardState.IsKeyDown(Keys.D4))
            {
                _game.ShowSprite1 = false;
                _game.ShowSprite2 = false;
                _game.ShowSprite3 = true;
                _game.ShowSprite4 = false;
            }
        }
    }
}
