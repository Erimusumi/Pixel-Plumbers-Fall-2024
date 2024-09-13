using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint0
{
    public class Game1 : Game
    {
        //Default variables
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Added variables
        private SpriteFont font;
        private Texture2D texture;
        private Texture2D koopa;
        IController controller;
        IController mouseController;
        private ISprite sprite;
        private ISprite animatedSprite;
        private Boolean animate;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controller = new keyboardController(this, this.texture, _spriteBatch);
            mouseController = new mouseController(this, this.texture, _spriteBatch);
            sprite = new firstPage();
            base.Initialize();
        }

        public void Refresh(ISprite sprite1)
        {
            // TODO: Add your initialization logic here
            sprite = sprite1;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("fontFile");
            texture = Content.Load<Texture2D>("mario");
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            controller.Update();
            mouseController.Update();
            sprite.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Program Made By: Hwanho Kim", new Vector2(250, 370), Color.White);
            _spriteBatch.DrawString(font, "Sprites from: Carmen file", new Vector2(280, 400), Color.White);
            
            sprite.Draw(_spriteBatch, texture);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
