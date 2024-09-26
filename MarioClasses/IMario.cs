using Pixel_Plumbers_Fall_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMario
{
    void TakeDamage();
    void Update();
    void Jump();
    void Stop();
    void Walk();
    void Run();
    void Swim();
    void SwapDir();
    void Turning();
    void CollectPowerup(int powType);
    void CollectStar();
    void Crouch();

}

class Mario : IMario
{
    IMarioState state;
    //IMarioObject is reference to IMario in Game1. Kept here as variable so that the
    //decorators can change it
    Game1 game;

    public Mario(Game1 game)
    {
        this.game = game;
        state = new MarioState();
    }
    
    public void TakeDamage()
    {
        state.TakeDamage();
    }
    public void Jump()
    {
        state.Jump();
    }
    public void Update()
    {
        state.Update();
    }

    public void Stop()
    {
        state.Stop();
    }
    public void Walk()
    { 
        state.Walk();
    }
    public void Run()
    {
        state.Run();
    }
    public void Swim()
    {
        state.Swim();
    }

    public void SwapDir()
    {
        state.SwapDir();
    }
    public void Turning()
    {
        state.Turning();
    }
    public void Crouch()
    {
        state.Crouch();
    }
    public void CollectPowerup(int powType)
    {
        state.CollectPowerup(powType);
    }
    public void CollectStar()
    {
        game.Mario = new StarMario(this, this.game);
    }
}

class StarMario : IMario
{
    IMario decoratedMario;
    Game1 game;
    //Replace timer with however long the star lasts
    int timer = 100;

    public StarMario(IMario decoratedMario, Game1 game)
    {
        this.decoratedMario = decoratedMario;
        this.game = game;
    }

    public void TakeDamage()
    {
        //Left empty; Mario is invincible
    }
    public void Jump()
    {
        decoratedMario.Jump();
    }
    public void Update()
    {
        timer--;
        if (timer == 0)
        {
            RemoveStar();
        }

        decoratedMario.Update();
    }
    public void CollectPowerup(int powType)
    {
        decoratedMario.CollectPowerup(powType);
    }

    public void CollectStar()
    {
        //Do nothing since already has star
        //Maybe reset timer?
    }

    public void RemoveStar()
    {
        //Copied directly from carmen, change to better fix our project
        game.Mario = decoratedMario;
    }

    public void Stop()
    {
        decoratedMario.Stop();
    }
    public void Walk()
    {
        decoratedMario.Walk();
    }

    public void Run()
    {
        decoratedMario.Run();
    }

    public void Swim()
    {
        decoratedMario.Swim();
    }

    public void SwapDir()
    {
        decoratedMario.SwapDir();
    }

    public void Turning()
    {
        decoratedMario.Turning();
    }

    public void Crouch()
    {
        decoratedMario.Crouch();
    }
}
    //BigMario doesn't have any special attributes that would require a decorator
    /*
    class BigMario : IMario
    {
        IMario decoratedMario;
        public BigMario(IMario decoratedMario)
        {
            this.decoratedMario = decoratedMario;
        }

        public void TakeDamage()
        {
            decoratedMario.TakeDamage();
        }
        public void Jump()
        {
            decoratedMario.Jump();
        }
        public void Update()
        {
            decoratedMario.Update();
        }
        public void GetPowerup()
        {
            decoratedMario.GetPowerup();
        }

        public void RemovePowerup()
        {
            //Copied directly from carmen, change to better fix our project
            Game1.Mario = decoratedMario;
        }
        public void Move()
        {
            decoratedMario.Move();
        }
    }
    */

class FireMario : IMario
{
    IMario decoratedMario;
    Game1 game;
    public FireMario(IMario decoratedMario, Game1 game)
    {
        this.decoratedMario = decoratedMario;
        this.game = game;
    }

    public void TakeDamage()
    {
        decoratedMario.TakeDamage();
    }
    public void Jump()
    {
           decoratedMario.Jump();
    }
    public void Update()
    {
        decoratedMario.Update();
    }

    public void RemovePowerup()
    {
        //Copied directly from carmen, change to better fix our project
        game.Mario = decoratedMario;
    }

    public void ShootFire()
    {
        //TODO: this
    }
    public void CollectPowerup(int powType)
    {
       //Fire Mario is the highest tier of powerup, collecting powerups will do nothing
    }

    public void CollectStar()
    {
        game.Mario = new StarMario(this, game);
    }

    public void Stop()
    {
        decoratedMario.Stop();
    }
    public void Walk()
    {
        decoratedMario.Walk();
    }

    public void Run()
    {
        decoratedMario.Run();
    }

    public void Swim()
    {
        decoratedMario.Swim();
    }

    public void SwapDir()
    {
        decoratedMario.SwapDir();
    }

    public void Turning()
    {
        decoratedMario.Turning();
    }

    public void Crouch()
    {
        decoratedMario.Crouch();
    }
}


