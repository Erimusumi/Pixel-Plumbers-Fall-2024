public class LuigiTakeDamageCommand : IPlayerCommand
{
    private Luigi luigi;

    public LuigiTakeDamageCommand(Luigi luigi)
    {
        this.luigi = luigi;
    }

    public void Execute()
    {
        luigi.LuigiTakeDamage();
    }

    public void Unexecute()
    {
    }
}
