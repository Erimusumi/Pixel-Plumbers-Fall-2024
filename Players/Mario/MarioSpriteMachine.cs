using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

namespace Pixel_Plumbers_Fall_2024
{
    public class MarioSpriteMachine : IMarioSpriteMachine
    {
        private static ICharacter lastValidSprite;

        public ICharacter UpdatePlayerSprite(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            ICharacter newSprite = null;
            //Mario being dead takes priority over all other sprites
            if (marioStateMachine.IsDead())
            {
                newSprite = new DeadCharacter(texture);
            } else if (marioStateMachine.Wins())
            {
                newSprite = GetWinMarioState(marioStateMachine, texture);
            }
            else {
                newSprite = GetSpriteForFaceState(marioStateMachine, texture);
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

            return lastValidSprite ?? new IdleLeftBig(texture);
        }

        private static ICharacter GetSpriteForFaceState(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentFaceState)
            {
                case PlayerStateMachine.PlayerFaceState.Right:
                    return GetSpriteForGameStateRight(marioStateMachine, texture);
                case PlayerStateMachine.PlayerFaceState.Left:
                    return GetSpriteForGameStateLeft(marioStateMachine, texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetSpriteForGameStateRight(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentGameState)
            {
                case PlayerStateMachine.PlayerGameState.Small:
                    return GetSmallMarioSpriteRight(marioStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Big:
                    return GetBigMarioSpriteRight(marioStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Fire:
                    return GetFireMarioSpriteRight(marioStateMachine, texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetSpriteForGameStateLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentGameState)
            {
                case PlayerStateMachine.PlayerGameState.Small:
                    return GetSmallMarioSpriteLeft(marioStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Big:
                    return GetBigMarioSpriteLeft(marioStateMachine, texture);
                case PlayerStateMachine.PlayerGameState.Fire:
                    return GetFireMarioSpriteLeft(marioStateMachine, texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetSmallMarioSpriteRight(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightSmall(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightSmall(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightSmall(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftSmall(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetBigMarioSpriteRight(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightBig(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightBig(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightBig(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchRightBig(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftBig(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetFireMarioSpriteRight(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleRightFire(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingRightFire(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingRightFire(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchRightFire(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningLeftFire(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetSmallMarioSpriteLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftSmall(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftSmall(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftSmall(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightSmall(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetBigMarioSpriteLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftBig(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftBig(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftBig(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchLeftBig(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightBig(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetFireMarioSpriteLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
            {
                case PlayerStateMachine.PlayerMoveState.Idle:
                    return new IdleLeftFire(texture);
                case PlayerStateMachine.PlayerMoveState.Moving:
                    return new MovingLeftFire(texture);
                case PlayerStateMachine.PlayerMoveState.Jumping:
                    return new JumpingLeftFire(texture);
                case PlayerStateMachine.PlayerMoveState.Crouching:
                    return new CrouchLeftFire(texture);
                case PlayerStateMachine.PlayerMoveState.Turning:
                    return new TurningRightFire(texture);
                default:
                    return null;
            }
        }

        private static ICharacter GetWinMarioState(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentGameState) {
                case PlayerStateMachine.PlayerGameState.Small:
                    return new WinSmall(texture);
                case PlayerStateMachine.PlayerGameState.Big:
                    return new WinBig(texture);
                case PlayerStateMachine.PlayerGameState.Fire:
                    return new WinFire(texture);
                default: return null;
            }

        }
    }
}
