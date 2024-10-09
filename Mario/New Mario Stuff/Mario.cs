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

    private Vector2 marioPosition;
    private Vector2 marioVelocity;
    private float groundPosition = 200f;
    private float gravity = 980f;
    private float jumpSpeed = -350f;
    private bool isOnGround = true;

    private Vector2 initialPosition;

    public Mario(Texture2D marioTexture, GameTime gameTime)
    {
        this.marioTexture = marioTexture;
        initialPosition = new Vector2(400, groundPosition); // Set the initial position
        marioPosition = initialPosition;
        marioStateMachine = new MarioStateMachine();
        this.gameTime = gameTime;

        UpdateCurrentSprite();
    }

    public void MoveRight()
    {
        if (!marioStateMachine.IsCrouching())
        {
            marioPosition.X += 3;
            marioStateMachine.SetFaceState(MarioStateMachine.MarioFaceState.Right);

            if (!marioStateMachine.IsJumping())
            {
                marioStateMachine.SetMoveState(MarioStateMachine.MarioMoveState.Moving);
            }

            UpdateCurrentSprite();
        }
    }

    public void MoveLeft()
    {
        if (!marioStateMachine.IsCrouching())
        {
            marioPosition.X -= 3;
            marioStateMachine.SetFaceState(MarioStateMachine.MarioFaceState.Left);

            if (!marioStateMachine.IsJumping())
            {
                marioStateMachine.SetMoveState(MarioStateMachine.MarioMoveState.Moving);
            }

            UpdateCurrentSprite();
        }
    }

    public void Jump()
    {
        if (isOnGround && !marioStateMachine.IsCrouching())
        {
            marioVelocity.Y = jumpSpeed;
            marioStateMachine.SetMoveState(MarioStateMachine.MarioMoveState.Jumping);
            isOnGround = false;
            UpdateCurrentSprite();
        }
    }

    public void Crouch()
    {
        marioStateMachine.SetMoveState(MarioStateMachine.MarioMoveState.Crouching);
        UpdateCurrentSprite();
    }

    public void StandUp()
    {
        if (!marioStateMachine.IsJumping())
        {
            marioStateMachine.SetMoveState(MarioStateMachine.MarioMoveState.Idle);
            UpdateCurrentSprite();
        }
    }

    private void ApplyGravity(GameTime gameTime)
    {
        if (marioStateMachine.IsJumping())
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

    private void UpdateCurrentSprite()
    {
        currentMarioSprite = MarioSpriteConstructor.ConstructMarioSprite(marioStateMachine, marioTexture);
    }

    public void Update(GameTime gameTime)
    {
        ApplyGravity(gameTime);
        currentMarioSprite.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, marioPosition);
    }

    // Reset Mario to its initial state
    public void Reset()
    {
        marioPosition = initialPosition;  // Reset Mario's position
        marioVelocity = Vector2.Zero;     // Reset velocity
        marioStateMachine.Reset();        // Reset Mario's state machine to the default state
        isOnGround = true;                // Set Mario as standing on the ground
        UpdateCurrentSprite();            // Update the sprite to reflect the reset state
    }
}
