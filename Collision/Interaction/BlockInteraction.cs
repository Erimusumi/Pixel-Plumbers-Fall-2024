using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BlockInteraction
{
    private Mario mario;
    private BrokenBrickSprite block;
    private bool blockMovingUp = false;
    private float moveAmount = 16f;  // How much the block moves up
    private float moveSpeed = 100f;  // Speed of block movement
    private float blockInitialY;
    private double blockMoveTimer = 0;

    public BlockInteraction(Mario mario, BrokenBrickSprite block)
    {
        this.mario = mario;
        this.block = block;
        blockInitialY = block.GetDestination().Y; // Store the initial Y position of the block
    }

    // Method to handle Mario and Block collision
    public void HandleCollision(GameTime gameTime)
    {
        Rectangle marioRect = mario.GetDestination();
        Rectangle blockRect = block.GetDestination();

        // Check if Mario is intersecting with the block
        if (marioRect.Intersects(blockRect))
        {
            // Handle bottom collision (Mario hits the bottom of the block while jumping upward)
            if (marioRect.Bottom >= blockRect.Top && marioRect.Top < blockRect.Top && MarioIsMovingUp())
            {
                // Stop Mario's upward velocity (set Y velocity to 0)
                StopMarioVerticalMovement();

                // Trigger block to move upwards
                blockMovingUp = true;
                blockMoveTimer = 0;
            }

            // Handle left-side collision (Mario hits the left side of the block)
            if (marioRect.Right >= blockRect.Left && marioRect.Left < blockRect.Left && MarioIsMovingRight())
            {
                // Stop Mario from moving right
                StopMarioHorizontalMovement();
            }

            // Handle right-side collision (Mario hits the right side of the block)
            if (marioRect.Left <= blockRect.Right && marioRect.Right > blockRect.Right && MarioIsMovingLeft())
            {
                // Stop Mario from moving left
                StopMarioHorizontalMovement();
            }
        }

        // Handle block movement if it was hit
        if (blockMovingUp)
        {
            blockMoveTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Move block up for 0.1 seconds, then back down
            if (blockMoveTimer < 0.1f)
            {
                MoveBlockUp((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else if (blockMoveTimer < 0.2f)
            {
                MoveBlockDown((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                blockMovingUp = false;
                ResetBlockPosition();  // Reset block to its initial position
            }
        }
    }

    // Check if Mario is moving upward (negative Y velocity)
    private bool MarioIsMovingUp()
    {
        return mario.marioVelocity.Y < 0;
    }

    // Check if Mario is moving right (positive X velocity)
    private bool MarioIsMovingRight()
    {
        return mario.marioVelocity.X > 0;
    }

    // Check if Mario is moving left (negative X velocity)
    private bool MarioIsMovingLeft()
    {
        return mario.marioVelocity.X < 0;
    }

    // Stop Mario's vertical movement
    private void StopMarioVerticalMovement()
    {
        mario.marioVelocity.Y = 0;  // Set Mario's upward velocity to 0
    }

    // Stop Mario's horizontal movement (for side collisions)
    private void StopMarioHorizontalMovement()
    {
        mario.marioVelocity.X = 0;  // Set Mario's horizontal velocity to 0
    }

    // Move block upwards
    private void MoveBlockUp(float elapsedTime)
    {
        Rectangle blockRect = block.GetDestination();
        blockRect.Y -= (int)(moveSpeed * elapsedTime);  // Move block up
        block.destinationRectangle = blockRect;  // Update block position
    }

    // Move block downwards
    private void MoveBlockDown(float elapsedTime)
    {
        Rectangle blockRect = block.GetDestination();
        blockRect.Y += (int)(moveSpeed * elapsedTime);  // Move block down
        block.destinationRectangle = blockRect;  // Update block position
    }

    // Reset block to its initial Y position
    private void ResetBlockPosition()
    {
        Rectangle blockRect = block.GetDestination();
        blockRect.Y = (int)blockInitialY;
        block.destinationRectangle = blockRect;  // Update block position
    }
}


