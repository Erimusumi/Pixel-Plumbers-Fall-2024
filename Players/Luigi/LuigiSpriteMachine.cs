using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024
{
    public class LuigiSpriteMachine : IMarioSpriteMachine
    {
        private static ICharacter lastValidSprite;
        public ICharacter UpdatePlayerSprite(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            ICharacter newSprite = null;
            if (luigiStateMachine.IsDead())
            {
                newSprite = new DeadLuigi(texture);
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

            return lastValidSprite ?? new IdleLeftBigLuigi(texture);
        }

        private static ICharacter GetSpriteForFaceState(PlayerStateMachine luigiStateMachine, Texture2D texture)
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

        private static ICharacter GetSpriteForGameStateRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
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

        private static ICharacter GetSpriteForGameStateLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
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

        private static ICharacter GetSmallLuigiSpriteRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightSmallLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightSmallLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightSmallLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftSmallLuigi(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetBigLuigiSpriteRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchRightBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftBigLuigi(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetFireLuigiSpriteRight(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchRightFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftFireLuigi(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetSmallLuigiSpriteLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftSmallLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftSmallLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftSmallLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightSmallLuigi(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetBigLuigiSpriteLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchLeftBigLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightBigLuigi(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetFireLuigiSpriteLeft(PlayerStateMachine luigiStateMachine, Texture2D texture)
        {
            switch (luigiStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchLeftFireLuigi(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightFireLuigi(texture);
                default:
                    return null;
            }
        }
    }
}
