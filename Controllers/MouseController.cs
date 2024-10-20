using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class MouseController : IController
{
    Dictionary<Rectangle, ICommand> ClickRegions;
    MouseState previousMouseState;

    public MouseController()
    {
        ClickRegions = new Dictionary<Rectangle, ICommand>();
        previousMouseState = Mouse.GetState();
    }

    public void AddCommand(Rectangle region, ICommand command)
    {
        ClickRegions.Add(region, command);
    }

    public void Update()
    {
        MouseState currentMouseState = Mouse.GetState();
        if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
        {
            Point mousePosition = currentMouseState.Position;

            foreach (var region in ClickRegions)
            {
                if (region.Key.Contains(mousePosition))
                {
                    region.Value.Execute();
                }
            }
        }

        previousMouseState = currentMouseState;
    }
}