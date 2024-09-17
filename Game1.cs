using System;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    public enum GameStates{MainMenu, PlayerAlive, FaceLeft, FaceRight, IsJumping, GameOver};
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameState MyGameState;

    private KeyboardController keyboardController;


    Texture2D MarioCharacterTexture;
    Vector2 MarioCharacterPosition;

    private ISprite MarioWalkingLeftRightAnimation;
    private ISprite MarioCrouchingAnimation;
    private ISprite MarioTurningAnimation;
    private ISprite MarioJumpingAnimation;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        keyboardController = new KeyboardController();
        MyGameState = new GameState();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {

        keyboardController.update();

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        base.Draw(gameTime);
    }
}
