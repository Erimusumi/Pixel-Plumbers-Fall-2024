public class LuigiPowerUpCommand : IPlayerCommand
{
    private Luigi luigi;

    public LuigiPowerUpCommand(Luigi luigi)
    {
        this.luigi = luigi;
    }

    public void Execute()
    {
        luigi.LuigiPowerUp();
    }

    public void Unexecute()
    {
    }
}
