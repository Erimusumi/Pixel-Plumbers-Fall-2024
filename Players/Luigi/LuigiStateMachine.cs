using System;
using System.Configuration.Assemblies;

public class LuigiStateMachine
{
    public enum LuigiGameState { Small, Big, Fire, Star }
    public enum LuigiFaceState { Left, Right }
    public enum LuigiMoveState { Idle, Moving, Jumping, Crouching, Turning, Dead }

    public LuigiGameState CurrentGameState { get; private set; }
    public LuigiFaceState CurrentFaceState { get; private set; }
    public LuigiMoveState CurrentMoveState { get; private set; }

    public bool _HasStar;
    public bool luigiWins;
    public bool isVisible;

    public LuigiStateMachine()
    {
        CurrentGameState = LuigiGameState.Small;
        CurrentFaceState = LuigiFaceState.Right;
        CurrentMoveState = LuigiMoveState.Idle;
        _HasStar = false;
        isVisible = true;
        luigiWins = false;
    }

    public void SetLuigiSmall()
    {
        CurrentGameState = LuigiGameState.Small;
    }

    public void SetLuigiBig()
    {
        CurrentGameState = LuigiGameState.Big;
    }

    public void SetLuigiFire()
    {
        CurrentGameState = LuigiGameState.Fire;
    }

    public void SetLuigiIdle()
    {
        CurrentMoveState = LuigiMoveState.Idle;
    }

    public void SetLuigiMoving()
    {
        CurrentMoveState = LuigiMoveState.Moving;
    }

    public void SetLuigiJumping()
    {
        CurrentMoveState = LuigiMoveState.Jumping;
    }

    public void SetLuigiCrouching()
    {
        CurrentMoveState = LuigiMoveState.Crouching;
    }

    public void SetLuigiTurning()
    {
        CurrentMoveState = LuigiMoveState.Turning;
    }

    public void SetLuigiDead()
    {
        CurrentMoveState = LuigiMoveState.Dead;
    }
    public void SetLuigiWins()
    {
        luigiWins = true;
    }
    public void SetLuigiLeft()
    {
        CurrentFaceState = LuigiFaceState.Left;
    }

    public void SetLuigiRight()
    {
        CurrentFaceState = LuigiFaceState.Right;
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
        if (CurrentMoveState == LuigiMoveState.Jumping)
        {
            CurrentMoveState = LuigiMoveState.Idle;
        }
    }

    public bool IsCrouching()
    {
        return CurrentMoveState == LuigiMoveState.Crouching;
    }

    public bool IsJumping()
    {
        return CurrentMoveState == LuigiMoveState.Jumping;
    }

    public bool IsTurning()
    {
        return CurrentMoveState == LuigiMoveState.Turning;
    }

    public bool IsRight()
    {
        return CurrentFaceState == LuigiFaceState.Right;
    }

    public bool IsMoving()
    {
        return CurrentMoveState == LuigiMoveState.Moving;
    }

    public bool IsDead()
    {
        return CurrentMoveState == LuigiMoveState.Dead;
    }

    public bool IsFire()
    {
        return CurrentGameState == LuigiGameState.Fire;
    }

    public void Reset()
    {
        CurrentGameState = LuigiGameState.Small;
        CurrentFaceState = LuigiFaceState.Right;
        CurrentMoveState = LuigiMoveState.Idle;
        luigiWins = false;
    }

    public bool Wins()
    {
        return luigiWins;
    }

    public bool IsVisible()
    {
        return isVisible;
    }

    public void MakeVisible()
    {
        isVisible = true;
    }

    public void MakeInvisible()
    {
        isVisible = false;
    }

    public bool IsSmall()
    {
        return CurrentGameState == LuigiGameState.Small;
    }
    
    public bool IsBig()
    {
        return CurrentGameState == LuigiGameState.Big;
    }
}
