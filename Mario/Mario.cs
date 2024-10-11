using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class Mario
{
    private Texture2D marioTexture;
    private IMarioSprite currentMarioSprite;
    private MarioStateMachine marioStateMachine;
    private GameTime gameTime;

    private Vector2 initialPosition;
    private Vector2 marioPosition;
    private Vector2 marioVelocity;
    private float groundPosition = 200f;
    private float gravity = 980f;
    private float jumpSpeed = -350f;
    private bool isOnGround = true;

    private const float maxSpeed = 3f;
    private const float acceleration = 0.03f;


    public Mario(Texture2D marioTexture, GameTime gametime)
    {
        this.marioTexture = marioTexture;
        marioPosition = new Vector2(400, groundPosition);
        initialPosition = new Vector2(400, groundPosition);
        marioStateMachine = new MarioStateMachine();
        this.gameTime = gametime;
        marioPosition = initialPosition;

        UpdateCurrentSprite();
    }

    public void MoveRight()
    {
        if (marioStateMachine.CurrentFaceState == MarioStateMachine.MarioFaceState.Left)
        {
            SwapDirection();
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X < maxSpeed)
            {
                marioVelocity.X += acceleration;
                if (marioVelocity.X > maxSpeed)
                {
                    marioVelocity.X = maxSpeed;
                }
            }

            marioPosition.X += marioVelocity.X;

            if (marioStateMachine.CurrentMoveState != MarioStateMachine.MarioMoveState.Jumping)
            {
                marioStateMachine.SetMarioRight();
                marioStateMachine.SetMarioMoving();

                if (!(currentMarioSprite is MovingRightBigMario))
                {
                    currentMarioSprite = new MovingRightBigMario(marioTexture);
                }
            }
            currentMarioSprite.Update(gameTime);
        }
    }

    public void MoveLeft()
    {
        if (marioStateMachine.CurrentFaceState == MarioStateMachine.MarioFaceState.Right)
        {
            SwapDirection();
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X > -maxSpeed)
            {
                marioVelocity.X -= acceleration;
                if (marioVelocity.X < -maxSpeed)
                {
                    marioVelocity.X = -maxSpeed;
                }
            }

            marioPosition.X += marioVelocity.X;

            if (marioStateMachine.CurrentMoveState != MarioStateMachine.MarioMoveState.Jumping)
            {
                marioStateMachine.SetMarioLeft();
                marioStateMachine.SetMarioMoving();

                if (!(currentMarioSprite is MovingLeftBigMario))
                {
                    currentMarioSprite = new MovingLeftBigMario(marioTexture);
                }
            }
            currentMarioSprite.Update(gameTime);
        }
    }

    public void Jump()
    {
        if (isOnGround && !marioStateMachine.IsCrouching())
        {
            marioVelocity.Y = jumpSpeed;
            marioStateMachine.SetMarioJumping();
            isOnGround = false;
            UpdateCurrentSprite();
        }
    }

    public void Crouch()
    {
        if (!marioStateMachine.IsJumping())
        {
            marioStateMachine.SetMarioCrouching();
            UpdateCurrentSprite();
        }
    }

    private void ApplyGravity(GameTime gameTime)
    {
        if (!isOnGround)
        {
            marioVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            marioPosition.Y += marioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (marioPosition.Y >= groundPosition)
            {
                marioPosition.Y = groundPosition;
                marioVelocity.Y = 0;
                isOnGround = true;
                marioStateMachine.UpdateMoveStateForJumping();

                UpdateCurrentSprite();
            }
        }
    }

    public void MarioPowerUp()
    {
        switch (marioStateMachine.CurrentGameState)
        {
            case MarioStateMachine.MarioGameState.Small:
                marioStateMachine.SetMarioBig();
                UpdateCurrentSprite();
                break;

            case MarioStateMachine.MarioGameState.Big:
                marioStateMachine.SetMarioFire();
                UpdateCurrentSprite();
                break;

            case MarioStateMachine.MarioGameState.Fire:
                // Mario is already in Fire state, maybe reset timer
                break;
        }
    }

    public void MarioTakeDamage()
    {
        switch (marioStateMachine.CurrentGameState)
        {
            case MarioStateMachine.MarioGameState.Fire:
                marioStateMachine.SetMarioBig();
                UpdateCurrentSprite();
                break;

            case MarioStateMachine.MarioGameState.Big:
                marioStateMachine.SetMarioSmall();
                UpdateCurrentSprite();
                break;

            case MarioStateMachine.MarioGameState.Small:
                // Mario is dead, maybe add some gameover functions
                break;
        }
    }

    public void SwapDirection()
    {
        if (marioStateMachine.CurrentMoveState == MarioStateMachine.MarioMoveState.Moving)
        {
            marioStateMachine.SetMarioTurning();
            marioVelocity.X = 0f;
        }
        UpdateCurrentSprite();
    }

    public void Stop()
    {
        marioVelocity.X = 0f;
        marioStateMachine.SetMarioIdle();
        UpdateCurrentSprite();
    }

    public void Update(GameTime gameTime)
    {
        ApplyGravity(gameTime);
        marioPosition.X += marioVelocity.X;
        currentMarioSprite.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, marioPosition);
    }

    private void UpdateCurrentSprite()
    {
        currentMarioSprite = MarioSpriteMachine.UpdateMarioSprite(marioStateMachine, marioTexture);

    }
    public void Reset()
    {
        marioPosition = initialPosition;  // Reset Mario's position
        marioVelocity = Vector2.Zero;     // Reset velocity
        marioStateMachine.Reset();        // Reset Mario's state machine to the default state
        isOnGround = true;                // Set Mario as standing on the ground
        UpdateCurrentSprite();            // Update the sprite to reflect the reset state
    }
}
