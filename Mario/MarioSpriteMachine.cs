using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024;

public class MarioSpriteMachine
{
    private static IMarioSprite lastValidSprite;  // Store the last valid sprite

    public static IMarioSprite UpdateMarioSprite(MarioStateMachine marioStateMachine, Texture2D texture)
    {
        IMarioSprite newSprite = null;

        switch (marioStateMachine.CurrentFaceState)
        {
            case MarioStateMachine.MarioFaceState.Right:
                switch (marioStateMachine.CurrentGameState)
                {
                    case MarioStateMachine.MarioGameState.Small:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                newSprite = new IdleRightSmallMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Moving:
                                newSprite = new MovingRightSmallMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Jumping:
                                newSprite = new JumpingRightSmallMario(texture);
                                break;
                        }
                        break;

                    case MarioStateMachine.MarioGameState.Big:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                newSprite = new IdleRightBigMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Moving:
                                newSprite = new MovingRightBigMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Jumping:
                                newSprite = new JumpingRightBigMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Crouching:
                                newSprite = new CrouchRightBigMario(texture);
                                break;
                        }
                        break;

                    case MarioStateMachine.MarioGameState.Fire:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                newSprite = new IdleRightFireMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Moving:
                                newSprite = new MovingRightFireMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Jumping:
                                newSprite = new JumpingRightFireMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Crouching:
                                newSprite = new CrouchRightFireMario(texture);
                                break;
                        }
                        break;
                }
                break;

            case MarioStateMachine.MarioFaceState.Left:
                switch (marioStateMachine.CurrentGameState)
                {
                    case MarioStateMachine.MarioGameState.Small:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                newSprite = new IdleLeftSmallMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Moving:
                                newSprite = new MovingLeftSmallMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Jumping:
                                newSprite = new JumpingLeftSmallMario(texture);
                                break;
                        }
                        break;

                    case MarioStateMachine.MarioGameState.Big:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                newSprite = new IdleLeftBigMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Moving:
                                newSprite = new MovingLeftBigMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Jumping:
                                newSprite = new JumpingLeftBigMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Crouching:
                                newSprite = new CrouchLeftBigMario(texture);
                                break;
                        }
                        break;

                    case MarioStateMachine.MarioGameState.Fire:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                newSprite = new IdleLeftFireMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Moving:
                                newSprite = new MovingLeftFireMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Jumping:
                                newSprite = new JumpingLeftFireMario(texture);
                                break;
                            case MarioStateMachine.MarioMoveState.Crouching:
                                newSprite = new CrouchLeftFireMario(texture);
                                break;
                        }
                        break;
                }
                break;
        }

        if (newSprite != null)
        {
            lastValidSprite = newSprite;
            return newSprite;
        }

        if (lastValidSprite != null)
        {
            return lastValidSprite;
        }
        return new IdleLeftBigMario(texture);
    }
}
