using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    private bool moveKeyPressed = false;
    private bool deathSoundPlaying = false;

    private const float maxSpeed = 3f;
    private const float acceleration = 0.03f;

    private int fireballTimer;
    private int starTimer;
    int marioDeathBounceIncrement;
    private List<SoundEffect> _sfx;

    //Need Game1 reference to correctly create fireballs
    private Game1 game;
    private int gameResetTimer = -1;
    private List<IEntity> _entities;

    public Mario(Texture2D marioTexture, GameTime gametime, Game1 game, List<IEntity> entities, List<SoundEffect> sfx)
    {
        this.marioTexture = marioTexture;
        marioPosition = new Vector2(200, groundPosition);
        initialPosition = new Vector2(200, groundPosition);
        marioStateMachine = new MarioStateMachine();
        this.gameTime = gametime;
        marioPosition = initialPosition;
        fireballTimer = 0;
        starTimer = 0;
        marioDeathBounceIncrement = 15;

        currentMarioSprite = new IdleRightSmallMario(marioTexture);
        this.game = game;
        this._entities = entities;
        
        /*
         * SFX loaded in specific order:
         * 0: Power up
         * 1: Power down
         * 2: Fireball
         * 3: Jump
         * 4: Death
         */
        this._sfx = sfx;
    }

    public void MoveRight()
    {
        /*
         * Old implementation of MoveRight, keeping here in case needs to be reverted
         * 
        if (marioVelocity.X < 0f)
        {
            marioStateMachine.SetMarioTurning();
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X < maxSpeed)
            {
                marioVelocity.X += acceleration;
            }

            marioPosition.X += marioVelocity.X;

            if (!marioStateMachine.IsJumping() && !marioStateMachine.IsTurning())
            {
                marioStateMachine.SetMarioRight();
                marioStateMachine.SetMarioMoving();
            }
        }
        */
        if (marioStateMachine.IsDead()) return;

        moveKeyPressed = true;
        if (!marioStateMachine.IsJumping())
        {
            if (marioVelocity.X < 0f)
            {
                marioStateMachine.SetMarioTurning();
            }
            else if (!marioStateMachine.IsCrouching())
            {
                marioStateMachine.SetMarioRight();
                marioStateMachine.SetMarioMoving();
            }
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X < maxSpeed)
            {
                marioVelocity.X += acceleration;
            }
        }
    }

    public void MoveLeft()
    {
        if (marioStateMachine.IsDead()) return;

        moveKeyPressed = true;

        if (!marioStateMachine.IsJumping())
        {
            if (marioVelocity.X > 0f)
            {
                marioStateMachine.SetMarioTurning();
            }
            else if (!marioStateMachine.IsCrouching())
            {
                marioStateMachine.SetMarioLeft();
                marioStateMachine.SetMarioMoving();
            }
        }

        if (!marioStateMachine.IsCrouching())
        {
            if (marioVelocity.X > -maxSpeed)
            {
                marioVelocity.X -= acceleration;
            }
        }
    }

    public void Jump()
    {
        if (marioStateMachine.IsDead()) return;

        if (isOnGround && !marioStateMachine.IsCrouching())
        {
            marioVelocity.Y = jumpSpeed;
            marioStateMachine.SetMarioJumping();
            isOnGround = false;
            _sfx[3].Play();
        }
    }

    public void Crouch()
    {
        if (marioStateMachine.IsDead()) return;

        if (!marioStateMachine.IsJumping())
        {
            marioStateMachine.SetMarioCrouching();
        }
    }

    public void ApplyGravity(GameTime gameTime)
    {
        if (marioStateMachine.IsDead()) return;

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
        if (marioStateMachine.IsDead()) return;

        if (!canPowerUp) return; // Prevent power-ups if not allowed
        switch (marioStateMachine.CurrentGameState)
        {
            case MarioStateMachine.MarioGameState.Small:
                marioStateMachine.SetMarioBig();
                _sfx[0].Play();
                break;

            case MarioStateMachine.MarioGameState.Big:
                marioStateMachine.SetMarioFire();
                _sfx[0].Play();
                break;

            case MarioStateMachine.MarioGameState.Fire:
                break;
        }
        canPowerUp = false;
        Task.Delay(1000).ContinueWith(t => canPowerUp = true); // Reset after 1 second
    }

    public void MarioTakeDamage()
    {
        if (marioStateMachine.IsDead()) return;

        if (!canTakeDamage) return;
        switch (marioStateMachine.CurrentGameState)
        {
            case MarioStateMachine.MarioGameState.Fire:
                _sfx[1].Play();
                marioStateMachine.SetMarioBig();
                break;

            case MarioStateMachine.MarioGameState.Big:
                _sfx[1].Play();
                marioStateMachine.SetMarioSmall();
                break;

            case MarioStateMachine.MarioGameState.Small:
                marioStateMachine.SetMarioDead();
                break;
        }
        canTakeDamage = false;
        Task.Delay(1000).ContinueWith(t => canTakeDamage = true); // Reset after 1 second
    }

    public void MarioDeath()
    {
        if (marioStateMachine.IsDead())
        {
            if (!deathSoundPlaying)
            {
                _sfx[4].Play();
                deathSoundPlaying = true;
            }
            marioVelocity.X = 0; marioVelocity.Y = 0;
            marioPosition.Y -= (float)marioDeathBounceIncrement;
            marioDeathBounceIncrement -= 1;

            //Start timer and reset automatically after mario dies
            if (gameResetTimer > 0)
            {
                gameResetTimer -= 1;
            }
            else if (gameResetTimer < 0)
            {
                gameResetTimer = 250;
            }
            else if (gameResetTimer == 0)
            {
                game.hudManager.LoseLife();
                game.ResetGame();
            }
        }
    }
    public void SwapDirection()
    {
        if (marioStateMachine.IsDead()) return;

        if (marioStateMachine.IsMoving())
        {
            marioStateMachine.SetMarioTurning();
            marioVelocity.X = 0f;
        }
    }

    public void Stop()
    {
        if (marioStateMachine.IsDead()) return;

        //Cut Mario's speed when movement key is released, feels better to control
        marioVelocity.X *= 0.3f;
        
        moveKeyPressed = false;

        if (isOnGround)
        {
            marioStateMachine.SetMarioIdle();
        }
    }

    private void CheckStopTurningUpd()
    {
        if (marioStateMachine.IsTurning())
        {
            if ((marioStateMachine.CurrentFaceState == MarioStateMachine.MarioFaceState.Left) && (marioVelocity.X <= 0f))
            {
                marioStateMachine.SetMarioLeft();
            }
            else if ((marioStateMachine.CurrentFaceState == MarioStateMachine.MarioFaceState.Right) && (marioVelocity.X >= 0f))
            {
                marioStateMachine.SetMarioRight();
            }
        }
    }

    private void SlowStopMario()
    {
        if (!moveKeyPressed && !marioStateMachine.IsJumping())
        {
            //naturally slow down mario
            marioVelocity.X *= 0.5f;
        }
    
        if (Math.Abs(marioVelocity.X) < 0.025f)
        {
            marioVelocity.X = 0f;
        }
    }

    public void ShootFireball()
    {
        if (marioStateMachine.IsDead()) return;
        if (fireballTimer > 0) return;

        if (marioStateMachine.IsFire())
        {
            _sfx[2].Play();
            Fireball f = new Fireball(marioPosition, game.ItemsTexture, gameTime, marioStateMachine.CurrentFaceState, game, _entities);
            game.fireballs.Add(f);
            fireballTimer = 20;
        }
    }

    public void Update(GameTime gameTime)
    {
        ApplyGravity(gameTime);
        marioPosition.X += marioVelocity.X;
        this.SlowStopMario();
        this.CheckStopTurningUpd();
        this.MarioDeath();
        currentMarioSprite = MarioSpriteMachine.UpdateMarioSprite(marioStateMachine, marioTexture);
        currentMarioSprite.Update(gameTime);
        fireballTimer += -1;
        starTimer += -1;
        this.RemoveStar();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, marioPosition, this.HasStar());
    }

    public void Reset()
    {
        marioPosition = initialPosition;                                                    // Reset Mario's position
        marioVelocity = Vector2.Zero;                                                       // Reset velocity
        marioStateMachine.Reset();                                                          // Reset Mario's state machine to the default state
        isOnGround = true;                                                                  // Set Mario as standing on the ground
        currentMarioSprite = new IdleRightSmallMario(marioTexture);                         // Set mario to small idle right again
        marioDeathBounceIncrement = 20;
        gameResetTimer = -1;
        deathSoundPlaying = false;
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
        starTimer = 450;
        marioStateMachine.SetStar();
    }

    public void RemoveStar()
    {
        if (this.HasStar() && starTimer <= 0)
        {
            marioStateMachine.RemoveStar();
        }
    }
    public void updateGroundPosition(float gp)
    {
        this.groundPosition = gp;
    }

    public bool isSmall()
    {

        return marioStateMachine.isSmall();
    }

    public bool isBig()
    {
        return marioStateMachine.isBig();
    }
    public bool isFire()
    {
        return marioStateMachine.isFire();
    }   
}