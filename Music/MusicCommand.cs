using Microsoft.Xna.Framework.Media;
using Pixel_Plumbers_Fall_2024;

public class MusicCommand : ICommand
{
    private Game1 game;
    private MusicStateMachine MusicStateMachine;
    private Song song;

    public MusicCommand(MusicStateMachine MusicStateMachine)
    {
        this.MusicStateMachine = MusicStateMachine;
        song = MusicStateMachine.current();
    }

    public void Execute()
    {
        song = MusicStateMachine.NextSong();
        MediaPlayer.Play(song);
        MediaPlayer.IsRepeating = true;
    }
}
