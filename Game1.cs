using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace cse3902
{
    public class Game1 : Game
    {
        Texture2D marioTexture;
        Vector2 marioPosition;

        internal int currentSprite;
        internal Rectangle upperLeftQuad;
        internal Rectangle upperRightQuad;
        internal Rectangle lowerLeftQuad;
        internal Rectangle lowerRightQuad;
        internal Rectangle fullScreen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        private ISprite animatedSprite;
        private ISprite oneFrameSprite;
        private ISprite movingOneFrameSprite;
        private ISprite movingAnimatedSprite;
        private ISprite creditSprite;
        private ISprite nameSprite;
        private ISprite urlSprite;
        private ISprite urlSprite2;

        private KeyboardController keyboardController;
        private MouseController mouseController;

        private ICommand quitGameCommand;
        private ICommand setFixedSpriteCommand;
        private ICommand setAnimatedSpriteCommand;
        private ICommand setFixedMovingSpriteCommand;
        private ICommand setAnimatedMovingSpriteCommand;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            currentSprite = 1;      // default fixed sprite
            marioPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);

            // set rectangles
            upperLeftQuad = new Rectangle(0, 0, 320, 240);
            upperRightQuad = new Rectangle(320, 0, 640, 240);
            lowerLeftQuad = new Rectangle(0, 240, 400, 240);
            lowerRightQuad = new Rectangle(320, 240, 640, 240);
            fullScreen = new Rectangle(0, 0, 640, 480);

            // initialize controllers
            keyboardController = new KeyboardController();
            mouseController = new MouseController();

            // initialize commands
            quitGameCommand = new QuitGameCommand(this);
            setFixedSpriteCommand = new SetFixedSpriteCommand(this);
            setAnimatedSpriteCommand = new SetAnimatedSpriteCommand(this);
            setFixedMovingSpriteCommand = new SetFixedMovingSpriteCommand(this);
            setAnimatedMovingSpriteCommand = new SetAnimatedMovingSpriteCommand(this);

            // initialize keyboard
            keyboardController.addCommand(Keys.D0, quitGameCommand);
            keyboardController.addCommand(Keys.D1, setFixedSpriteCommand);
            keyboardController.addCommand(Keys.D2, setAnimatedSpriteCommand);
            keyboardController.addCommand(Keys.D3, setFixedMovingSpriteCommand);
            keyboardController.addCommand(Keys.D4, setAnimatedMovingSpriteCommand);

            // initialize mouse
            mouseController.addCommand(fullScreen, 2, quitGameCommand);
            mouseController.addCommand(upperLeftQuad, 1, setFixedSpriteCommand);
            mouseController.addCommand(upperRightQuad, 1, setAnimatedSpriteCommand);
            mouseController.addCommand(lowerLeftQuad, 1, setFixedMovingSpriteCommand);
            mouseController.addCommand(lowerRightQuad, 1, setAnimatedMovingSpriteCommand);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // load content
            marioTexture = Content.Load<Texture2D>("mario");
            _font = Content.Load<SpriteFont>("myfont");

            // load mario sprite
            animatedSprite = new AnimatedSprite(marioTexture, new Vector2(228, 52), new Vector2(328, 87), 3, 10);
            oneFrameSprite = new OneFrameSprite(marioTexture);
            movingOneFrameSprite = new MovingOneFrameSprite(marioTexture, marioPosition);
            movingAnimatedSprite = new MovingAnimatedSprite(marioTexture, new Vector2(228, 52), new Vector2(328, 87), marioPosition, 3, 10);
            
            // load text sprite
            creditSprite = new TextSprite(_font, "Credits");
            nameSprite = new TextSprite(_font, "Program made by: Helen Wang");
            urlSprite = new TextSprite(_font, "Sprites from: https://osu.instructure.com/courses/168410/files/folder/Mario%20spritesheets%20in%20different%");
            urlSprite2 = new TextSprite(_font, "20formats?");

        }

        protected override void Update(GameTime gameTime)
        {
            animatedSprite.Update();
            // oneFrameSprite.Update(); 
            movingOneFrameSprite.Update();
            movingAnimatedSprite.Update();
            // creditSprite.Update(); nameSprite.Update(); urlSprite.Update(); urlSprite2.Update(); 
            keyboardController.Update();
            mouseController.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentSprite)
            {
                case 1:
                    oneFrameSprite.Draw(_spriteBatch, new Vector2(marioTexture.Width / 2 + 400, marioTexture.Height / 2 + 200));
                    break;
                case 2:
                    animatedSprite.Draw(_spriteBatch, new Vector2(marioTexture.Width / 2 + 200, marioTexture.Height / 2 + 100));
                    break;
                case 3:
                    movingOneFrameSprite.Draw(_spriteBatch, new Vector2(marioTexture.Width / 2 + 200, marioTexture.Height / 2 + 100));
                    break;
                case 4:
                    movingAnimatedSprite.Draw(_spriteBatch, new Vector2(marioTexture.Width / 2 + 200, marioTexture.Height / 2 + 100));
                    break;
                default:
                    break;
            }
            
            creditSprite.Draw(_spriteBatch, new Vector2(20, 300));
            nameSprite.Draw(_spriteBatch, new Vector2(20, 330));
            urlSprite.Draw(_spriteBatch, new Vector2(20, 360));
            urlSprite2.Draw(_spriteBatch, new Vector2(105, 390));

            base.Draw(gameTime);
        }
    }
}
