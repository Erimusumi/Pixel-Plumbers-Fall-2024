using Microsoft.Xna.Framework.Media;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using System.Threading;

public class StandCommand : ICommand
{
    private BlackJackStateMachine blackJackStateMachine;
    private SoundEffect fwip;

    public StandCommand(BlackJackStateMachine blackJackStateMachine)
    {
        this.blackJackStateMachine = blackJackStateMachine;
        this.fwip = blackJackStateMachine.effect();
    }

    public void Execute()
    {
        blackJackStateMachine.Stand();
        if (blackJackStateMachine.StandNumber() == 1)
        {
            fwip.Play();
            Thread.Sleep(200);
            blackJackStateMachine.playACard();
        }
    }
}
