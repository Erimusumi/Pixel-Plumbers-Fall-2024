using Microsoft.Xna.Framework.Graphics;


public class MarioMoveRightCommand : ICommand
{
    private Mario mario;

    public MarioMoveRightCommand(Mario mario)
    {
        this.mario = mario;
    }
    public void Execute()
    {
        mario.MoveRight();
    }
}
