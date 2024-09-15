using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimatedSprite animatedSprite;
        private Controller controller = new Controller();
        Texture2D stillTexture;
        SpriteFont font;
        float speed;
        float updatedSpeed;
        float xPos, yPos;
        private int lastButton = -1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            lastButton = -1;
            speed = 100f;
            xPos = 400;
            yPos = 200;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D texture = Content.Load<Texture2D>("walkingForwardCafeGirl");
            stillTexture = Content.Load<Texture2D>("cafeGirlStanding");
            animatedSprite = new AnimatedSprite(texture, 1, 3);
             font = Content.Load<SpriteFont>("File");
            //font = Content.Load<SpriteFont>("myFont");

        }

        protected override void Update(GameTime gameTime)
        {
            // controller = new Controller();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            animatedSprite.Update();
            controller.UpdateCue();
            updatedSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (controller.Cue == 0)
            {
                Exit();
            }
            if (controller.Cue == 1)
            {
                lastButton = 1;
            }
            if (controller.Cue == 2)
            {
                lastButton = 2;
            }
            if (controller.Cue == 3)
            {
                lastButton = 3;
            }
            if (controller.Cue == 4)
            {
                lastButton = 4;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);
             _spriteBatch.Begin();
            Vector2 textMidPoint = font.MeasureString("Name: Sanaa Kamau");
            Vector2 position = new Vector2(400, 320);
            _spriteBatch.DrawString(font, "Credits:  ", position, Color.Black, 0, textMidPoint, 2.0f, SpriteEffects.None, 0.5f);
            _spriteBatch.DrawString(font, "Program Made By: Sanaa Kamau ", new Vector2(400,360), Color.Black, 0, textMidPoint, 2.0f, SpriteEffects.None, 0.5f);
            _spriteBatch.DrawString(font, "Sprites From: Sanaa Kamau ", new Vector2(400, 400), Color.Black, 0, textMidPoint, 2.0f, SpriteEffects.None, 0.5f);
            _spriteBatch.End();

            // TODO: Add your drawing code here
            int lastButton = controller.Cue;
            if (controller.Cue == 1)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(stillTexture, new Vector2(400, 200), Color.White);
                _spriteBatch.End();
            }
            if (controller.Cue == 2)
            {
                animatedSprite.Draw(_spriteBatch, new Vector2(400, 200));
            }
            if (controller.Cue == 3 || lastButton == 3)
            {
                xPos = 400;
                animatedSprite.Draw(_spriteBatch, new Vector2(xPos, yPos));


                yPos -= updatedSpeed;
            }
            if (controller.Cue == 4)
            {
                yPos = 200;
                animatedSprite.Draw(_spriteBatch, new Vector2(xPos, yPos));
                xPos -= updatedSpeed;
            }
            base.Draw(gameTime);
        }
    }
}
