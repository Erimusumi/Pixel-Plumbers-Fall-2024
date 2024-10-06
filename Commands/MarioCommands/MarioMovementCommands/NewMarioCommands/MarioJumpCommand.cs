public class MarioJumpCommand : ICommand
{
    private Mario mario;

    public MarioJumpCommand(Mario mario)
    {
        this.mario = mario;
    }

    public void Execute()
    {
        mario.Jump();
    }
}