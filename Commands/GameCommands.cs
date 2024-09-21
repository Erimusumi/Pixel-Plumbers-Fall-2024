using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Pixel_Plumbers_Fall_2024;

public class GameCommands
{
    public Game game1;
    public Dictionary<Keys, ICommand> KeyCommands { get; set; }
    public GameCommands(Game game1)
    {
        this.game1 = game1;
        KeyCommands = new Dictionary<Keys, ICommand>();
    }

}