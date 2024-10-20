using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

public class BlockInteraction
{
    private Mario mario;
    private IBlock block;
    private Rectangle marioRect;
    private Rectangle blockRect;

    bool hitTop = false;
    bool hitBottom = false;
    bool hitLeft = false;
    bool hitRight = false;

    public BlockInteraction(Mario mario, IBlock block)
    {
        this.mario = mario;
        this.block = block;
        marioRect = mario.GetDestination();
        blockRect = block.GetDestination();
    }

    // Method to handle Mario and Block collision
    public void update()
    {
        collisionSide();

        // Handle horizontal collision
        if (hitLeft || hitRight)
        {
            StopMarioHorizontalMovement();

            // Adjust Mario's position to prevent overlap
            if (hitLeft)
            {
                SetPosition(new Vector2(blockRect.Left - marioRect.Width, marioRect.Y)); // Align Mario's right side with block's left
            }
            else if (hitRight)
            {
                SetPosition(new Vector2(blockRect.Right, marioRect.Y)); // Align Mario's left side with block's right
            }
        }

        // Handle vertical collision
        if (hitBottom)
        {
            StopMarioVerticalMovement();  // Stop Mario's upward movement
            // Optionally adjust Mario's position to sit on top of the block
            SetPosition(new Vector2(marioRect.X, blockRect.Top - marioRect.Height));
        }
        else if (hitTop)
        {
            // You can implement what happens when Mario hits the top if needed
        }

        // Reset hit flags for the next update
        ResetHitFlags();
        Debug.Write("BlockInteraction update method works");
        mario.marioVelocity.X = 0;
    }

    private void collisionSide()
    {
        marioRect = mario.GetDestination(); // Update Mario's rectangle every time
        blockRect = block.GetDestination(); // Update block's rectangle every time

        if (marioRect.Bottom > blockRect.Top && marioRect.Top < blockRect.Top && mario.marioVelocity.Y < 0)
        {
            hitBottom = true;    // Mario hit the bottom of the block
        }
        if (marioRect.Top < blockRect.Bottom && marioRect.Bottom > blockRect.Bottom && mario.marioVelocity.Y > 0)
        {
            hitTop = true; // Mario landed on top of the block
        }

        if (marioRect.Right > blockRect.Left && marioRect.Left < blockRect.Left && mario.marioVelocity.X > 0)
        {
            hitLeft = true;  // Mario hit the left side of the block
        }
        if (marioRect.Left < blockRect.Right && marioRect.Right > blockRect.Right && mario.marioVelocity.X < 0)
        {
            hitRight = true;   // Mario hit the right side of the block
        }
    }

    private void StopMarioHorizontalMovement()
    {
        mario.marioVelocity.X = 0;
    }

    private void StopMarioVerticalMovement()
    {
        // Set Mario's vertical velocity to 0
        mario.marioVelocity.Y = 0;
    }

    private void SetPosition(Vector2 newPosition)
    {
        mario.marioPosition = newPosition; // Update Mario's position
    }

    private void ResetHitFlags()
    {
        // Reset all hit flags for the next update
        hitTop = false;
        hitBottom = false;
        hitLeft = false;
        hitRight = false;
    }
}