using Microsoft.Xna.Framework.Media;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CardCommand : ICommand
{
    private Game1 game;
    private BlackJackStateMachine blackJackStateMachine;

    public CardCommand(BlackJackStateMachine blackJackStateMachine)
    {
        this.blackJackStateMachine = blackJackStateMachine;
    }

    public void Execute()
    {
        blackJackStateMachine.playACard();
    }
}
