using System;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    public IdleRightMario idleRightMario { get; set; }
    public IdleLeftMario idleLeftMario { get; set; }
    public WalkingRightMario walkingRightMario { get; set; }
    public WalkingLeftMario walkingLeftMario { get; set; }


    public ISprite CurrentMarioSprite { get; set; }
    public ICommand CurrentCommand { get; internal set; }
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        CurrentMarioSprite.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        base.Draw(gameTime);
    }
}
