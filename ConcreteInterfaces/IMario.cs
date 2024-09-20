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
    public void TakeDamage()
    {

    }
    public void Jump()
    {

    }
    public void Update()
    {

    }
    public void Move()
    {

    }
}

