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
                newSprite = new DeadMario(texture);
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

            return lastValidSprite ?? new IdleLeftBigMario(texture);
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

        private static ICharacter GetBigMarioSpriteRight(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
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

        private static ICharacter GetFireMarioSpriteRight(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
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

        private static ICharacter GetSmallMarioSpriteLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
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

        private static ICharacter GetBigMarioSpriteLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
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

        private static ICharacter GetFireMarioSpriteLeft(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentMoveState)
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

        private static ICharacter GetWinMarioState(PlayerStateMachine marioStateMachine, Texture2D texture)
        {
            switch (marioStateMachine.CurrentGameState) {
                case PlayerStateMachine.PlayerGameState.Small:
                    return new WinSmallMario(texture);
                case PlayerStateMachine.PlayerGameState.Big:
                    return new WinBigMario(texture);
                case PlayerStateMachine.PlayerGameState.Fire:
                    return new WinFireMario(texture);
                default: return null;
            }

        }
    }
}
