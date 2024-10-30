using Microsoft.Xna.Framework.Media;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using System.Threading;

public class CardCommand : ICommand
{
    private Game1 game;
    private BlackJackStateMachine blackJackStateMachine;
    private SoundEffect fwip;

    public CardCommand(BlackJackStateMachine blackJackStateMachine)
    {
        this.blackJackStateMachine = blackJackStateMachine;
        this.fwip = blackJackStateMachine.effect();
    }

    public void Execute()
    {
        fwip.Play();
        Thread.Sleep(200);
        blackJackStateMachine.playACard();
    }
}
