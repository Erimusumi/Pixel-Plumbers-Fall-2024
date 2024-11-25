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

public class Luigi : IPlayer
{
    private Texture2D luigiTexture;
    private Texture2D itemTexture;
    private TextureManager textureManager;

    private ICharacter currentMarioSprite;
    private PlayerStateMachine playerStateMachine;
    private IMarioSpriteMachine luigiSpriteMachine;
    public GameTime gameTime;

    private Vector2 initialPosition;
    public Vector2 luigiPosition;
    private Vector2 luigiVelocity;
    private float groundPosition = 385f;
    private float gravity = 980f;
    private float jumpSpeed = -570f;

    public bool isOnGround = true;
    private bool canPowerUp = true;
    private bool canTakeDamage = true;
    private bool moveKeyPressed = false;
    private bool deathSoundPlaying = false;
    private bool isSwimmingLevel = false;

    private const float maxSpeed = 3f;
    private const float acceleration = 0.03f;

    private int fireballTimer;
    private int starTimer;
    int luigiDeathBounceIncrement;
    private List<SoundEffect> _sfx;

    private Game1 game;
    private int gameResetTimer = -1;
    private List<IEntity> _entities;



    public Luigi(Game1 game, List<IEntity> entities, List<SoundEffect> sfx, TextureManager textureManager, GameTime gametime)
    {
        this.textureManager = textureManager;

        this.luigiTexture = textureManager.GetTexture("luigi");
        this.itemTexture = textureManager.GetTexture("Items");

        this.luigiPosition = new Vector2(200, groundPosition);
        this.initialPosition = new Vector2(200, groundPosition);
        this.playerStateMachine = new PlayerStateMachine();
        this.gameTime = gametime;
        this.luigiPosition = initialPosition;
        this.fireballTimer = 0;
        this.starTimer = 0;
        this.luigiDeathBounceIncrement = 15;

        this.currentMarioSprite = new IdleRightSmallMario(luigiTexture);
        this.game = game;
        this._entities = entities;

        this._sfx = sfx;
    }

    public void MoveRight()
    {
        if (playerStateMachine.IsDead()) return;

        moveKeyPressed = true;
        if (!playerStateMachine.IsJumping())
        {
            if (luigiVelocity.X < 0f)
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
            if (luigiVelocity.X < maxSpeed)
            {
                luigiVelocity.X += acceleration;
            }
        }
    }

    public void MoveLeft()
    {
        if (playerStateMachine.IsDead()) return;

        moveKeyPressed = true;

        if (!playerStateMachine.IsJumping())
        {
            if (luigiVelocity.X > 0f)
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
            if (luigiVelocity.X > -maxSpeed)
            {
                luigiVelocity.X -= acceleration;
            }
        }
    }

    public void Jump()
    {
        if (playerStateMachine.IsDead()) return;

        if (isOnGround && !playerStateMachine.IsCrouching())
        {
            luigiVelocity.Y = jumpSpeed;
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
            luigiVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            luigiVelocity.Y += luigiVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (luigiVelocity.Y >= groundPosition)
            {
                luigiVelocity.Y = groundPosition;
                luigiVelocity.Y = 0;
                isOnGround = true;
                playerStateMachine.UpdateMoveStateForJumping();
            }
        }
    }
    public void ForceGravity(GameTime gameTime)
    {
        luigiVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        luigiVelocity.Y += luigiVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void PowerUp()
    {
        if (playerStateMachine.IsDead()) return;

        if (!canPowerUp) return;
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
        Task.Delay(1000).ContinueWith(t => canTakeDamage = true);
    }
    public void MarioWins()
    {
        if (playerStateMachine.Wins())
        {
            _sfx[5].Play();
            playerStateMachine.MakeInvisible();

        }
    }

    public void LuigiDeath()
    {
        if (playerStateMachine.IsDead())
        {
            if (!deathSoundPlaying)
            {
                _sfx[4].Play();
                deathSoundPlaying = true;
            }
            luigiVelocity.X = 0; luigiVelocity.Y = 0;
            luigiVelocity.Y -= (float)luigiDeathBounceIncrement;
            luigiDeathBounceIncrement -= 1;

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
            luigiVelocity.X = 0f;
        }
    }

    public void Stop()
    {
        if (playerStateMachine.IsDead()) return;

        luigiVelocity.X *= 0.3f;

        moveKeyPressed = false;

        if (isOnGround)
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
            if ((playerStateMachine.CurrentFaceState == PlayerStateMachine.PlayerFaceState.Left) && (luigiVelocity.X <= 0f))
            {
                playerStateMachine.SetPlayerLeft();
            }
            else if ((playerStateMachine.CurrentFaceState == PlayerStateMachine.PlayerFaceState.Right) && (luigiVelocity.X >= 0f))
            {
                playerStateMachine.SetPlayerRight();
            }
        }
    }

    private void SlowStopMario()
    {
        if (!moveKeyPressed && !playerStateMachine.IsJumping())
        {
            luigiVelocity.X *= 0.5f;
        }

        if (Math.Abs(luigiVelocity.X) < 0.025f)
        {
            luigiVelocity.X = 0f;
        }
    }

    public void ShootFireball()
    {
        if (playerStateMachine.IsDead()) return;
        if (fireballTimer > 0) return;

        if (playerStateMachine.IsFire())
        {
            _sfx[2].Play();
            // Fireball f = new Fireball(luigiPosition, itemTexture, gameTime, luigiStateMachine.CurrentFaceState, game, _entities);
            // game.fireballs.Add(f);
            fireballTimer = 20;
        }
    }

    public void Update(GameTime gameTime)
    {
        ApplyGravity(gameTime);
        luigiPosition.X += luigiVelocity.X;
        this.SlowStopMario();
        this.CheckStopTurningUpd();
        this.LuigiDeath();
        currentMarioSprite = luigiSpriteMachine.UpdatePlayerSprite(playerStateMachine, luigiTexture);
        currentMarioSprite.Update(gameTime);
        fireballTimer += -1;
        starTimer += -1;
        this.RemoveStar();
        this.checkMarioHeightForDeath();
        this.MarioWins();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentMarioSprite.Draw(spriteBatch, luigiPosition, this.HasStar());
    }

    public void Reset()
    {
        luigiVelocity = initialPosition;
        luigiVelocity = Vector2.Zero;
        playerStateMachine.Reset();
        isOnGround = true;
        currentMarioSprite = new IdleRightSmallMario(luigiTexture);
        luigiDeathBounceIncrement = 20;
        gameResetTimer = -1;
        deathSoundPlaying = false;

    }

    public Rectangle GetDestination()
    {
        return currentMarioSprite.GetDestination(luigiPosition);
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
        luigiVelocity.Y = velocityY;
    }
    public void SetVelocityX(float velocityX)
    {
        luigiVelocity.X = velocityX;
    }
    public void SetPositionY(float positionY)
    {
        luigiPosition.Y = positionY;
    }
    public void SetPositionX(float positionX)
    {
        luigiPosition.X = positionX;
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

    public void SetSwimmingLevel(bool isLevelSwimming)
    {
        isSwimmingLevel = isLevelSwimming;
        playerStateMachine.setSwimmingLevel(isLevelSwimming);

        if (isSwimmingLevel)
        {
            //Reduce gravity and jump height, "floaty" physics
            luigiSpriteMachine = new LuigiSpriteMachineSwimming();
            gravity = 980f / 4f;
            jumpSpeed = -570f / 4f;
        }
        else
        {
            //Set parameters to normal
            luigiSpriteMachine = new LuigiSpriteMachine();
            gravity = 980f;
            jumpSpeed = -570f;
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