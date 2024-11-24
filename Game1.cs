using System;
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
    private SoundManager soundManager;
    public HudManager hudManager;

    private Mario mario;
    private Luigi luigi;

    public Vector2 initial_mario_position;
    private ISpriteAnimation Dance;

    private MarioControlCenter marioControlCenter;
    private LuigiControlCenter luigiControlCenter;

    private PlayerMovementController marioMovementController;
    private PlayerMovementController luigiMovementController;

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
    private List<Rectangle> lvl1CollidableRectangles;
    private List<Rectangle> lvl2CollidableRectangles;

    private Sort sort = new Sort();
    private Sweep sweep;

    private SoundEffect oneUpSound;
    private SoundEffect breakBlockSound;
    private SoundEffect powerDownSound;

    private Rectangle screen = new Rectangle(0, 0, 800, 480);
    private FollowCamera camera;

    private Ground ground;
    private ToggleFalling toggleFalling;
    private ToggleFalling ToggleFalling;

    private BlackJackStateMachine blackJackStateMachine;

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
            levelTwo.InitializeLevel();
        }

        fireballs.Clear();
        mario.Reset();
        hudManager.SetTime(400);
        camera = new(Vector2.Zero);
    }

    public void GameOver()
    {
        gameStateMachine.setGameStateOver();
        soundManager.GetSound("over").Play();
    }
    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();
        this.sweep = new Sweep(gameTime);

        textureManager = new TextureManager(Content);
     

        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();
        controlCenter = new CommandControlCenter(this);

        levelOne = new LevelOne(this, mario, luigi, entities, entitiesRemoved, spriteBatch, gameTime, Content, textureManager, gameStateMachine);
        levelOne.InitializeLevel();

        levelTwo = new LevelTwo(this, mario, luigi, entities, entitiesRemoved, spriteBatch, gameTime, Content, textureManager, gameStateMachine);
        levelTwo.InitializeLevel();

        lvl1CollidableRectangles = new List<Rectangle>();
        lvl1CollidableRectangles = levelOne.GetLevelFloorRectangles();
        lvl2CollidableRectangles = new List<Rectangle>();
        lvl2CollidableRectangles = levelTwo.GetLevelFloorRectangles();


    }

    public void SetKey(KeyboardController keys)
    {
        keyboardController = keys;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        textureManager = new TextureManager(Content);
        soundManager = new SoundManager(Content);

        //oneUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_1-up");

        ItemSounds.Add(soundManager.GetSound("coin"));
        ItemSounds.Add(soundManager.GetSound("spawn"));

        marioSounds.Add(soundManager.GetSound("powerup"));
        marioSounds.Add(soundManager.GetSound("pipe"));
        marioSounds.Add(soundManager.GetSound("fireball"));
        marioSounds.Add(soundManager.GetSound("jump"));
        marioSounds.Add(soundManager.GetSound("death"));
        marioSounds.Add(soundManager.GetSound("flagpole"));

        mario = new Mario(this, entities, marioSounds, textureManager, gameTime);
        luigi = new Luigi(this, entities, marioSounds, textureManager, gameTime);

        startScreenFonts = Content.Load<SpriteFont>("StartScreenFonts");
        levelScreenFonts = Content.Load<SpriteFont>("LevelScreenFonts");
        startScreenSprite = new StartScreenSprite(textureManager, startScreenFonts);
        levelScreenSprite = new LevelScreenSprite(levelScreenFonts);

        blackJackStateMachine = new BlackJackStateMachine(textureManager, soundManager.GetSound("fwip"), startScreenFonts);
        hudManager = new HudManager(startScreenFonts, this, mario);

        marioMovementController = new PlayerMovementController();
        luigiMovementController = new PlayerMovementController();

        marioControlCenter = new MarioControlCenter(mario, marioMovementController);
        luigiControlCenter = new LuigiControlCenter(luigi, luigiMovementController);

        gameStateMachine = new GameStateMachine();
        gameStateKeyboardController = new KeyboardController();
        gameStateMouseController = new MouseController();
        gameStateControlCenter = new GameStateControlCenter(gameStateMachine, gameStateKeyboardController, gameStateMouseController, this, startScreenSprite, levelScreenSprite, soundManager, blackJackStateMachine);

    }

    protected override void Update(GameTime gameTime)
    {
        ground = new Ground(lvl1CollidableRectangles);
        toggleFalling = new ToggleFalling(ground, entities, this.mario);
        if (gameStateMachine.isLevelOne())
        {
            ground = new Ground(lvl1CollidableRectangles);
            toggleFalling = new ToggleFalling(ground, entities, this.mario);
        }
        else if (gameStateMachine.isLevelTwo())
        {
            ground = new Ground(lvl2CollidableRectangles);
            toggleFalling = new ToggleFalling(ground, entities, this.mario);
        }

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
            luigiMovementController.Update();

            if (gameStateMachine.isLevelOne())
            {
                levelOne.UpdateLevel(gameTime);
            }
            else if (gameStateMachine.isLevelTwo())
            {
                levelTwo.UpdateLevel(gameTime);
            }

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

        //toggleFalling.updateMarioFalling(mario);
        toggleFalling.updates();
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
                levelTwo.DrawLevel(spriteBatch, camera);
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