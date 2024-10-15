using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

//Was UnknownBlockSprite
public class BlockInteractions
{
    private Mario mario;
    private UnknownBlockSprite block;
    private bool blockMovingUp = false;
    private float moveAmount = 16f;  // How much the block moves up
    private float moveSpeed = 100f;  // Speed of block movement
    private float blockInitialY;
    private double blockMoveTimer = 0;

    public BlockInteractions(Mario mario, UnknownBlockSprite block)
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
            // Check if Mario is hitting the bottom of the block while jumping upward
            if (marioRect.Bottom >= blockRect.Top && marioRect.Top < blockRect.Top && MarioIsMovingUp())
            {
                // Stop Mario's upward velocity (set Y velocity to 0)
                StopMarioVerticalMovement();

                // Trigger block to move upwards
                blockMovingUp = true;
                blockMoveTimer = 0;
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

    // Stop Mario's vertical movement
    private void StopMarioVerticalMovement()
    {
        mario.marioVelocity.Y = 0;  // Set Mario's upward velocity to 0
    }

    // Move block upwards
    private void MoveBlockUp(float elapsedTime)
    {
        Rectangle blockRect = block.GetDestination();
        blockRect.Y -= (int)(moveSpeed * elapsedTime);  // Move block up
        block.destinationRectangle = blockRect;  // Assuming there's a SetPosition method in block
    }

    // Move block downwards
    private void MoveBlockDown(float elapsedTime)
    {
        Rectangle blockRect = block.GetDestination();
        blockRect.Y += (int)(moveSpeed * elapsedTime);  // Move block down
        block.destinationRectangle = blockRect;  // Assuming there's a SetPosition method in block
    }

    // Reset block to its initial Y position
    private void ResetBlockPosition()
    {
        Rectangle blockRect = block.GetDestination();
        blockRect.Y = (int)blockInitialY;
        block.destinationRectangle = blockRect;  // Assuming there's a SetPosition method in block
    }
}

