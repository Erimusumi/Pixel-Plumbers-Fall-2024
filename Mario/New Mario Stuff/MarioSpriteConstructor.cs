using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024;

public class MarioSpriteConstructor
{

    public static IMarioSprite ConstructMarioSprite(MarioStateMachine marioStateMachine, Texture2D texture)
    {
        switch (marioStateMachine.CurrentFaceState)
        {
            case MarioStateMachine.MarioFaceState.Right:
                switch (marioStateMachine.CurrentGameState)
                {
                    case MarioStateMachine.MarioGameState.Small:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                return new IdleRightSmallMario(texture);
                            case MarioStateMachine.MarioMoveState.Moving:
                                return new MovingRightSmallMario(texture);
                            case MarioStateMachine.MarioMoveState.Jumping:
                                return new JumpingRightSmallMario(texture);

                        }
                        break;

                    case MarioStateMachine.MarioGameState.Big:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                return new IdleRightBigtMario(texture);
                            case MarioStateMachine.MarioMoveState.Moving:
                                return new MovingRightBigMario(texture);
                            case MarioStateMachine.MarioMoveState.Jumping:
                                return new JumpingRightBigMario(texture);
                            case MarioStateMachine.MarioMoveState.Crouching:
                                return new CrouchRightBigMario(texture);
                        }
                        break;

                    case MarioStateMachine.MarioGameState.Fire:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                return new IdleRightFireMario(texture);
                            case MarioStateMachine.MarioMoveState.Moving:
                                return new MovingRightFireMario(texture);
                            case MarioStateMachine.MarioMoveState.Jumping:
                                return new JumpingRightFireMario(texture);
                            case MarioStateMachine.MarioMoveState.Crouching:
                                return new CrouchRightFireMario(texture);
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
                                return new IdleLeftSmallMario(texture);
                            case MarioStateMachine.MarioMoveState.Moving:
                                return new MovingLeftSmallMario(texture);
                            case MarioStateMachine.MarioMoveState.Jumping:
                                return new JumpingLeftSmallMario(texture);

                        }
                        break;

                    case MarioStateMachine.MarioGameState.Big:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                return new IdleLeftBigMario(texture);
                            case MarioStateMachine.MarioMoveState.Moving:
                                return new MovingLeftBigMario(texture);
                            case MarioStateMachine.MarioMoveState.Jumping:
                                return new JumpingLeftBigMario(texture);
                            case MarioStateMachine.MarioMoveState.Crouching:
                                return new CrouchLeftBigMario(texture);
                        }
                        break;

                    case MarioStateMachine.MarioGameState.Fire:
                        switch (marioStateMachine.CurrentMoveState)
                        {
                            case MarioStateMachine.MarioMoveState.Idle:
                                return new IdleLeftFireMario(texture);
                            case MarioStateMachine.MarioMoveState.Moving:
                                return new MovingLeftFireMario(texture);
                            case MarioStateMachine.MarioMoveState.Jumping:
                                return new JumpingLeftFireMario(texture);
                            case MarioStateMachine.MarioMoveState.Crouching:
                                return new CrouchLeftFireMario(texture);
                        }
                        break;
                }
                break;
        }
        return new IdleLeftBigMario(texture);
    }
}
