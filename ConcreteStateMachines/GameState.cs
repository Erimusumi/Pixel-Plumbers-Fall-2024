public class GameState
{
    public enum GameStates { Menu, Paused, Alive, Dead, GameOver }

    GameStates MyGameState = GameStates.Menu;
    public void SetGameState(GameStates state)
    {
        if (state != MyGameState)
        {
            MyGameState = state;
            switch (state)
            {
                case GameStates.Menu:
                    // Show menu window or overlay here if not already open
                    // Pause game world time flow
                    // Start potential transitions here
                    break;
                case GameStates.Paused:
                    // Resume game world time flow
                    break;
                case GameStates.Alive:
                    // Pause game world time flow
                    // Maybe show game paused UI
                    break;
                case GameStates.GameOver:
                    // Show game over screen or overlay
                    // Pause game world time flow (not strictly)
                    // Any interaction from player leads to state e.g. GameStates.Menu
                    break;
                default:
                    break;
            }
        }
    }
}