using Microsoft.Xna.Framework.Graphics;


public class MarioMoveLeftCommand : ICommand
{
    private Mario mario;

    public MarioMoveLeftCommand(Mario mario)
    {
        this.mario = mario;
    }
    public void Execute()
    {
        mario.MoveLeft();
    }
}
