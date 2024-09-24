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
    void Walk();
    void Run();
    void Swim();
    void Turn();
    void GetPowerup();
    void Crouch();
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
        switch (currPowerup)
        {
            case MarioPowerupEnum.Fire:
                 currPowerup = MarioPowerupEnum.Big;
                 break;     
            case MarioPowerupEnum.Big:   
                 currPowerup = MarioPowerupEnum.Base;
                 break;       
            case MarioPowerupEnum.Base:
                
            default:
                //die
                currState = MarioStateEnum.Dead;
                break;
        }
    }
    public void Jump()
    {
        switch (currState)
        {
            case MarioStateEnum.LeftStill:
            case MarioStateEnum.LeftWalk:
            case MarioStateEnum.LeftRun:
            case MarioStateEnum.LeftTurning:
                currState = MarioStateEnum.LeftJump;
                break;
            case MarioStateEnum.RightStill:
            case MarioStateEnum.RightWalk:
            case MarioStateEnum.RightRun:
            case MarioStateEnum.RightTurning:
                currState = MarioStateEnum.RightJump;
                break;
            default:
                break;
        }
    }
    public void Update()
    {

    }
    public void Walk()
    {

    }
    public void Run()
    {

    }
    public void Swim()
    {

    }
    public void Turn()
    {

    }
    public void GetPowerup()
    {

    }
    public void Crouch()
    {
        switch (currState)
        {
            case MarioStateEnum.LeftStill:
            case MarioStateEnum.LeftWalk:
            case MarioStateEnum.LeftRun:
            case MarioStateEnum.LeftTurning:
                currState = MarioStateEnum.LeftCrouch;
                break;
            case MarioStateEnum.RightStill:
            case MarioStateEnum.RightWalk:
            case MarioStateEnum.RightRun:
            case MarioStateEnum.RightTurning:
                currState = MarioStateEnum.RightCrouch;
                break;
            default:
                break;

        }
    }
}

