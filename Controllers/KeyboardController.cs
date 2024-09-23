using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System.Collections.Generic;

public class KeyboardController
{
    private Dictionary<Keys, ICommand> keyBindings;
    public KeyboardController()
    {
        keyBindings = new Dictionary<Keys, ICommand>();
    }

    public void BindKey(Keys key, ICommand command)
    {
        keyBindings[key] = command;
    }

    public void ProcessInput(KeyboardState keyboardState, Game1 game)
    {
        foreach (var binding in keyBindings)
        {
            if (keyboardState.IsKeyDown(binding.Key))
            {
                binding.Value.Execute();
            }
        }
    }
}
