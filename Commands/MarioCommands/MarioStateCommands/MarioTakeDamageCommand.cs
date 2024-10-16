public class MarioTakeDamageCommand : IPlayerCommand
{
    private Mario mario;

    public MarioTakeDamageCommand(Mario mario)
    {
        this.mario = mario;
    }
    public void Execute()
    {
        mario.MarioTakeDamage();
    }

    public void Unexecute()
    {
    }
}
