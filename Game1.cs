﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    public Texture2D MarioTexture;
    public Vector2 MarioPosition;
    public float MarioSpeed;
    public Vector2 MarioVelocity;
    public float Gravity = 9.8f;
    public float JumpSpeed = -350f;
    public float GroundPosition;
    public float updatedMarioSpeed;

    public ISprite IdleRightMario;
    public ISprite IdleLeftMario;
    public ISprite MovingRightMarioAnimation;
    public ISprite MovingLeftMarioAnimation;
    public ISprite JumpingRightMario;
    public ISprite JumpingLeftMario;

    public ICommand SetMovingRightMarioCommand;
    public ICommand SetMovingLeftMarioCommand;
    public ICommand SetJumpingUpMarioCommand;

    public ISprite CurrentMarioSprite;

    public Boolean FacingRight = true;
    public Boolean MovingRight = false;
    public Boolean MovingLeft = false;
    public Boolean IsJumping = false;

    private KeyboardController keyboardController;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        GroundPosition = graphics.PreferredBackBufferHeight / 2;
        MarioVelocity = Vector2.Zero;

        SetJumpingUpMarioCommand = new SetJumpUp(this);
        SetMovingRightMarioCommand = new SetMoveRightCommand(this);
        SetMovingLeftMarioCommand = new SetMoveLeftCommand(this);

        keyboardController = new KeyboardController();
        keyboardController.addCommand(Keys.Right, SetMovingRightMarioCommand);
        keyboardController.addCommand(Keys.Left, SetMovingLeftMarioCommand);
        keyboardController.addCommand(Keys.Up, SetJumpingUpMarioCommand);

        CurrentMarioSprite = IdleRightMario;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        MarioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        MarioSpeed = 150f;

        MarioTexture = Content.Load<Texture2D>("mario");
        IdleRightMario = new IdleRightMario(MarioTexture);
        IdleLeftMario = new IdleLeftMario(MarioTexture);
        JumpingRightMario = new JumpingRightMario(MarioTexture);
        JumpingLeftMario = new JumpingLeftMario(MarioTexture);

        MovingRightMarioAnimation = new MovingRightMario(MarioTexture);
        MovingRightMarioAnimation.Load(graphics);

        MovingLeftMarioAnimation = new MovingLeftMario(MarioTexture);
        MovingLeftMarioAnimation.Load(graphics);
    }

    protected override void Update(GameTime gameTime)
    {
        if (!IsJumping && FacingRight)
        {
            CurrentMarioSprite = IdleRightMario;
        }
        else if (!IsJumping && !FacingRight)
        {
            CurrentMarioSprite = IdleLeftMario;
        }

        keyboardController.Update(gameTime);
        updatedMarioSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        MarioVelocity.Y += Gravity;
        MarioPosition.Y += MarioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (MarioPosition.Y >= GroundPosition)
        {
            MarioPosition.Y = GroundPosition;
            MarioVelocity.Y = 0;
            IsJumping = false;
        }
        CurrentMarioSprite.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        CurrentMarioSprite.Draw(spriteBatch, MarioPosition);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}
