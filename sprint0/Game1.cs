using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        List<IController> ControllerList;
        ISprite CharacterSprite;
        ISprite TextSprite;

        SpriteFont Font;
        Texture2D Texture;

        

        protected override void Initialize()
        {
            ControllerList = new List<IController>();
            ControllerList.Add(new KeyboardController());
            ControllerList.Add(new MouseController());
            TextSprite = new SpriteTextController();

            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            CharacterSprite = new SpriteNonMovingNonAnimatedController();
            TextSprite = new SpriteTextController();
            Font = Content.Load<SpriteFont>("NameCredits");
            Texture = Content.Load<Texture2D>("KirbysAdventureSheet1");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if ((Mouse.GetState().RightButton == ButtonState.Pressed) || Keyboard.GetState().IsKeyDown(Keys.D0))
                Exit();

            foreach (IController controller in ControllerList) {
                controller.HandleInputs(ref CharacterSprite);
            }

            CharacterSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            CharacterSprite.Draw(_spriteBatch, Texture);
            TextSprite.Draw(_spriteBatch, Font);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public class KeyboardController : IController
        {

            KeyboardState KeysPressed;
            private KeyboardState PrevKeysPressed;
            public void HandleInputs(ref ISprite CharacterSprite)
            {
                KeysPressed = Keyboard.GetState();

                if ((KeysPressed.IsKeyDown(Keys.D1)) && !(PrevKeysPressed.IsKeyDown(Keys.D1)))
                {
                    CharacterSprite = new SpriteNonMovingNonAnimatedController();
                }
                else if ((KeysPressed.IsKeyDown(Keys.D2)) && !(PrevKeysPressed.IsKeyDown(Keys.D2)))
                {
                    CharacterSprite = new SpriteNonMovingAnimatedController();
                }
                else if ((KeysPressed.IsKeyDown(Keys.D3)) && !(PrevKeysPressed.IsKeyDown(Keys.D3)))
                {
                    CharacterSprite = new SpriteMovingNonAnimatedController();
                }
                else if ((KeysPressed.IsKeyDown(Keys.D4)) && !(PrevKeysPressed.IsKeyDown(Keys.D4)))
                {
                    CharacterSprite = new SpriteMovingAnimatedController();
                }

                PrevKeysPressed = KeysPressed;

            }
        }
        public class MouseController : IController
        {
            MouseState MouseStatus;
            private MouseState PrevMouseStatus;
            int MouseX;
            int MouseY;
            public void HandleInputs(ref ISprite CharacterSprite)
            {
                MouseStatus = Mouse.GetState();
                MouseX = MouseStatus.X;
                MouseY = MouseStatus.Y;

                if ((MouseStatus.LeftButton == ButtonState.Pressed) && (PrevMouseStatus.LeftButton != ButtonState.Pressed))
                {
                    //Google says default window size is 800x400
                    if ((MouseX <= 400) && (MouseY <= 200))
                    {
                        CharacterSprite = new SpriteNonMovingNonAnimatedController();
                    }
                    else if ((MouseX > 400) && (MouseY <= 200))
                    {
                        CharacterSprite = new SpriteNonMovingAnimatedController();
                    }
                    else if ((MouseX <= 400) && (MouseY > 200))
                    {
                        CharacterSprite = new SpriteMovingNonAnimatedController();
                    }
                    else if ((MouseX > 400) && (MouseY > 200))
                    {
                        CharacterSprite = new SpriteMovingAnimatedController();
                    }
                }

                PrevMouseStatus = MouseStatus;
            }
        }
        public class SpriteNonMovingNonAnimatedController : ISprite
        {

            Rectangle SourceRectangle;
            Rectangle DestinationRectangle;
            public void Update()
            {

            }
            public void Draw(SpriteBatch sb, Texture2D texture)
            {
                DestinationRectangle = new Rectangle(350, 150, 100, 100);
                SourceRectangle = new Rectangle(56, 18, 18, 18);
                sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
            }
            public void Draw(SpriteBatch sb, SpriteFont font)
            {

            }
        }

        public class SpriteNonMovingAnimatedController : ISprite
        {
            Rectangle SourceRectangle;
            Rectangle DestinationRectangle;

            int CurrFrame = 0;
            public void Update()
            {
                CurrFrame += 1;
            }
            public void Draw(SpriteBatch sb, Texture2D texture)
            {
                DestinationRectangle = new Rectangle(350, 150, 100, 100);
                int DrawFrame = (CurrFrame / 10) % 5;
                switch (DrawFrame)
                {
                    case 0:
                        SourceRectangle = new Rectangle(21, 36, 18, 18);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 1:
                        SourceRectangle = new Rectangle(56, 36, 18, 18);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 2:
                        SourceRectangle = new Rectangle(3, 36, 18, 18);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 3:
                        SourceRectangle = new Rectangle(38, 36, 18, 18);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 4:
                        SourceRectangle = new Rectangle(38, 18, 18, 18);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                }
                
            }
            public void Draw(SpriteBatch sb, SpriteFont font)
            {

            }
        }
        public class SpriteMovingNonAnimatedController : ISprite
        {
            Rectangle SourceRectangle;
            Rectangle DestinationRectangle;

            int CurrFrame = 0;
            public void Update()
            {
                CurrFrame += 1;
            }
            public void Draw(SpriteBatch sb, Texture2D texture)
            {
                SourceRectangle = new Rectangle(49, 95, 73 - 49, 119 - 95);
                int DrawFrame = (CurrFrame / 12) % 6;
                switch (DrawFrame)
                {
                    case 0:
                        DestinationRectangle = new Rectangle(350, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 1:
                        DestinationRectangle = new Rectangle(350, 130, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 2:
                        DestinationRectangle = new Rectangle(350, 110, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 3:
                        DestinationRectangle = new Rectangle(350, 90, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 4:
                        DestinationRectangle = new Rectangle(350, 110, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 5:
                        DestinationRectangle = new Rectangle(350, 130, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                }
            }
            public void Draw(SpriteBatch sb, SpriteFont font)
            {
                
            }
        }
        public class SpriteMovingAnimatedController : ISprite
        {
            Rectangle SourceRectangle;
            Rectangle DestinationRectangle;

            int CurrFrame = 0;
            public void Update()
            {
                CurrFrame += 1;
            }
            public void Draw(SpriteBatch sb, Texture2D texture)
            {
                int DrawFrame = (CurrFrame / 12) % 24;
                switch (DrawFrame)
                {
                    case 0:
                        SourceRectangle = new Rectangle(74, 0, 91 - 74, 17);
                        DestinationRectangle = new Rectangle(350, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 1:
                        SourceRectangle = new Rectangle(92, 0, 108 - 92, 17);
                        DestinationRectangle = new Rectangle(375, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 2:
                        SourceRectangle = new Rectangle(109, 0, 126 - 109, 17);
                        DestinationRectangle = new Rectangle(400, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 3:
                        SourceRectangle = new Rectangle(92, 0, 108 - 92, 17);
                        DestinationRectangle = new Rectangle(425, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 4:
                        SourceRectangle = new Rectangle(74, 0, 91 - 74, 17);
                        DestinationRectangle = new Rectangle(450, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 5:
                        SourceRectangle = new Rectangle(92, 0, 108 - 92, 17);
                        DestinationRectangle = new Rectangle(475, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 6:
                        SourceRectangle = new Rectangle(109, 0, 126 - 109, 17);
                        DestinationRectangle = new Rectangle(500, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 7:
                        SourceRectangle = new Rectangle(92, 0, 108 - 92, 17);
                        DestinationRectangle = new Rectangle(525, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 8:
                        SourceRectangle = new Rectangle(74, 0, 91 - 74, 17);
                        DestinationRectangle = new Rectangle(550, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 9:
                        SourceRectangle = new Rectangle(92, 0, 108 - 92, 17);
                        DestinationRectangle = new Rectangle(575, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 10:
                        SourceRectangle = new Rectangle(109, 0, 126 - 109, 17);
                        DestinationRectangle = new Rectangle(600, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 11:
                        SourceRectangle = new Rectangle(92, 0, 108 - 92, 17);
                        DestinationRectangle = new Rectangle(625, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 12:
                        SourceRectangle = new Rectangle(56, 0, 73 - 56, 17);
                        DestinationRectangle = new Rectangle(625, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 13:
                        SourceRectangle = new Rectangle(39, 0, 55 - 39, 17);
                        DestinationRectangle = new Rectangle(600, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 14:
                        SourceRectangle = new Rectangle(21, 0, 38 - 21, 17);
                        DestinationRectangle = new Rectangle(575, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 15:
                        SourceRectangle = new Rectangle(39, 0, 55 - 39, 17);
                        DestinationRectangle = new Rectangle(550, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 16:
                        SourceRectangle = new Rectangle(56, 0, 73 - 56, 17);
                        DestinationRectangle = new Rectangle(525, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 17:
                        SourceRectangle = new Rectangle(39, 0, 55 - 39, 17);
                        DestinationRectangle = new Rectangle(500, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 18:
                        SourceRectangle = new Rectangle(21, 0, 38 - 21, 17);
                        DestinationRectangle = new Rectangle(475, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 19:
                        SourceRectangle = new Rectangle(39, 0, 55 - 39, 17);
                        DestinationRectangle = new Rectangle(450, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 20:
                        SourceRectangle = new Rectangle(56, 0, 73 - 56, 17);
                        DestinationRectangle = new Rectangle(425, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 21:
                        SourceRectangle = new Rectangle(39, 0, 55 - 39, 17);
                        DestinationRectangle = new Rectangle(400, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 22:
                        SourceRectangle = new Rectangle(21, 0, 38 - 21, 17);
                        DestinationRectangle = new Rectangle(375, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                    case 23:
                        SourceRectangle = new Rectangle(39, 0, 55 - 39, 17);
                        DestinationRectangle = new Rectangle(350, 150, 100, 100);
                        sb.Draw(texture, DestinationRectangle, SourceRectangle, Color.White);
                        break;
                }
            }
            public void Draw(SpriteBatch sb, SpriteFont font)
            {

            }
        }

        public class SpriteTextController : ISprite
        {

            public void Update()
            {

            }

            public void Draw(SpriteBatch sb, Texture2D texture)
            {

            }
            public void Draw(SpriteBatch sb, SpriteFont font)
            {

                sb.DrawString(font, "Credits\nProgram made by Michael Francek\nSprites from https://retrogamezone.co.uk/kirbysadventure.htm", new Vector2(250, 400), Color.Black);
                
            }
        }
    }

    
}
