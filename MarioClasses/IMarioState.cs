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
    void Stop();
    //Seperate walk and run might not be necessary, since I think the sprites are the same
    void Walk();
    void Run();
    void Swim();
    void Turn();
    void GetPowerup();
    void Crouch();
}

public class MarioState : IMarioState
{
    private enum MarioStateEnum {Still, Walk, Run, Jump, Crouch, Swim, Turning, Dead };
    private enum MarioPowerupEnum {Base, Big, Fire };

    private enum MarioDirectionEnum {Left, Right };


    private MarioStateEnum currState = MarioStateEnum.Still;
    private MarioPowerupEnum currPowerup = MarioPowerupEnum.Base;
    private MarioDirectionEnum currDirection = MarioDirectionEnum.Right;

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
        currState = MarioStateEnum.Jump;
    }
    public void Update()
    {

    }
    public void Stop()
    {
        currState = MarioStateEnum.Still;
    }
    public void Walk()
    {
        currState = MarioStateEnum.Walk;
    }
    public void Run()
    {
        currState = MarioStateEnum.Run;
    }
    public void Swim()
    {
        currState = MarioStateEnum.Swim;
    }
    public void Turn()
    {
        switch (currDirection)
        {
            case MarioDirectionEnum.Left:
                currDirection = MarioDirectionEnum.Right;
                break;
            case MarioDirectionEnum.Right:
                currDirection = MarioDirectionEnum.Left;
                break;
            default:
                break;
        }
    }
    public void GetPowerup()
    {

    }
    public void Crouch()
    {
        currState = MarioStateEnum.Crouch;
    }
}

