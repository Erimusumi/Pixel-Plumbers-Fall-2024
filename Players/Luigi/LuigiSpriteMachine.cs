using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024
{
    public class LuigiSpriteMachine
    {
        private static IMarioSprite lastValidSprite;
        public static IMarioSprite UpdateLuigiSprite(PlayerStateMachine luigiStateMachine, Texture2D texture)
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

        private static IMarioSprite GetSpriteForFaceState(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentFaceState)
            {
                case PlayerStateMachine.PlayerFaceState.Right:
                    return GetSpriteForGameStateRight(luigiStateMachine, texture);
                case PlayerStateMachine.PlayerFaceState.Left:
                    return GetSpriteForGameStateLeft(luigiStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSpriteForGameStateRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentGameState)
            {
                case PlayerStateMachine.PlayerGameState.Small:
                    return GetSmallLuigiSpriteRight(luigiStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Big:
                    return GetBigLuigiSpriteRight(luigiStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Fire:
                    return GetFireLuigiSpriteRight(luigiStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSpriteForGameStateLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentGameState)
            {
                case PlayerStateMachine.PlayerGameState.Small:
                    return GetSmallLuigiSpriteLeft(luigiStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Big:
                    return GetBigLuigiSpriteLeft(luigiStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Fire:
                    return GetFireLuigiSpriteLeft(luigiStateMachine, texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSmallLuigiSpriteRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightSmallMario(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightSmallMario(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightSmallMario(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftSmallMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetBigLuigiSpriteRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchRightBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftBigMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetFireLuigiSpriteRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchRightFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftFireMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetSmallLuigiSpriteLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftSmallMario(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftSmallMario(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftSmallMario(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightSmallMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetBigLuigiSpriteLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchLeftBigMario(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightBigMario(texture);
                default:
                    return null;
            }
        }

        private static IMarioSprite GetFireLuigiSpriteLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchLeftFireMario(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightFireMario(texture);
                default:
                    return null;
            }
        }
    }
}
