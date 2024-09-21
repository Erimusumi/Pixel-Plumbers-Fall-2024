using static Pixel_Plumbers_Fall_2024.Game1;

public class GameState
{
    private GameStates MyGameState = GameStates.MainMenu;
    public void SetGameState(GameStates state)
    {
        if (state != MyGameState)
        {
            MyGameState = state;
            switch (state)
            {
                case GameStates.MainMenu:

                    break;
                case GameStates.FaceLeft:

                    break;
                case GameStates.FaceRight:

                    break;
                case GameStates.GameOver:

                    break;
                default:
                    break;
            }
        }
    }
}