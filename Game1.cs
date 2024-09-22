using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D MarioTexture;

    private KeyboardController keyboardController;

    public ISprite idleRightMario;
    public ISprite idleLeftMario;
    public ISprite walkingLeftMario;
    public ISprite walkingRightMario;

    public ICommand idleRightCommand;
    public ICommand idleLeftCommand;
    public ICommand walkRightCommand;
    public ICommand walkLeftCommand;

    public ISprite CurrentMarioSprite;
    public bool FacingRight = true;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        keyboardController = new KeyboardController(this);
        idleRightCommand = new IdleRightCommand(this);
        idleLeftCommand = new IdleLeftCommand(this);
        walkRightCommand = new WalkRightCommand(this);
        walkLeftCommand = new WalkLeftCommand(this);

        CurrentMarioSprite = idleRightMario;

        keyboardController.addCommand(Keys.A, walkRightCommand);
        keyboardController.addCommand(Keys.D, walkLeftCommand);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        MarioTexture = Content.Load<Texture2D>("mario");
        idleRightMario = new IdleRightMario(MarioTexture);
        idleLeftMario = new IdleLeftMario(MarioTexture);
        walkingRightMario = new WalkingRightMario(MarioTexture);
        walkingLeftMario = new WalkingLeftMario(MarioTexture);
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();

        idleRightMario.Draw(_spriteBatch, new Vector2(200, 200));

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
