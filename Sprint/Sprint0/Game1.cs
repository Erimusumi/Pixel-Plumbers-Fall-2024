using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private SpriteFont _font;

        IController control;
        IController controlM;
        ISprite sprite;
        Text text;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            sprite = new NonMovingNonAnimated();
            control = new KeyboardController(this);
            controlM = new MouseController(this);
            text = new Text();

            base.Initialize();
        }

        public void Set(ISprite sprite1)
        {
            sprite = sprite1;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //_texture = Content.LoadLocalized<Texture2D>("luigi");
            _texture = Content.Load<Texture2D>("luigi");
            _font = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            
            control.Updates();
            controlM.Updates();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            text.Draw(_spriteBatch, _font);
            sprite.Updates();
            sprite.Draw(_spriteBatch, _texture);

            base.Draw(gameTime);
        }
    }
}
