using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024
{
    public class LuigiSpriteMachine
    {
        private static IMarioSprite lastValidSprite;
        public static IMarioSprite UpdateLuigiSprite(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            IMarioSprite newSprite = null;
            if (luigiStateMachine.IsDead())
            {
                newSprite = new DeadMario(texture);
            }
            else
            {
                newSprite = GetSpriteForFaceState(luigiStateMachine, texture);
            }

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

        private static IMarioSprite GetSpriteForFaceState(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentFaceState)
            {
                case LuigiStateMachine.LuigiFaceState.Right:
                    return GetSpriteForGameStateRight(luigiStateMachine, texture);
                case LuigiStateMachine.LuigiFaceState.Left:
                    return GetSpriteForGameStateLeft(luigiStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSpriteForGameStateRight(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentGameState)
            {
                case LuigiStateMachine.LuigiGameState.Small:
                    return GetSmallLuigiSpriteRight(luigiStateMachine, texture);
                case LuigiStateMachine.LuigiGameState.Big:
                    return GetBigLuigiSpriteRight(luigiStateMachine, texture);
                case LuigiStateMachine.LuigiGameState.Fire:
                    return GetFireLuigiSpriteRight(luigiStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSpriteForGameStateLeft(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentGameState)
            {
                case LuigiStateMachine.LuigiGameState.Small:
                    return GetSmallLuigiSpriteLeft(luigiStateMachine, texture);
                case LuigiStateMachine.LuigiGameState.Big:
                    return GetBigLuigiSpriteLeft(luigiStateMachine, texture);
                case LuigiStateMachine.LuigiGameState.Fire:
                    return GetFireLuigiSpriteLeft(luigiStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSmallLuigiSpriteRight(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case LuigiStateMachine.LuigiMoveState.Idle:
                    return new IdleRightSmallMario(texture);
                case LuigiStateMachine.LuigiMoveState.Moving:
                    return new MovingRightSmallMario(texture);
                case LuigiStateMachine.LuigiMoveState.Jumping:
                    return new JumpingRightSmallMario(texture);
                case LuigiStateMachine.LuigiMoveState.Turning:
                    return new TurningLeftSmallMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetBigLuigiSpriteRight(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case LuigiStateMachine.LuigiMoveState.Idle:
                    return new IdleRightBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Moving:
                    return new MovingRightBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Jumping:
                    return new JumpingRightBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Crouching:
                    return new CrouchRightBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Turning:
                    return new TurningLeftBigMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetFireLuigiSpriteRight(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case LuigiStateMachine.LuigiMoveState.Idle:
                    return new IdleRightFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Moving:
                    return new MovingRightFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Jumping:
                    return new JumpingRightFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Crouching:
                    return new CrouchRightFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Turning:
                    return new TurningLeftFireMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSmallLuigiSpriteLeft(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case LuigiStateMachine.LuigiMoveState.Idle:
                    return new IdleLeftSmallMario(texture);
                case LuigiStateMachine.LuigiMoveState.Moving:
                    return new MovingLeftSmallMario(texture);
                case LuigiStateMachine.LuigiMoveState.Jumping:
                    return new JumpingLeftSmallMario(texture);
                case LuigiStateMachine.LuigiMoveState.Turning:
                    return new TurningRightSmallMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetBigLuigiSpriteLeft(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case LuigiStateMachine.LuigiMoveState.Idle:
                    return new IdleLeftBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Moving:
                    return new MovingLeftBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Jumping:
                    return new JumpingLeftBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Crouching:
                    return new CrouchLeftBigMario(texture);
                case LuigiStateMachine.LuigiMoveState.Turning:
                    return new TurningRightBigMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetFireLuigiSpriteLeft(LuigiStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case LuigiStateMachine.LuigiMoveState.Idle:
                    return new IdleLeftFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Moving:
                    return new MovingLeftFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Jumping:
                    return new JumpingLeftFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Crouching:
                    return new CrouchLeftFireMario(texture);
                case LuigiStateMachine.LuigiMoveState.Turning:
                    return new TurningRightFireMario(texture);
                default:
                    return null;
            }
        }
    }
}
