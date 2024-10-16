using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class Mario : IEntity
{
    private Texture2D marioTexture;
    private IMarioSprite currentMarioSprite;
    private MarioStateMachine marioStateMachine;
    private GameTime gameTime;

    private Vector2 initialPosition;
    private Vector2 marioPosition;
    public Vector2 marioVelocity;
    private float groundPosition = 200f;
    private float gravity = 980f;
    private float jumpSpeed = -350f;
    private bool isOnGround = true;

    private bool canPowerUp = true;
    private bool canTakeDamage = true;

    private const float maxSpeed = 3f;
    private const float acceleration = 0.03f;

    private int fireballTimer;

    //Need Game1 reference to correctly create fireballs
    private Game1 game;

    public Mario(Texture2D marioTexture, GameTime gametime, Game1 game)
    {
        this.marioTexture = marioTexture;
        marioPosition = new Vector2(400, groundPosition);
        initialPosition = new Vector2(400, groundPosition);
        marioStateMachine = new MarioStateMachine();
        this.gameTime = gametime;
        marioPosition = initialPosition;
        fireballTimer = 0;

        currentMarioSprite = new IdleRightSmallMario(marioTexture);
        this.game = game;
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
            }
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
            }
        }
    }

    public void Jump()
    {
        if (isOnGround && !marioStateMachine.IsCrouching())
        {
            marioVelocity.Y = jumpSpeed;
            marioStateMachine.SetMarioJumping();
            isOnGround = false;
        }
    }

    public void Crouch()
    {
        if (!marioStateMachine.IsJumping())
        {
            marioStateMachine.SetMarioCrouching();
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
            }
        }
    }

    public void MarioPowerUp()
    {
        if (!canPowerUp) return; // Prevent power-ups if not allowed
        switch (marioStateMachine.CurrentGameState)
        {
            case MarioStateMachine.MarioGameState.Small:
                marioStateMachine.SetMarioBig();
                break;

            case MarioStateMachine.MarioGameState.Big:
                marioStateMachine.SetMarioFire();
                break;

            case MarioStateMachine.MarioGameState.Fire:
                break;
        }
        canPowerUp = false;
        Task.Delay(1000).ContinueWith(t => canPowerUp = true); // Reset after 1 second
    }

    public void MarioTakeDamage()
    {
        if (!canTakeDamage) return;
        switch (marioStateMachine.CurrentGameState)
        {
            case MarioStateMachine.MarioGameState.Fire:
                marioStateMachine.SetMarioBig();
                break;

            case MarioStateMachine.MarioGameState.Big:
                marioStateMachine.SetMarioSmall();
                break;

            case MarioStateMachine.MarioGameState.Small:
                Console.WriteLine("Died");
                break;
        }
        canTakeDamage = false;
        Task.Delay(1000).ContinueWith(t => canTakeDamage = true); // Reset after 1 second
    }

    public void SwapDirection()
    {
        if (marioStateMachine.CurrentMoveState == MarioStateMachine.MarioMoveState.Moving)
        {
            marioStateMachine.SetMarioTurning();
            marioVelocity.X = 0f;
        }
    }

    public void Stop()
    {
        marioVelocity.X = 0f;
        marioStateMachine.SetMarioIdle();
    }

    public void ShootFireball()
    {
        if (fireballTimer > 0)
        {
            return;
        }
        if (marioStateMachine.CurrentGameState == MarioStateMachine.MarioGameState.Fire)
        {
            Fireball f = new Fireball(marioPosition, game.ItemsTexture, gameTime, marioStateMachine.CurrentFaceState);
            game.fireballs.Add(f);
            fireballTimer = 30;
        }
    }

    public void Update(GameTime gameTime)
    {
        ApplyGravity(gameTime);
        marioPosition.X += marioVelocity.X;
        currentMarioSprite = MarioSpriteMachine.UpdateMarioSprite(marioStateMachine, marioTexture);
        currentMarioSprite.Update(gameTime);
        fireballTimer += -1;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, marioPosition);
    }

    public void Reset()
    {
        marioPosition = initialPosition;                                                    // Reset Mario's position
        marioVelocity = Vector2.Zero;                                                       // Reset velocity
        marioStateMachine.Reset();                                                          // Reset Mario's state machine to the default state
        isOnGround = true;                                                                  // Set Mario as standing on the ground
        currentMarioSprite = new IdleRightSmallMario(marioTexture);                         // Set mario to small idle right again
    }

    public Rectangle GetDestination()
    {
        return currentMarioSprite.GetDestination(marioPosition);
    }

    public Vector2 GetVelocity()
    {
        return marioVelocity;
    }

    public void SetVelocity(Vector2 newVelocity)
    {
        marioVelocity = newVelocity;
    }

    public MarioStateMachine.MarioGameState GetMarioGameState()
    {
        return marioStateMachine.CurrentGameState;
    }
    
}