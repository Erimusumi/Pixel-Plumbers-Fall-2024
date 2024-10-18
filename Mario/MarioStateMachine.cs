using System;
using System.Configuration.Assemblies;

public class MarioStateMachine
{
    public enum MarioGameState { Small, Big, Fire }
    public enum MarioFaceState { Left, Right }
    public enum MarioMoveState { Idle, Moving, Jumping, Crouching, Turning }

    public MarioGameState CurrentGameState { get; private set; }
    public MarioFaceState CurrentFaceState { get; private set; }
    public MarioMoveState CurrentMoveState { get; private set; }

    public bool _HasStar;

    public MarioStateMachine()
    {
        CurrentGameState = MarioGameState.Small;
        CurrentFaceState = MarioFaceState.Right;
        CurrentMoveState = MarioMoveState.Idle;
        _HasStar = false;
    }

    public void SetMarioSmall()
    {
        CurrentGameState = MarioGameState.Small;
    }

    public void SetMarioBig()
    {
        CurrentGameState = MarioGameState.Big;
    }

    public void SetMarioFire()
    {
        CurrentGameState = MarioGameState.Fire;
    }

    public void SetMarioIdle()
    {
        CurrentMoveState = MarioMoveState.Idle;
    }

    public void SetMarioMoving()
    {
        CurrentMoveState = MarioMoveState.Moving;
    }

    public void SetMarioJumping()
    {
        CurrentMoveState = MarioMoveState.Jumping;
    }

    public void SetMarioCrouching()
    {
        CurrentMoveState = MarioMoveState.Crouching;
    }

    public void SetMarioTurning()
    {
        CurrentMoveState = MarioMoveState.Turning;
    }

    public void SetMarioLeft()
    {
        CurrentFaceState = MarioFaceState.Left;
    }

    public void SetMarioRight()
    {
        CurrentFaceState = MarioFaceState.Right;
    }
    public Boolean HasStar()
    {
        return _HasStar;
    }

    public void SetStar()
    {
        _HasStar = true;
        //test, remove later
        System.Diagnostics.Debug.WriteLine("Star Collected");
    }

    public void RemoveStar()
    {
        _HasStar = false;
    }

    public void UpdateMoveStateForJumping()
    {
        if (CurrentMoveState == MarioMoveState.Jumping)
        {
            CurrentMoveState = MarioMoveState.Idle;
        }
    }

    public bool IsCrouching()
    {
        return CurrentMoveState == MarioMoveState.Crouching;
    }

    public bool IsJumping()
    {
        return CurrentMoveState == MarioMoveState.Jumping;
    }

    public bool IsTurning()
    {
        return CurrentMoveState == MarioMoveState.Turning;
    }

    public void Reset()
    {
        CurrentGameState = MarioGameState.Small;
        CurrentFaceState = MarioFaceState.Right;
        CurrentMoveState = MarioMoveState.Idle;
    }
}
