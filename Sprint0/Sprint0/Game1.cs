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
        IController controlKey;
        ISpriteEnemy sprite;
        Text text;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            sprite = new Goomba();
            control = new GoombaCommand(sprite);
            controlKey = new KeyboardController(this);
            text = new Text();

            base.Initialize();
        }

        public ISpriteEnemy SetEnemy(ISpriteEnemy sprite1)
        {
            sprite = sprite1;
            return sprite;
        }
        public void Set(ISprite sprite1)
        {
        }

        public void Set2(IController control1)
        {
            control = control1;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //_texture = Content.LoadLocalized<Texture2D>("luigi");
            _texture = Content.Load<Texture2D>("enemies");
            _font = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            
            control.Updates();
            controlKey.Updates();
            sprite.Updates();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            text.Draw(_spriteBatch, _font);
            sprite.Draw(_spriteBatch, _texture);

            base.Draw(gameTime);
        }
    }
}
