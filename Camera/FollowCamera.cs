using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FollowCamera
{
    public Vector2 position;
    private float smoothSpeed = 0.1f; // Adjust this value to control smoothness

    public FollowCamera(Vector2 position)
    {
        this.position = position;
    }

    public void Follow(Vector2 marioPosition, Vector2 screenSize)
    {
        // Calculate the target camera position
        float targetX = marioPosition.X - (screenSize.X / 2);
        float targetY = marioPosition.Y - (screenSize.Y / 2);

        // Smoothly interpolate between current position and target position
        position.X = MathHelper.Lerp(position.X, targetX, smoothSpeed);
        position.Y = MathHelper.Lerp(position.Y, targetY, smoothSpeed);

        // Clamp the camera position to prevent going out of bounds
        position.X = Math.Max(0, position.X);
        position.Y = Math.Max(0, position.Y);
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