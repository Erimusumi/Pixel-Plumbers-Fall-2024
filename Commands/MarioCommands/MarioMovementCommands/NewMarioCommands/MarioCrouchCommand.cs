public class MarioCrouchCommand : ICommand
{
    private Mario mario;

    public MarioCrouchCommand(Mario mario)
    {
        this.mario = mario;
    }

    public void Execute()
    {
        mario.Crouch();
    }
}
