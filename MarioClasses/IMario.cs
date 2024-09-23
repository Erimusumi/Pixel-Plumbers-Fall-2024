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
    //Move method might be unneccessary, if there's a more appropriate place for it
    void Move();
}

class Mario : IMario
{
    IMarioState state;

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
    public void Move()
    { 
        state.Move();
    }
}

class StarMario : IMario
{
    IMario decoratedMario;
    //Replace timer with however long the star lasts
    int timer = 0;
    
    public StarMario (IMario decoratedMario)
    {
        this.decoratedMario = decoratedMario;
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

    public void RemoveStar()
    {
        //Copied directly from carmen, change to better fix our project
        Game1.Instance.mario = decoratedMario;
    }
    public void Move()
    {
        decoratedMario.Move();
    }
}
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

    public void RemovePowerup()
    {
        //Copied directly from carmen, change to better fix our project
        Game1.Instance.mario = decoratedMario;
    }
    public void Move()
    {
        decoratedMario.Move();
    }
}

class FireMario : IMario
{
    IMario decoratedMario;
    public FireMario(IMario decoratedMario)
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

    public void RemovePowerup()
    {
        //Copied directly from carmen, change to better fix our project
        Game1.Instance.mario = decoratedMario;
    }
    public void Move()
    {
        decoratedMario.Move();
    }

    public void ShootFire()
    {
        
    }
}

