﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Audio;
using System.Net.NetworkInformation;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private GameTime gameTime;
    private float gameOverTickTimer;

    private TextureManager textureManager;
    public HudManager hudManager;

    private Mario mario;
    public Vector2 initial_mario_position;
    private ISpriteAnimation Dance;

    private PlayerCommandControlCenter playerCommandControlCenter;
    private PlayerMovementController marioMovementController;
    private KeyboardControllerMovement keyboardControllerMovement;
    private KeyboardController keyboardController;
    private CommandControlCenter controlCenter;

    private GameStateMachine gameStateMachine;
    private MouseController gameStateMouseController;
    private KeyboardController gameStateKeyboardController;
    private GameStateControlCenter gameStateControlCenter;

    public List<Fireball> fireballs = new List<Fireball>();
    public List<IEntity> entities = new List<IEntity>();
    private List<IEntity> entitiesRemoved = new List<IEntity>();
    private List<SoundEffect> marioSounds = new List<SoundEffect>();
    private List<SoundEffect> ItemSounds = new List<SoundEffect>();
    private List<Rectangle> collidableRectangles;

    private Sort sort = new Sort();
    private Sweep sweep;

    private SoundEffect oneUpSound;
    private SoundEffect breakBlockSound;
    private SoundEffect coinSound;
    private SoundEffect fireBallSound;
    private SoundEffect flagPoleSound;
    private SoundEffect pipeSound;
    private SoundEffect powerUpSound;
    private SoundEffect powerDownSound;
    private SoundEffect powerUpSpawnsSound;
    private SoundEffect marioJump;
    private SoundEffect marioDeath;
    private SoundEffect gameOverSound;

    private Rectangle screen = new Rectangle(0, 0, 800, 480);
    private FollowCamera camera;

    private Ground ground;
    private ToggleFalling toggleFalling;
    private ToggleFalling ToggleFalling;

    private BlackJackStateMachine blackJackStateMachine;
    private SoundEffect fwip;

    private StartScreenSprite startScreenSprite;
    private LevelScreenSprite levelScreenSprite;
    private SpriteFont startScreenFonts;
    private SpriteFont levelScreenFonts;

    private LevelOne levelOne;
    private LevelTwo levelTwo;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        camera = new(Vector2.Zero);
    }

    public void ResetGame()
    {
        entities.Clear();
        if (gameStateMachine.isLevelOne())
        {
            levelOne.InitializeLevel();
        }
        else if (gameStateMachine.isLevelTwo())
        {

        }

        fireballs.Clear();
        mario.Reset();
        hudManager.SetTime(400);
        camera = new(Vector2.Zero);
    }

    public void GameOver()
    {
        gameStateMachine.setGameStateOver();
        gameOverSound.Play();
    }
    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();
        this.sweep = new Sweep(gameTime);

        textureManager = new TextureManager(Content);
        Dance = new DancePole();

        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();
        controlCenter = new CommandControlCenter(this);

        levelOne = new LevelOne(this, mario, entities, entitiesRemoved, spriteBatch, gameTime, Content, textureManager);
        levelOne.InitializeLevel();

        collidableRectangles = new List<Rectangle>();
        collidableRectangles = levelOne.GetLevelOneRectangles();
        ground = new Ground(collidableRectangles);
        toggleFalling = new ToggleFalling(ground, entities, this.mario);
    }

    public void SetKey(KeyboardController keys)
    {
        keyboardController = keys;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        textureManager = new TextureManager(Content);

        pipeSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_pipe");
        oneUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_1-up");
        coinSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_coin");
        fireBallSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_fireball");
        flagPoleSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_flagpole");
        powerUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_powerup");
        powerUpSpawnsSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_powerup_appears");
        marioJump = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_jump-small");
        marioDeath = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_mariodie");
        fwip = Content.Load<SoundEffect>("Audio/flip");
        gameOverSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_gameover");

        ItemSounds.Add(coinSound);
        ItemSounds.Add(powerUpSpawnsSound);

        marioSounds.Add(powerUpSound);
        marioSounds.Add(pipeSound);
        marioSounds.Add(fireBallSound);
        marioSounds.Add(marioJump);
        marioSounds.Add(marioDeath);
        marioSounds.Add(flagPoleSound);

        mario = new Mario(this, entities, marioSounds, textureManager, gameTime);

        startScreenFonts = Content.Load<SpriteFont>("StartScreenFonts");
        levelScreenFonts = Content.Load<SpriteFont>("LevelScreenFonts");
        startScreenSprite = new StartScreenSprite(textureManager, startScreenFonts);
        levelScreenSprite = new LevelScreenSprite(levelScreenFonts);

        blackJackStateMachine = new BlackJackStateMachine(textureManager, fwip, startScreenFonts);
        hudManager = new HudManager(startScreenFonts, this, mario);

        marioMovementController = new PlayerMovementController();
        playerCommandControlCenter = new PlayerCommandControlCenter(mario, marioMovementController);

        gameStateMachine = new GameStateMachine();
        gameStateKeyboardController = new KeyboardController();
        gameStateMouseController = new MouseController();
        gameStateControlCenter = new GameStateControlCenter(gameStateMachine, gameStateKeyboardController, gameStateMouseController, this, startScreenSprite, levelScreenSprite, Content, blackJackStateMachine);

    }

    protected override void Update(GameTime gameTime)
    {
        gameStateKeyboardController.Update();
        gameStateMouseController.Update();

        List<IEntity> temp = entities;
        entities = sort.SortList(entities, entities.Count, temp);
        sweep.Compare(entities, entitiesRemoved, camera.position);

        blackJackStateMachine.Update();
        if (gameStateMachine.isCurrentStateRunning())
        {
            keyboardController.Update();
            keyboardControllerMovement.Update();
            marioMovementController.Update();

            levelOne.UpdateLevel(gameTime);
            camera.Follow(mario.marioPosition, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

            foreach (var item in fireballs)
            {
                item.Update(gameTime);
            }

            foreach (var consumedEntity in entitiesRemoved)
            {
                if (entities.Contains(consumedEntity))
                {
                    entities.Remove(consumedEntity);
                }
            }

            hudManager.Update(gameTime, camera);
        }

        if (gameStateMachine.isCurrentStatOver())
        {
            this.gameOverTickTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (gameOverTickTimer > 5000)
            {
                Process.Start("Pixel-Plumbers-Fall-2024");
                Environment.Exit(0);
            }
        }

        toggleFalling.updateMarioFalling(mario);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

        if (gameStateMachine.isCurrentStateStart())
        {
            startScreenSprite.Draw(spriteBatch, new Vector2(200, 200));
        }

        if (gameStateMachine.isLevelScreen())
        {
            levelScreenSprite.Draw(spriteBatch, new Vector2(200, 200));
        }

        if (gameStateMachine.isCurrentStateRunning() || gameStateMachine.isCurrentStatePaused())
        {
            if (gameStateMachine.isLevelOne())
            {


                levelOne.DrawLevel(spriteBatch, camera);
            }

            if (gameStateMachine.isLevelTwo())
            {

            }

            foreach (var item in fireballs)
            {
                item.Draw(spriteBatch);
            }

            hudManager.Draw(spriteBatch);
            blackJackStateMachine.Draw(spriteBatch);
        }
        if (gameStateMachine.isCurrentStatOver())
        {
            // spriteBatch.Draw(gameOverBackground, new Vector2(camera.position.X, camera.position.Y), Color.Black);
            spriteBatch.DrawString(startScreenFonts, "GAME OVER", new Vector2(camera.position.X + 300, camera.position.Y + 150), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
        }
        spriteBatch.End();
        base.Draw(gameTime);
    }
}