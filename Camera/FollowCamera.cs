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

    public void Follow(Vector2 marioPosition, Vector2 screenSize, float mapWidth)
    {
        // Calculate the target camera position (only X-axis)
        float targetX = marioPosition.X - (screenSize.X / 2);

        // Smoothly interpolate between current position and target position (only X)
        position.X = MathHelper.Lerp(position.X, targetX, smoothSpeed);

        // Clamp the camera position to prevent going out of bounds
        position.X = Math.Max(0, position.X); // Prevent going left of 0
        position.X = Math.Min(position.X, mapWidth - screenSize.X); // Prevent going beyond map width

        // Set Y to the center of the screen height
        position.Y = (screenSize.Y / 2) - (screenSize.Y / 2);
    }

    public Matrix GetViewMatrix()
    {
        return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
    }
}