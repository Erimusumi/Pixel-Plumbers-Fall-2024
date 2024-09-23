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
}

public class MarioState : IMarioState
{
    private enum MarioStateEnum {LeftStill, RightStill, LeftWalk, RightWalk, LeftRun, 
        RightRun, LeftJump, RightJump, LeftCrouch, RightCrouch, LeftSwim, RightSwim };
    private MarioStateEnum currState = MarioStateEnum.RightStill;
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

