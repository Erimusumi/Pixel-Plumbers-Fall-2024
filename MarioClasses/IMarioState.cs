using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Mario State Machine

internal interface IMarioState
{
    void TakeDamage();
    void Jump();
    void Update();
    void Move();
    void GetPowerup();
}

public class MarioState : IMarioState
{
    private enum MarioStateEnum {LeftStill, RightStill, LeftWalk, RightWalk, LeftRun, 
        RightRun, LeftJump, RightJump, LeftCrouch, RightCrouch, LeftSwim, RightSwim, LeftTurning,
        RightTurning, Dead };
    private enum MarioPowerupEnum {Base, Big, Fire };


    private MarioStateEnum currState = MarioStateEnum.RightStill;
    private MarioPowerupEnum currPowerup = MarioPowerupEnum.Base;

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
    public void GetPowerup()
    {

    }
}

