public class MarioStateMachine
{
    public enum MarioGameState { Small, Big, Fire }
    public enum MarioFaceState { Left, Right }
    public enum MarioMoveState { Idle, Moving, Jumping, Crouching }

    public MarioGameState CurrentGameState { get; private set; }
    public MarioFaceState CurrentFaceState { get; private set; }
    public MarioMoveState CurrentMoveState { get; private set; }

    public MarioStateMachine()
    {
        // Initialize default state
        CurrentGameState = MarioGameState.Big;
        CurrentFaceState = MarioFaceState.Right;
        CurrentMoveState = MarioMoveState.Idle;
    }

    public void SetGameState(MarioGameState gameState)
    {
        CurrentGameState = gameState;
    }

    public void SetFaceState(MarioFaceState faceState)
    {
        CurrentFaceState = faceState;
    }

    public void SetMoveState(MarioMoveState moveState)
    {
        if (moveState != MarioMoveState.Crouching || CurrentMoveState != MarioMoveState.Jumping)
        {
            CurrentMoveState = moveState;
        }
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

    // Reset Mario state machine to its initial state
    public void Reset()
    {
        CurrentGameState = MarioGameState.Big;  // Reset to 'Big' state
        CurrentFaceState = MarioFaceState.Right; // Reset to facing right
        CurrentMoveState = MarioMoveState.Idle;  // Reset to idle movement state
    }
}
