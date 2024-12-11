using System;
using Microsoft.Xna.Framework;

public class FollowCamera
{
    public Vector2 position;
    private Vector2 initialPosition;
    private Vector2 lowerPosition;
    private float smoothSpeed = 0.1f;

    public FollowCamera(Vector2 position)
    {
        this.position = position;
        this.initialPosition = position;
        this.lowerPosition = new Vector2(100, 200);
    }

    public void Follow(Mario mario, Luigi luigi, Vector2 screenSize, float mapWidth)
    {
        float screenCenter = position.X + (screenSize.X / 2);

        float targetX;
        if (mario.marioPosition.X > screenCenter && mario.marioPosition.X > luigi.luigiPosition.X)
        {
            targetX = mario.marioPosition.X - (screenSize.X / 2);
        }
        else if (luigi.luigiPosition.X > screenCenter)
        {
            targetX = luigi.luigiPosition.X - (screenSize.X / 2);
        }
        else
        {
            targetX = mario.marioPosition.X - (screenSize.X / 2);
        }

        position.X = MathHelper.Lerp(position.X, targetX, smoothSpeed);
        position.X = Math.Clamp(position.X, 0, mapWidth - screenSize.X);


        if (mario.marioPosition.X < 3)
        {
            mario.marioPosition.X = mario.marioPosition.X + 3;
        }
        if (luigi.luigiPosition.X < 3)
        {
            luigi.luigiPosition.X = luigi.luigiPosition.X + 3;
        }
    }

    public void Reset()
    {
        position = initialPosition;
    }

    public void SetYPosition()
    {
        lowerPosition = new Vector2(0, 480);
        position = lowerPosition;
    }

    public void setLowerCamera()
    {
        position.Y = 1000;
        Console.WriteLine("Camera Moved");
    }

    public Matrix GetViewMatrix()
    {
        return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
    }
}
