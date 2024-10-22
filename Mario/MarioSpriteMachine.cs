using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024
{
    public class MarioSpriteMachine
    {
        private static IMarioSprite lastValidSprite;

        public static IMarioSprite UpdateMarioSprite(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            IMarioSprite newSprite = GetSpriteForFaceState(marioStateMachine, texture);

            if (lastValidSprite != null && newSprite != null && newSprite.GetType() == lastValidSprite.GetType())
            {
                return lastValidSprite;
            }

            if (newSprite != null)
            {
                lastValidSprite = newSprite;
                return newSprite;
            }

            return lastValidSprite ?? new IdleLeftBigMario(texture);
        }

        private static IMarioSprite GetSpriteForFaceState(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentFaceState)
            {
                case MarioStateMachine.MarioFaceState.Right:
                    return GetSpriteForGameStateRight(marioStateMachine, texture);
                case MarioStateMachine.MarioFaceState.Left:
                    return GetSpriteForGameStateLeft(marioStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSpriteForGameStateRight(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentGameState)
            {
                case MarioStateMachine.MarioGameState.Small:
                    return GetSmallMarioSpriteRight(marioStateMachine, texture);
                case MarioStateMachine.MarioGameState.Big:
                    return GetBigMarioSpriteRight(marioStateMachine, texture);
                case MarioStateMachine.MarioGameState.Fire:
                    return GetFireMarioSpriteRight(marioStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSpriteForGameStateLeft(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentGameState)
            {
                case MarioStateMachine.MarioGameState.Small:
                    return GetSmallMarioSpriteLeft(marioStateMachine, texture);
                case MarioStateMachine.MarioGameState.Big:
                    return GetBigMarioSpriteLeft(marioStateMachine, texture);
                case MarioStateMachine.MarioGameState.Fire:
                    return GetFireMarioSpriteLeft(marioStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSmallMarioSpriteRight(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case MarioStateMachine.MarioMoveState.Idle:
                    return new IdleRightSmallMario(texture);
                case MarioStateMachine.MarioMoveState.Moving:
                    return new MovingRightSmallMario(texture);
                case MarioStateMachine.MarioMoveState.Jumping:
                    return new JumpingRightSmallMario(texture);
                case MarioStateMachine.MarioMoveState.Turning:
                    return new TurningRightSmallMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetBigMarioSpriteRight(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case MarioStateMachine.MarioMoveState.Idle:
                    return new IdleRightBigMario(texture);
                case MarioStateMachine.MarioMoveState.Moving:
                    return new MovingRightBigMario(texture);
                case MarioStateMachine.MarioMoveState.Jumping:
                    return new JumpingRightBigMario(texture);
                case MarioStateMachine.MarioMoveState.Crouching:
                    return new CrouchRightBigMario(texture);
                case MarioStateMachine.MarioMoveState.Turning:
                    return new TurningRightBigMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetFireMarioSpriteRight(MarioStateMachine marioStateMachine, Texture2D texture)
        {
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
                case MarioStateMachine.MarioMoveState.Turning:
                    return new TurningRightFireMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSmallMarioSpriteLeft(MarioStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case MarioStateMachine.MarioMoveState.Idle:
                    return new IdleLeftSmallMario(texture);
                case MarioStateMachine.MarioMoveState.Moving:
                    return new MovingLeftSmallMario(texture);
                case MarioStateMachine.MarioMoveState.Jumping:
                    return new JumpingLeftSmallMario(texture);
                case MarioStateMachine.MarioMoveState.Turning:
                    return new TurningLeftSmallMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetBigMarioSpriteLeft(MarioStateMachine marioStateMachine, Texture2D texture)
        {
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
                case MarioStateMachine.MarioMoveState.Turning:
                    return new TurningLeftBigMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetFireMarioSpriteLeft(MarioStateMachine marioStateMachine, Texture2D texture)
        {
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
                case MarioStateMachine.MarioMoveState.Turning:
                    return new TurningLeftFireMario(texture);
                default:
                    return null;
            }
        }
    }
}
