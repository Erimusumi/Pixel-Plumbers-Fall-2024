using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private KeyboardController _keyboardController;
        private MouseController _mouseController;

        private OneFrameFixedSprite _sprite1;
        private AnimatedeFixedSprite _sprite2;
        private AnimatedeLeftRightSprite _sprite3;
        private OneFrameUpDown _sprite4;


        public bool ShowSprite1 { get; set; } = true;
        public bool ShowSprite2 { get; set; } = false;
        public bool ShowSprite3 { get; set; } = false;
        public bool ShowSprite4 { get; set; } = false;

        private SpriteFont MyFont;
        private DisplayText MyText;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _keyboardController = new KeyboardController(this);
            _mouseController = new MouseController(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MyFont = Content.Load<SpriteFont>("MyFonts");
            MyText = new(MyFont);

            _sprite1 = new OneFrameFixedSprite(Content.Load<Texture2D>("mario"));
            _sprite1.LoadContent(_graphics);

            _sprite2 = new AnimatedeFixedSprite(Content.Load<Texture2D>("mario"));
            _sprite2.LoadContent(_graphics);

            _sprite3 = new AnimatedeLeftRightSprite(Content.Load<Texture2D>("mario"));
            _sprite3.LoadContent(_graphics);

            _sprite4 = new OneFrameUpDown(Content.Load<Texture2D>("mario"));
            _sprite4.LoadContent(_graphics);
        }

        protected override void Update(GameTime gameTime)
        {
            _keyboardController.Update(gameTime);
            _mouseController.Update(gameTime);

            if (ShowSprite1)
                _sprite1.Update(gameTime);

            if (ShowSprite2)
                _sprite2.Update(gameTime);

            if (ShowSprite3)
                _sprite3.Update(gameTime);

            if (ShowSprite4)
                _sprite4.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (ShowSprite1)
            {
                _sprite1.Draw(_graphics, _spriteBatch);
            }
            else if (ShowSprite2)
            {
                _sprite2.Draw(_graphics, _spriteBatch);
            }
            else if (ShowSprite3)
            {
                _sprite3.Draw(_graphics, _spriteBatch);
            }
            else if (ShowSprite4)
            {
                _sprite4.Draw(_graphics, _spriteBatch);
            }

                MyText.Draw(_graphics, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
