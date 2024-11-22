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
    private Texture2D marioTexture;
    private Texture2D itemTexture;
    private TextureManager textureManager;

    private IMarioSprite currentMarioSprite;
    private LuigiStateMachine luigiStateMachine;
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

        this.marioTexture = textureManager.GetTexture("Mario");
        this.itemTexture = textureManager.GetTexture("Items");

        this.luigiPosition = new Vector2(200, groundPosition);
        this.initialPosition = new Vector2(200, groundPosition);
        this.luigiStateMachine = new LuigiStateMachine();
        this.gameTime = gametime;
        this.luigiPosition = initialPosition;
        this.fireballTimer = 0;
        this.starTimer = 0;
        this.luigiDeathBounceIncrement = 15;

        this.currentMarioSprite = new IdleRightSmallMario(marioTexture);
        this.game = game;
        this._entities = entities;

        this._sfx = sfx;
    }

    public void MoveRight()
    {
        if (luigiStateMachine.IsDead()) return;

        moveKeyPressed = true;
        if (!luigiStateMachine.IsJumping())
        {
            if (luigiVelocity.X < 0f)
            {
                luigiStateMachine.SetLuigiTurning();
            }
            else if (!luigiStateMachine.IsCrouching())
            {
                luigiStateMachine.SetLuigiRight();
                luigiStateMachine.SetLuigiMoving();
            }
        }

        if (!luigiStateMachine.IsCrouching())
        {
            if (luigiVelocity.X < maxSpeed)
            {
                luigiVelocity.X += acceleration;
            }
        }
    }

    public void MoveLeft()
    {
        if (luigiStateMachine.IsDead()) return;

        moveKeyPressed = true;

        if (!luigiStateMachine.IsJumping())
        {
            if (luigiVelocity.X > 0f)
            {
                luigiStateMachine.SetLuigiTurning();
            }
            else if (!luigiStateMachine.IsCrouching())
            {
                luigiStateMachine.SetLuigiLeft();
                luigiStateMachine.SetLuigiMoving();
            }
        }

        if (!luigiStateMachine.IsCrouching())
        {
            if (luigiVelocity.X > -maxSpeed)
            {
                luigiVelocity.X -= acceleration;
            }
        }
    }

    public void Jump()
    {
        if (luigiStateMachine.IsDead()) return;

        if (isOnGround && !luigiStateMachine.IsCrouching())
        {
            luigiVelocity.Y = jumpSpeed;
            luigiStateMachine.SetLuigiJumping();
            isOnGround = false;
            _sfx[3].Play();
        }
    }

    public void Crouch()
    {
        if (luigiStateMachine.IsDead()) return;

        if (!luigiStateMachine.IsJumping())
        {
            luigiStateMachine.SetLuigiCrouching();
        }
    }

    public void ApplyGravity(GameTime gameTime)
    {
        if (luigiStateMachine.IsDead()) return;

        if (!isOnGround)
        {
            luigiVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            luigiVelocity.Y += luigiVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (luigiVelocity.Y >= groundPosition)
            {
                luigiVelocity.Y = groundPosition;
                luigiVelocity.Y = 0;
                isOnGround = true;
                luigiStateMachine.UpdateMoveStateForJumping();
            }
        }
    }
    public void ForceGravity(GameTime gameTime)
    {
        luigiVelocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        luigiVelocity.Y += luigiVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void LuigiPowerUp()
    {
        if (luigiStateMachine.IsDead()) return;

        if (!canPowerUp) return;
        switch (luigiStateMachine.CurrentGameState)
        {
            case LuigiStateMachine.LuigiGameState.Small:
                luigiStateMachine.SetLuigiBig();
                _sfx[0].Play();
                break;

            case LuigiStateMachine.LuigiGameState.Big:
                luigiStateMachine.SetLuigiFire();
                _sfx[0].Play();
                break;

            case LuigiStateMachine.LuigiGameState.Fire:

                break;
        }
        canPowerUp = false;
        Task.Delay(1000).ContinueWith(t => canPowerUp = true);
    }

    public void TakeDamage()
    {
        if (luigiStateMachine.IsDead()) return;

        if (!canTakeDamage) return;
        switch (luigiStateMachine.CurrentGameState)
        {
            case LuigiStateMachine.LuigiGameState.Fire:
                _sfx[1].Play();
                luigiStateMachine.SetLuigiBig();
                break;

            case LuigiStateMachine.LuigiGameState.Big:
                _sfx[1].Play();
                luigiStateMachine.SetLuigiSmall();
                break;

            case LuigiStateMachine.LuigiGameState.Small:
                luigiStateMachine.SetLuigiDead();
                break;
        }
        canTakeDamage = false;
        Task.Delay(1000).ContinueWith(t => canTakeDamage = true);
    }
    public void MarioWins()
    {
        if (luigiStateMachine.Wins())
        {
            _sfx[5].Play();
            luigiStateMachine.MakeInvisible();

        }
    }

    public void LuigiDeath()
    {
        if (luigiStateMachine.IsDead())
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
        if (luigiStateMachine.IsDead()) return;

        if (luigiStateMachine.IsMoving())
        {
            luigiStateMachine.SetLuigiTurning();
            luigiVelocity.X = 0f;
        }
    }

    public void Stop()
    {
        if (luigiStateMachine.IsDead()) return;

        luigiVelocity.X *= 0.3f;

        moveKeyPressed = false;

        if (isOnGround)
        {
            luigiStateMachine.SetLuigiIdle();
        }
    }

    private void CheckStopTurningUpd()
    {
        if (luigiStateMachine.IsTurning())
        {
            if ((luigiStateMachine.CurrentFaceState == LuigiStateMachine.LuigiFaceState.Left) && (luigiVelocity.X <= 0f))
            {
                luigiStateMachine.SetLuigiLeft();
            }
            else if ((luigiStateMachine.CurrentFaceState == LuigiStateMachine.LuigiFaceState.Right) && (luigiVelocity.X >= 0f))
            {
                luigiStateMachine.SetLuigiRight();
            }
        }
    }

    private void SlowStopMario()
    {
        if (!moveKeyPressed && !luigiStateMachine.IsJumping())
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
        if (luigiStateMachine.IsDead()) return;
        if (fireballTimer > 0) return;

        if (luigiStateMachine.IsFire())
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
        currentMarioSprite = LuigiSpriteMachine.UpdateLuigiSprite(luigiStateMachine, marioTexture);
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
        luigiStateMachine.Reset();
        isOnGround = true;
        currentMarioSprite = new IdleRightSmallMario(marioTexture);
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
            luigiStateMachine.SetLuigiDead();
        }
    }

    public LuigiStateMachine.LuigiGameState GetLuigiGameState()
    {
        return luigiStateMachine.CurrentGameState;
    }

    public bool HasStar()
    {
        return luigiStateMachine.HasStar();
    }
    public void SetVelocityY(float velocityY)
    {
        luigiVelocity.Y = velocityY;
    }
    public void SetVelocityX(float velocityX)
    {
        luigiVelocity.X = velocityX;
    }
    public void CollectStar()
    {
        starTimer = 450;
        luigiStateMachine.SetStar();
    }

    public void RemoveStar()
    {
        if (this.HasStar() && starTimer <= 0)
        {
            luigiStateMachine.RemoveStar();
        }
    }
    public void updateGroundPosition(float gp)
    {
        this.groundPosition = gp;
    }

    public bool isSmall()
    {
        return luigiStateMachine.IsSmall();
    }

    public bool isBig()
    {
        return luigiStateMachine.IsBig();
    }
    public bool isFire()
    {
        return luigiStateMachine.IsFire();
    }
}