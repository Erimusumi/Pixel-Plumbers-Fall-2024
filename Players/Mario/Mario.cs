using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class Mario : IPlayer
{
    private Texture2D marioTexture;
    private Texture2D itemTexture;
    private TextureManager textureManager;

    private IMarioSprite currentMarioSprite;
    private PlayerStateMachine playerStateMachine;
    public GameTime gameTime;

    private Vector2 initialPosition;
    public Vector2 marioPosition;
    private Vector2 marioVelocity;
    private float groundPosition = 385f;
    private float gravity = 980f;
    private float jumpSpeed = -570f;

    private bool isOnGround = true;
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



    public Mario(Game1 game, List<IEntity> entities, List<SoundEffect> sfx, TextureManager textureManager, GameTime gametime)
    {
        this.textureManager = textureManager;

        this.marioTexture = textureManager.GetTexture("Mario");
        this.itemTexture = textureManager.GetTexture("Items");

        this.marioPosition = new Vector2(200, groundPosition);
        this.initialPosition = new Vector2(200, groundPosition);
        this.playerStateMachine = new PlayerStateMachine();
        this.gameTime = gametime;
        this.marioPosition = initialPosition;
        this.fireballTimer = 0;
        this.starTimer = 0;
        this.marioDeathBounceIncrement = 15;

        this.currentMarioSprite = new IdleRightSmallMario(marioTexture);
        this.game = game;
        this._entities = entities;

        /*
         * SFX loaded in specific order:
         * 0: Power up
         * 1: Power down
         * 2: Fireball
         * 3: Jump
         * 4: Death
         * 5:FlagPole for winning
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
        if (playerStateMachine.IsDead()) return;

        moveKeyPressed = true;
        if (!playerStateMachine.IsJumping())
        {
            if (marioVelocity.X < 0f)
            {
                playerStateMachine.SetPlayerTurning();
            }
            else if (!playerStateMachine.IsCrouching())
            {
                playerStateMachine.SetPlayerRight();
                playerStateMachine.SetPlayerMoving();
            }
        }

        if (!playerStateMachine.IsCrouching())
        {
            if (marioVelocity.X < maxSpeed)
            {
                marioVelocity.X += acceleration;
            }
        }
    }

    public void MoveLeft()
    {
        if (playerStateMachine.IsDead()) return;

        moveKeyPressed = true;

        if (!playerStateMachine.IsJumping())
        {
            if (marioVelocity.X > 0f)
            {
                playerStateMachine.SetPlayerTurning();
            }
            else if (!playerStateMachine.IsCrouching())
            {
                playerStateMachine.SetPlayerLeft();
                playerStateMachine.SetPlayerMoving();
            }
        }

        if (!playerStateMachine.IsCrouching())
        {
            if (marioVelocity.X > -maxSpeed)
            {
                marioVelocity.X -= acceleration;
            }
        }
    }

    public void Jump()
    {
        if (playerStateMachine.IsDead()) return;

        if (isOnGround && !playerStateMachine.IsCrouching())
        {
            marioVelocity.Y = jumpSpeed;
            playerStateMachine.SetPlayerJumping();
            isOnGround = false;
            _sfx[3].Play();
        }
    }

    public void Crouch()
    {
        if (playerStateMachine.IsDead()) return;

        if (!playerStateMachine.IsJumping())
        {
            playerStateMachine.SetPlayerCrouching();
            }
        }

        public void ApplyGravity(GameTime gameTime)
    {
        if (playerStateMachine.IsDead()) return;

        if (!isOnGround)
        {
            marioVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            marioPosition.Y += marioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (marioPosition.Y >= groundPosition)
            {
                marioPosition.Y = groundPosition;
                marioVelocity.Y = 0;
                isOnGround = true;
                playerStateMachine.UpdateMoveStateForJumping();
            }
        }
    }
    public void ForceGravity(GameTime gameTime)
    {
        marioVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        marioPosition.Y += marioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void PowerUp()
    {
        if (playerStateMachine.IsDead()) return;

        if (!canPowerUp) return; // Prevent power-ups if not allowed
        switch (playerStateMachine.CurrentGameState)
        {
            case PlayerStateMachine.PlayerGameState.Small:
                playerStateMachine.SetPlayerBig();
                _sfx[0].Play();
                break;

            case PlayerStateMachine.PlayerGameState.Big:
                playerStateMachine.SetPlayerFire();
                _sfx[0].Play();
                break;

            case PlayerStateMachine.PlayerGameState.Fire:
                break;
        }
        canPowerUp = false;
        Task.Delay(1000).ContinueWith(t => canPowerUp = true); // Reset after 1 second
    }

    public void TakeDamage()
    {
        if (playerStateMachine.IsDead()) return;

        if (!canTakeDamage) return;
        switch (playerStateMachine.CurrentGameState)
        {
            case PlayerStateMachine.PlayerGameState.Fire:
                _sfx[1].Play();
                playerStateMachine.SetPlayerBig();
                break;

            case PlayerStateMachine.PlayerGameState.Big:
                _sfx[1].Play();
                playerStateMachine.SetPlayerSmall();
                break;

            case PlayerStateMachine.PlayerGameState.Small:
                playerStateMachine.SetPlayerDead();
                break;
        }
        canTakeDamage = false;
        Task.Delay(1000).ContinueWith(t => canTakeDamage = true); // Reset after 1 second
    }
    public void MarioWins()
    {
        if (playerStateMachine.Wins())
        {
            _sfx[5].Play();
            playerStateMachine.MakeInvisible();

        }
    }

    public void MarioDeath()
    {
        if (playerStateMachine.IsDead())
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
                if (game.hudManager.GetNumLives() <= 0)
                {
                    game.GameOver();
                }
                else
                {
                    game.ResetGame();
                }
            }
        }
    }
    public void SwapDirection()
    {
        if (playerStateMachine.IsDead()) return;

        if (playerStateMachine.IsMoving())
        {
            playerStateMachine.SetPlayerTurning();
            marioVelocity.X = 0f;
        }
    }

    public void Stop()
    {
        if (playerStateMachine.IsDead()) return;

        //Cut Mario's speed when movement key is released, feels better to control
        marioVelocity.X *= 0.3f;

        moveKeyPressed = false;

        if (!playerStateMachine.IsJumping())
        {
            playerStateMachine.SetPlayerIdle();
        }
    }

    public void JumpStop()
    {
        if (playerStateMachine.IsDead()) return;
        moveKeyPressed = false;
        if (!playerStateMachine.IsMoving())
        {
            playerStateMachine.SetPlayerIdle();
        }
    }

    private void CheckStopTurningUpd()
    {
        if (playerStateMachine.IsTurning())
        {
            if ((playerStateMachine.CurrentFaceState == PlayerStateMachine.PlayerFaceState.Left) && (marioVelocity.X <= 0f))
            {
                playerStateMachine.SetPlayerLeft();
            }
            else if ((playerStateMachine.CurrentFaceState == PlayerStateMachine.PlayerFaceState.Right) && (marioVelocity.X >= 0f))
            {
                playerStateMachine.SetPlayerRight();
            }
        }
    }

    private void SlowStopMario()
    {
        if (!moveKeyPressed && !playerStateMachine.IsJumping())
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
        if (playerStateMachine.IsDead()) return;
        if (fireballTimer > 0) return;

        if (playerStateMachine.IsFire())
        {
            _sfx[2].Play();
            Fireball f = new Fireball(marioPosition, itemTexture, gameTime, playerStateMachine.CurrentFaceState, game, _entities);
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
        currentMarioSprite = MarioSpriteMachine.UpdateMarioSprite(playerStateMachine, marioTexture);
        currentMarioSprite.Update(gameTime);
        fireballTimer += -1;
        starTimer += -1;
        this.RemoveStar();
        this.checkMarioHeightForDeath();
        this.MarioWins();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, marioPosition, this.HasStar());
    }

    public void Reset()
    {
        marioPosition = initialPosition;                                                    // Reset Mario's position
        marioVelocity = Vector2.Zero;                                                       // Reset velocity
        playerStateMachine.Reset();                                                          // Reset Mario's state machine to the default state
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
    public float GroundPosition()
    {
        return this.groundPosition;
    }
    public void checkMarioHeightForDeath()
    {
        if (this.GetDestination().Y > 464)
        {
            playerStateMachine.SetPlayerDead();
        }
    }


    public PlayerStateMachine.PlayerGameState GetGameState()
    {
        return playerStateMachine.CurrentGameState;
    }

    public bool HasStar()
    {
        return playerStateMachine.HasStar();
    }

    public void SetVelocityY(float velocityY)
    {
        marioVelocity.Y = velocityY;
    }

    public void SetVelocityX(float velocityX)
    {
        marioVelocity.X = velocityX;
    }
    public void SetPositionY(float positionY)
    {
        marioPosition.Y = positionY;
    }
    public void SetPositionX(float positionX)
    {
        marioPosition.X = positionX;
    }
    public void SetIsOnGround(bool isGround)
    {
        isOnGround = isGround;
    }
    public bool GetIsOnGround()
    {
        return isOnGround;
    }
    public void CollectStar()
    {
        starTimer = 450;
        playerStateMachine.SetStar();
    }

    public void RemoveStar()
    {
        if (this.HasStar() && starTimer <= 0)
        {
            playerStateMachine.RemoveStar();
        }
    }
    public void updateGroundPosition(float gp)
    {
        this.groundPosition = gp;
    }

    public bool isSmall()
    {

        return playerStateMachine.IsSmall();
    }

    public bool isBig()
    {
        return playerStateMachine.IsBig();
    }
    public bool isFire()
    {
        return playerStateMachine.IsFire();
    }
}