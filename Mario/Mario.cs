using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class Mario : IEntity
{
    private Texture2D marioTexture;
    private IMarioSprite currentMarioSprite;
    private MarioStateMachine marioStateMachine;
    public GameTime gameTime;

    private Vector2 initialPosition;
    public Vector2 marioPosition;
    public Vector2 marioVelocity;
    private float groundPosition = 385f;
    private float gravity = 980f;
    private float jumpSpeed = -500f;

    public bool isOnGround = true;
    private bool canPowerUp = true;
    private bool canTakeDamage = true;

    private const float maxSpeed = 3f;
    private const float acceleration = 0.03f;

    private int fireballTimer;
    private int starTimer;

    //Need Game1 reference to correctly create fireballs
    private Game1 game;
    private List<IEntity> _entities;

    public Mario(Texture2D marioTexture, GameTime gametime, Game1 game, List<IEntity> entities)
    {
        this.marioTexture = marioTexture;
        marioPosition = new Vector2(200, groundPosition);
        initialPosition = new Vector2(200, groundPosition);
        marioStateMachine = new MarioStateMachine();
        this.gameTime = gametime;
        marioPosition = initialPosition;
        fireballTimer = 0;
        starTimer = 0;

        currentMarioSprite = new IdleRightSmallMario(marioTexture);
        this.game = game;
        this._entities = entities;
    }

    public void MoveRight()
    {
        if (!marioStateMachine.IsRight())
        {
            SwapDirection();
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X < maxSpeed)
            {
                marioVelocity.X += acceleration;
            }

            marioPosition.X += marioVelocity.X;

            if (!marioStateMachine.IsJumping())
            {
                marioStateMachine.SetMarioRight();
                marioStateMachine.SetMarioMoving();
            }
        }
    }

    public void MoveLeft()
    {
        if (marioStateMachine.IsRight())
        {
            SwapDirection();
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X > -maxSpeed)
            {
                marioVelocity.X -= acceleration;
            }

            marioPosition.X += marioVelocity.X;

            if (!marioStateMachine.IsJumping())
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

    public void ApplyGravity(GameTime gameTime)
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
        if (marioStateMachine.IsMoving())
        {
            marioStateMachine.SetMarioTurning();
            marioVelocity.X = 0f;
        }
    }

    public void Stop()
    {
        marioVelocity.X = 0f;
        if (isOnGround)
        {
            marioStateMachine.SetMarioIdle();
        }
    }

    public void ShootFireball()
    {
        if (fireballTimer > 0)
        {
            return;
        }
        if (marioStateMachine.IsFire())
        {
            Fireball f = new Fireball(marioPosition, game.ItemsTexture, gameTime, marioStateMachine.CurrentFaceState, game, _entities);
            game.fireballs.Add(f);
            fireballTimer = 20;
        }
    }

    public void Update(GameTime gameTime)
    {
        ApplyGravity(gameTime);
        marioPosition.X += marioVelocity.X;
        currentMarioSprite = MarioSpriteMachine.UpdateMarioSprite(marioStateMachine, marioTexture);
        currentMarioSprite.Update(gameTime);
        fireballTimer += -1;
        starTimer += -1;
        this.RemoveStar();
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

    public MarioStateMachine.MarioGameState GetMarioGameState()
    {
        return marioStateMachine.CurrentGameState;
    }

    public bool HasStar()
    {
        return marioStateMachine.HasStar();
    }

    public void CollectStar()
    {
        starTimer = 300;
        marioStateMachine.SetStar();
    }

    public void RemoveStar()
    {
        if (this.HasStar() && starTimer <= 0)
        {
            marioStateMachine.RemoveStar();
        }
    }

}