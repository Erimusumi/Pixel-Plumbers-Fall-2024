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
    void Turn();
    void GetPowerup();
    void GetStar();
    void Crouch();

}

class Mario : IMario
{
    IMarioState state;
    //IMarioObject is reference to IMario in Game1. Kept here as variable so that the
    //decorators can change it
    IMario IMarioObject;

    public Mario(IMario mario)
    {
        IMarioObject = mario;
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

    public void Turn()
    {
        state.Turn();
    }
    public void Crouch()
    {
        state.Crouch();
    }
    public void GetPowerup()
    {
        state.GetPowerup();
    }
    public void GetStar()
    {
        IMarioObject = new StarMario(this, IMarioObject);
    }
}

class StarMario : IMario
{
    IMario decoratedMario;
    IMario IMarioObject;
    //Replace timer with however long the star lasts
    int timer = 100;

    public StarMario(IMario decoratedMario, IMario mario)
    {
        this.decoratedMario = decoratedMario;
        IMarioObject = mario;
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
    public void GetPowerup()
    {
        decoratedMario.GetPowerup();
    }

    public void GetStar()
    {
        //Do nothing since already has star
        //Maybe reset timer?
    }

    public void RemoveStar()
    {
        //Copied directly from carmen, change to better fix our project
        IMarioObject = decoratedMario;
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

    public void Turn()
    {
        decoratedMario.Turn();
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
    IMario IMarioObject;
    public FireMario(IMario decoratedMario, IMario mario)
    {
        this.decoratedMario = decoratedMario;
        IMarioObject = mario;
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
        IMarioObject = decoratedMario;
    }

    public void ShootFire()
    {
        //TODO: this
    }
    public void GetPowerup()
    {
       decoratedMario.GetPowerup();
    }

    public void GetStar()
    {
        IMarioObject = new StarMario(this, IMarioObject);
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

    public void Turn()
    {
        decoratedMario.Turn();
    }

    public void Crouch()
    {
        decoratedMario.Crouch();
    }
}


