using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FollowCamera
{
    public Vector2 position;

    public FollowCamera(Vector2 position)
    {
        this.position = position;
    }

    public void Follow(Rectangle target, Vector2 screenSize)
    {
        // Update camera position only if the target (Mario) is moving to the right
        if (target.X > position.X + (screenSize.X / 2))
        {
            position.X = target.X - (screenSize.X / 2 - target.Width / 2);
        }

        // Keep the Y position fixed at 0
        position.Y = 0;
    }

    // Method to get the view matrix
    public Matrix GetViewMatrix()
    {
        return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
    }
}
