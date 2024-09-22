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

    public ISprite IdleRightMario;
    public ISprite IdleLeftMario;
    public ISprite WalkingLeftMario;
    public ISprite WalkingRightMario;

    public ICommand IdleRightCommand;
    public ICommand IdleLeftCommand;
    public ICommand WalkRightCommand;
    public ICommand WalkLeftCommand;

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
        IdleRightCommand = new IdleRightCommand(this);
        IdleLeftCommand = new IdleLeftCommand(this);
        WalkRightCommand = new WalkRightCommand(this);
        WalkLeftCommand = new WalkLeftCommand(this);

        CurrentMarioSprite = IdleRightMario;
        keyboardController.addCommand(Keys.A, WalkRightCommand);
        keyboardController.addCommand(Keys.D, WalkLeftCommand);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        MarioTexture = Content.Load<Texture2D>("mario");
        IdleRightMario = new IdleRightMario(MarioTexture);
        IdleLeftMario = new IdleLeftMario(MarioTexture);
        WalkingRightMario = new WalkingRightMario(MarioTexture);
        WalkingLeftMario = new WalkingLeftMario(MarioTexture);

        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        CurrentMarioSprite.Draw(_spriteBatch, new Vector2(200, 200));
        base.Draw(gameTime);
    }
}
