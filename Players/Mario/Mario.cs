using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    private ICharacter currentMarioSprite;
    private IMarioSpriteMachine marioSpriteMachine;
    private PlayerStateMachine playerStateMachine;
    public GameTime gameTime;

    private Vector2 initialPosition;
    public Vector2 marioPosition;
    public Vector2 minPos, maxPos;
    private int tileSize = 32;
    private Vector2 marioVelocity;
    private float groundPosition = 385f;
    private float swimmingMaxHeight = 10f;
    private float gravity = 980f;
    private float jumpSpeed = -570f;

    private bool isSwimmingLevel = false;
    private bool isOnGround = true;
    private bool canPowerUp = true;
    private bool canTakeDamage = true;
    private bool moveKeyPressed = false;
    private bool deathSoundPlaying = false;
    private bool waitingForPartnerToDie = false;

    private const float maxSpeed = 3f;
    private const float acceleration = 0.03f;

    private int fireballTimer;
    private int starTimer;
    int marioDeathBounceIncrement;
    private List<SoundEffect> _sfx;

    private Game1 game;
    private int gameResetTimer = -1;
    private List<IEntity> _entities;

    private GameStateMachine gsm;
    private Luigi luigi;

    private int scoreMult;
    private const int maxScoreMult = 16;
    private SpriteFont scoreFont;

    public Mario(Game1 game, List<IEntity> entities, List<SoundEffect> sfx, TextureManager textureManager, GameTime gametime, ref GameStateMachine gsm, ref SpriteFont font)
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

        this.gsm = gsm;

        this.scoreMult = 1;
        this.scoreFont = font;

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

    public PlayerStateMachine GetStateMachine()
    {
        return this.playerStateMachine;
    }

    public void MoveRight()
    {
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
        if (isSwimmingLevel && (marioVelocity.X > 0f))
        {
            playerStateMachine.SetPlayerRight();
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
        if (isSwimmingLevel && (marioVelocity.X < 0f))
        {
            playerStateMachine.SetPlayerLeft();
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
        if (this.gsm == null)
        {
            this.TakeDamage();
        }
        if ((isOnGround || isSwimmingLevel) && !playerStateMachine.IsCrouching())
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
            marioVelocity.X = 0;
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
        if (playerStateMachine.IsDead() || !canPowerUp) return;
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
        Task.Delay(1000).ContinueWith(t => canPowerUp = true);
    }

    public void TakeDamage()
    {
        if (playerStateMachine.IsDead() || !canTakeDamage) return;
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
        Task.Delay(1000).ContinueWith(t => canTakeDamage = true);
    }

    public void SetWin()
    {
        playerStateMachine.SetPlayerWins();
    }

    public void MarioWins()
    {
        if (playerStateMachine.Wins())
        {
            marioVelocity.Y = 0;
            marioVelocity.X = 0;
            marioPosition.Y++;
            //_sfx[5].Play();
            playerStateMachine.MakeInvisible();
        }
    }

    public void MarioDeath()
    {
        if (playerStateMachine.IsDead() && !waitingForPartnerToDie)
        {
            if (!deathSoundPlaying)
            {
                _sfx[4].Play();
                deathSoundPlaying = true;
            }
            marioVelocity.X = 0; marioVelocity.Y = 0;
            marioPosition.Y -= (float)marioDeathBounceIncrement;
            marioDeathBounceIncrement -= 1;
            if (gameResetTimer > 0)
            {
                gameResetTimer -= 1;
            }
            else if (gameResetTimer < 0)
            {
                game.hudManager.LoseLife();
                gameResetTimer = 250;
            }
            else if (gameResetTimer == 0)
            {
                if (gsm.isMultiplayer() && !luigi.getStateMachine().IsDead())
                {
                    waitingForPartnerToDie = true;
                }
                if (gsm.isSingleplayer() || (gsm.isMultiplayer() && luigi.getStateMachine().IsDead()))
                {
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
            marioVelocity.X *= 0.5f;
        }
        if (Math.Abs(marioVelocity.X) < 0.025f)
        {
            marioVelocity.X = 0f;
        }
    }

    public void ShootFireball()
    {
        if (playerStateMachine.IsDead() || fireballTimer > 0) return;
        if (playerStateMachine.IsFire())
        {
            _sfx[2].Play();
            Fireball f = new Fireball(marioPosition, itemTexture, gameTime, playerStateMachine.CurrentFaceState, game, _entities, this);
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
        this.CheckSwimmingMaxHeight();
        this.MarioDeath();
        currentMarioSprite = marioSpriteMachine.UpdatePlayerSprite(playerStateMachine, marioTexture);
        currentMarioSprite.Update(gameTime);
        fireballTimer += -1;
        starTimer += -1;
        this.RemoveStar();
        this.checkMarioHeightForDeath();
        this.MarioWins();
    }

    public void SetSwimmingLevel(bool isLevelSwimming)
    {
        isSwimmingLevel = isLevelSwimming;
        playerStateMachine.setSwimmingLevel(isLevelSwimming);

        if (isSwimmingLevel)
        {
            marioSpriteMachine = new MarioSpriteMachineSwimming();
            gravity = 980f / 4f;
            jumpSpeed = -570f / 4f;
        }
        else
        {
            marioSpriteMachine = new MarioSpriteMachine();
            gravity = 980f;
            jumpSpeed = -570f;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, marioPosition, this.playerStateMachine.HasStar());
    }



    public void Reset()
    {
        marioPosition = initialPosition;
        marioVelocity = Vector2.Zero;
        playerStateMachine.Reset();
        isOnGround = true;
        currentMarioSprite = new IdleRightSmallMario(marioTexture);
        marioDeathBounceIncrement = 20;
        gameResetTimer = -1;
        deathSoundPlaying = false;
        waitingForPartnerToDie = false;
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
        if (this.GetDestination().Y > 1500)
        {
            playerStateMachine.SetPlayerDead();
        }
    }

    private void CheckSwimmingMaxHeight()
    {
        if (isSwimmingLevel && (marioPosition.Y < swimmingMaxHeight))
        {
            marioPosition.Y = swimmingMaxHeight;
        }
    }

    public PlayerStateMachine.PlayerGameState GetGameState()
    {
        return playerStateMachine.CurrentGameState;
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
        if (this.playerStateMachine.HasStar() && starTimer <= 0)
        {
            playerStateMachine.RemoveStar();
        }
    }

    public void updateGroundPosition(float gp)
    {
        this.groundPosition = gp;
    }

    public PlayerStateMachine getStateMachine()
    {
        return this.playerStateMachine;
    }

    //public int GetScoreMult()
    //{
    //    return this.scoreMult;
    //}

    public void IncreaseScoreMult()
    {
        if ((scoreMult < maxScoreMult) && !isSwimmingLevel)
        {
            this.scoreMult *= 2;
        }
    }

    public void ResetScoreMult()
    {
        
        if (isOnGround && !this.playerStateMachine.HasStar())
        {
            scoreMult = 1;
        }
    }

    public void AddScore(int scoreAmt)
    {
        game.hudManager.AddScore(scoreAmt * this.scoreMult);
        //game.scorePopups.Add(new ScorePopup(marioPosition, scoreFont, this.game, game.scorePopups, this, scoreAmt * this.scoreMult));
    }
    public void AddCoin()
    {
        game.hudManager.CollectCoin();
    }
    public void playSound(int index)
    {
        _sfx[index].Play();
    }

    public void SetLuigiRef(Luigi luigi)
    {
        this.luigi = luigi;
    }
}