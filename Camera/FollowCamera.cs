using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FollowCamera
{
    public Vector2 position;

    public FollowCamera(Vector2 position)
    {
        this.position = position;
    }

    public void Follow(Vector2 marioPosition, Vector2 screenSize)
    {
        float targetX = marioPosition.X - (screenSize.X / 2);
        float targetY = marioPosition.Y - (screenSize.Y / 2);

        position.X = Math.Max(targetX, 0);
        position.Y = Math.Max(targetY, 0);

        if (marioPosition.X > position.X + (screenSize.X / 2))
        {
            position.X = marioPosition.X - (screenSize.X / 2);
        }
        if (marioPosition.Y > position.Y + (screenSize.Y / 2))
        {
            position.Y = marioPosition.Y - (screenSize.Y / 2);
        }
    }
    public void SetCameraY(float y)
    {
        position.Y = y;
    }
    public Matrix GetViewMatrix()
    {
        return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
    }
}
